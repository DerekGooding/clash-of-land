﻿using ClashLand.Core;
using ClashLand.Core.Networking;
using ClashLand.Extensions;
using ClashLand.Extensions.Binary;
using ClashLand.External.Blake2B;
using ClashLand.External.Sodium;
using ClashLand.Files;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using ClashLand.Packets.Cryptography;
using ClashLand.Packets.Messages.Server;
using ClashLand.Packets.Messages.Server.Authentication;
using ClashLand.Packets.Messages.Server.Clans;
using System;
using System.Linq;
using System.Text;

namespace ClashLand.Packets.Messages.Client.Authentication
{
    internal class Authentication : Message
    {
        public Authentication(Device device) : base(device)
        {
            this.Device.State = State.LOGIN;
        }

        internal StringBuilder Reason;
        internal long UserId;

        internal string Token, MasterHash, Language, UDID;

        internal int Major, Minor, Revision;

        internal string[] ClientVersion;

        internal override void DecryptSexy()
        {
            byte[] Buffer = this.Reader.ReadBytes((int)this.Length);
            this.Device.Keys.PublicKey = Buffer.Take(32).ToArray();

            Blake2BHasher Blake = new Blake2BHasher();

            Blake.Update(this.Device.Keys.PublicKey);
            Blake.Update(Key.PublicKey);

            this.Device.Keys.RNonce = Blake.Finish();

            Buffer = Sodium.Decrypt(Buffer.Skip(32).ToArray(), this.Device.Keys.RNonce, Key.PrivateKey, this.Device.Keys.PublicKey);

            this.Device.Keys.SNonce = Buffer.Skip(24).Take(24).ToArray();
            this.Reader = new Reader(Buffer.Skip(48).ToArray());

            this.Length = (ushort)Buffer.Length;
        }

        internal override void Decode()
        {
            this.UserId = this.Reader.ReadInt64();

            this.Token = this.Reader.ReadString();

            this.Major = this.Reader.ReadInt32();
            this.Minor = this.Reader.ReadInt32();
            this.Revision = this.Reader.ReadInt32();

            this.MasterHash = this.Reader.ReadString();

            this.Reader.ReadString();

            this.Device.AndroidID = this.Reader.ReadString();
            this.Device.MACAddress = this.Reader.ReadString();
            this.Device.Model = this.Reader.ReadString();

            this.Reader.Seek(4);    // 2000001

            this.Language = this.Reader.ReadString();
            this.Device.OpenUDID = this.Reader.ReadString();
            this.Device.OSVersion = this.Reader.ReadString();

            this.Device.Android = this.Reader.ReadBoolean();

            this.Reader.ReadString();

            this.Device.AndroidID = this.Reader.ReadString();

            this.Reader.ReadString();

            this.Device.Advertising = this.Reader.ReadBoolean();

            this.Reader.ReadString();

            this.Device.ClientSeed = this.Reader.ReadUInt32();

            this.Reader.ReadByte();
            this.Reader.ReadString();
            this.Reader.ReadString();

            this.ClientVersion = this.Reader.ReadString().Split('.');
        }

        internal override void Process()
        {
            if (Constants.RC4)
                new Session_Key(this.Device).Send();

            if (ClientVersion[0] != Constants.ClientVersion[0] || ClientVersion[1] != Constants.ClientVersion[1])
            {
                new Authentication_Failed(this.Device, Logic.Enums.Reason.Update).Send();
                return;
            }

            if (Constants.Maintenance != null)
            {
                new Authentication_Failed(this.Device, Logic.Enums.Reason.Maintenance).Send();
                return;
            }

            if (!string.IsNullOrEmpty(Fingerprint.Json) && !string.Equals(this.MasterHash, Fingerprint.Sha))
            {
                new Authentication_Failed(this.Device, Logic.Enums.Reason.Patch).Send();
                return;
            }

            if (this.UserId == 0)
            {
                if (Token == null)
                {
                    this.Device.Player = Players.New();
                    this.Device.Player.Avatar.Region =
                        Resources.Region.GetIpCountry(this.Device.Player.Avatar.IpAddress = this.Device.IPAddress);

                    if (this.Device.Player != null)
                    {
                        if (this.Device.Player.Avatar.Locked)
                        {
                            new Authentication_Failed(this.Device, Logic.Enums.Reason.Locked).Send();
                        }
                        else
                        {
                            this.Login();
                        }
                    }
                    else
                    {
                        new Authentication_Failed(this.Device, Logic.Enums.Reason.Pause).Send();
                    }
                }
                else
                {
                    new Authentication_Failed(this.Device, (Reason)2).Send();
                }
            }
            else if (this.UserId > 0)
            {
                if (Token == null)
                {
                    new Authentication_Failed(this.Device, (Reason)2).Send();
                    return;
                }
                else
                {
                    this.Device.Player = Players.Get(this.UserId);
                    if (this.Device.Player != null)
                    {
                        if (string.Equals(this.Token, this.Device.Player.Avatar.Token))
                        {
                            if (this.Device.Player.Avatar.Locked)
                            {
                                new Authentication_Failed(this.Device, Logic.Enums.Reason.Locked).Send();
                            }
                            else if (this.Device.Player.Avatar.Banned)
                            {
                                this.Reason = new StringBuilder();
                                this.Reason.AppendLine(
                                    "Your account has been banned from our servers, please contact one of the server staff members with these following information:");
                                this.Reason.AppendLine();
                                this.Reason.AppendLine("Your Account Name: " + this.Device.Player.Avatar.Name);
                                this.Reason.AppendLine("Your Account ID: " + this.Device.Player.Avatar.UserId);
                                this.Reason.AppendLine("Your Account Tag: " +
                                                       GameUtils.GetHashtag(this.Device.Player.Avatar.UserId));
                                this.Reason.AppendLine("Your Account Ban Duration: " +
                                                       Math.Round(
                                                           (this.Device.Player.Avatar.BanTime.AddDays(3) -
                                                            DateTime.UtcNow).TotalDays, 3) + " Day");
                                this.Reason.AppendLine("Your Account Unlock Date : " +
                                                       this.Device.Player.Avatar.BanTime.AddDays(3));
                                this.Reason.AppendLine();

                                new Authentication_Failed(this.Device, Logic.Enums.Reason.Banned)
                                {
                                    Message = Reason.ToString()
                                }.Send();
                            }
                            else
                            {
                                this.Login();
                            }
                        }
                        else
                        {
                            new Authentication_Failed(this.Device, Logic.Enums.Reason.Locked).Send();
                        }
                    }
                    else
                    {
                        this.Device.Player = Players.New(this.UserId, this.Token);
                        this.Device.Player.Avatar.Region =
                            Resources.Region.GetIpCountry(this.Device.Player.Avatar.IpAddress =
                                this.Device.IPAddress);
                        this.Login();
                    }
                }
            }
        }

        internal void Login()
        {
            this.Device.Player.Device = this.Device;
            this.Device.Player.Avatar.LoginTime = DateTime.UtcNow;
            Resources.GChat.Add(this.Device);
            Resources.PRegion.Add(this.Device.Player);

            //new Authentication_Failed(this.Device,(Reason)19).Send();
            new Authentication_OK(this.Device).Send();
            new Own_Home_Data(this.Device).Send();

            // new Own_Home_Data(this.Device).Send();
            new Server.Avatar_Stream(this.Device).Send();
            //Server.Avatar_Stream avatar_Stream = new Server.Avatar_Stream(Device);
            //avatar_Stream.Send();
            //new Game_News(this.Device).Send();
            if (this.Device.Player.Avatar.ClanId > 0)
            {
                Clan Alliance = Resources.Clans.Get(this.Device.Player.Avatar.ClanId);

                if (Alliance != null)
                {
                    this.Device.Player.Avatar.Alliance_Level = Alliance.Level;

                    new Alliance_Full_Entry(this.Device) { Clan = Alliance }.Send();
                    //new War_Map(this.Device).Send();

                    if (Alliance.Chats != null)
                    {
                        new Alliance_All_Stream_Entry(this.Device, Alliance).Send();
                    }
                }
                else
                {
                    this.Device.Player.Avatar.ClanId = 0;
                }
            }
            //new Server.Avatar_Stream(this.Device).Send();
        }
    }
}