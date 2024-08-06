﻿using ClashLand.Core.Networking;
using ClashLand.Extensions;
using ClashLand.Extensions.Binary;
using ClashLand.Extensions.List;
using ClashLand.External.Sodium;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using ClashLand.Packets.Messages.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace ClashLand.Packets
{
    internal class Message
    {
        internal Device Device { get; set; }
        internal ushort Identifier;
        internal ushort Version;
        internal int Offset;
        internal int Length { get; set; }
        internal Reader Reader { get; set; }

        internal List<byte> Data
        {
            get => _data;
            set
            {
                _data = value;
                Length = value.Count;
            }
        }

        private List<byte> _data;
        internal string Bookmark;

        internal Message(Device Device)
        {
            this.Device = Device;
            this.Data = new List<byte>();
        }

        internal Message(Device Device, Reader Reader)
        {
            this.Device = Device;
            this.Reader = Reader;
        }

        internal byte[] ToBytes
        {
            get
            {
                List<byte> Packet = new List<byte>();

                Packet.AddUShort(this.Identifier);
                Packet.AddInt24(this.Length);
                Packet.AddUShort(this.Version);
                Packet.AddRange(this.Data);
                return Packet.ToArray();
            }
        }

        internal virtual void Decode()
        {
        }

        internal virtual void Encode()
        {
        }

        internal virtual void Process()
        {
        }

        internal virtual void Decrypt()
        {
            var buffer = Data.ToArray();
            if (Identifier != 10100)
                this.Device.Decrypt(buffer);
            this.Reader = new Reader(buffer);
            this.Length = buffer.Length;
        }

        internal virtual void DecryptSexy()
        {
            if (this.Device.State >= State.LOGGED)
            {
                this.Device.Keys.SNonce.Increment();

                byte[] Decrypted = Sodium.Decrypt(new byte[16].Concat(this.Reader.ReadBytes(this.Length)).ToArray(), this.Device.Keys.SNonce, this.Device.Keys.PublicKey);

                if (Decrypted == null)
                {
                    throw new CryptographicException("We tried to decrypt an incomplete message - Check the network part, still have bytes to read.");
                }

                this.Reader = new Reader(Decrypted);
                this.Length = (ushort)Decrypted.Length;
            }

            var buffer = Data.ToArray();
            if (Identifier != 10100)
                this.Device.Decrypt(buffer);
            this.Device.Keys.SNonce.Increment();
            this.Reader = new Reader(buffer);
            this.Length = buffer.Length;
        }

        internal virtual void Encrypt()
        {
            var buffer = Data.ToArray();
            if (this.Device.State > State.SESSION_OK)
                this.Device.Encrypt(buffer);
            this.Data = new List<byte>(buffer);
        }

        internal void Debug()
        {
            Console.WriteLine(this.GetType().Name + " : " +
                              BitConverter.ToString(
                                  this.Reader.ReadBytes(
                                      (int)(this.Reader.BaseStream.Length - this.Reader.BaseStream.Position))));
        }

        internal void SendChatMessage(string message)
        {
            new Global_Chat_Entry(this.Device)
            {
                Message = message,
                Message_Sender = this.Device.Player.Avatar,
                Bot = true
            }.Send();
        }

        internal void ShowValues()
        {
            //Console.WriteLine(Environment.NewLine);

            foreach (FieldInfo Field in this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (Field != null)
                {
                    Console.WriteLine(Utils.Padding(this.GetType().Name) + " - " + Utils.Padding(Field.Name) + " : " + Utils.Padding(!string.IsNullOrEmpty(Field.Name) ? (Field.GetValue(this) != null ? Field.GetValue(this).ToString() : "(null)") : "(null)", 40));
                }
            }
        }
    }
}