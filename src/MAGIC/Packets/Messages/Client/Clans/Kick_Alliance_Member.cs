﻿using ClashLand.Extensions.Binary;
using ClashLand.Logic;
using System.IO;

namespace ClashLand.Packets.Messages.Client
{
    internal class Kick_Alliance_Member : Message
    {
        private int HighID;
        private int LowID;

        public Kick_Alliance_Member(Device Device, Reader Reader) : base(Device, Reader)
        {
            // KickClanMember.
        }

        internal override void Decode()
        {
            this.HighID = ((BinaryReader)this.Reader).ReadInt32();
            this.LowID = ((BinaryReader)this.Reader).ReadInt32();
            //this.HighID = this.Reader.ReadInt32();
            //this.LowID  = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            base.Process();
        }
    }
}