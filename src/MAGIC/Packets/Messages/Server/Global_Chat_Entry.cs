﻿using ClashLand.Core;
using ClashLand.Extensions.List;
using ClashLand.Logic;

namespace ClashLand.Packets.Messages.Server
{
    internal class Global_Chat_Entry : Message
    {
        internal string Message = string.Empty;
        internal Logic.Player Message_Sender = null;
        internal bool Sender = false;
        internal bool Bot = false;
        internal bool Regex = false;

        public Global_Chat_Entry(Device Device) : base(Device)
        {
            this.Identifier = 24715;
        }

        internal override void Encode()
        {
            this.Data.AddString(this.Message);
            this.Data.AddString(Bot ? "Clashology" : Sender ? "You" : Regex ? $"[{this.Message_Sender.Rank}] {this.Message_Sender.Name}" : this.Message_Sender.Name);

            this.Data.AddInt(this.Message_Sender.Level); // Unknown
            this.Data.AddInt(Bot ? 22 : this.Message_Sender.League);

            this.Data.AddLong(this.Message_Sender.UserId);
            this.Data.AddLong(this.Message_Sender.UserId);

            this.Data.AddBool(this.Message_Sender.ClanId > 0);
            if (this.Message_Sender.ClanId > 0)
            {
                var _Clan = Resources.Clans.Get(this.Message_Sender.ClanId);

                this.Data.AddLong(_Clan.Clan_ID);
                this.Data.AddString(_Clan.Name);
                this.Data.AddInt(_Clan.Badge);
            }
        }
    }
}