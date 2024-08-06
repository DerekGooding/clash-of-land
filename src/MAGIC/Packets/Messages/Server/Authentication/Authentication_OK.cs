﻿using ClashLand.Extensions;
using ClashLand.Extensions.List;
using ClashLand.Logic;
using ClashLand.Logic.Enums;

namespace ClashLand.Packets.Messages.Server.Authentication
{
    internal class Authentication_OK : Message
    {
        public Authentication_OK(Device client) : base(client)
        {
            this.Identifier = 20104;
            this.Device.State = State.LOGGED;
        }

        internal int ServerBuild;
        internal int ServerMajorVersion;
        internal int ContentVersion;

        internal override void Encode()
        {
            Player avatar = this.Device.Player.Avatar;
            this.Data.AddLong(avatar.UserId);
            this.Data.AddLong(avatar.UserId);

            this.Data.AddString(avatar.Token);

            this.Data.AddString(avatar.Facebook.Identifier);
            this.Data.AddString(avatar.Gamecenter.Identifier);

            this.Data.AddInt(ServerMajorVersion);
            this.Data.AddInt(ServerBuild);
            this.Data.AddInt(ContentVersion);

            this.Data.AddString("prod");

            this.Data.AddInt(avatar.Login_Count++); //Session Count
            this.Data.AddInt((int)avatar.PlayTime.TotalSeconds); //Playtime Second
            this.Data.AddInt(0);

            this.Data.AddString(Logic.Structure.API.Facebook.ApplicationID);

            this.Data.AddString(TimeUtils.ToJavaTimestamp(avatar.LastSave).ToString()); // 14 75 26 87 86 11 24 33
            this.Data.AddString(TimeUtils.ToJavaTimestamp(avatar.Created).ToString()); // 14 78 03 95 03 10 0

            this.Data.AddInt(0);
            this.Data.AddString(avatar.Google.Identifier);
            this.Data.AddString(avatar.Region);
            this.Data.AddString(null);
            this.Data.AddInt(1); //Unknown
            this.Data.AddString(Constants.Events);
            //this.Data.AddString("http://127.0.0.1/events/");
            //this.Data.AddString("http://api.clashersrepublic.net:8082/api/v1/events/download"); //Aidids events host
            //this.Data.AddString("http://b46f744d64acd2191eda-3720c0374d47e9a0dd52be4d281c260f.r11.cf2.rackcdn.com/"); //Patch server?
            this.Data.AddString("null");
        }
    }
}