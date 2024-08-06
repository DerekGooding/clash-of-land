﻿using ClashLand.Extensions.List;
using ClashLand.Logic;

namespace ClashLand.Packets.Messages.Server.Authentication
{
    internal class Unlock_Account_OK : Message
    {
        internal Player Account;

        internal Unlock_Account_OK(Device Device) : base(Device)
        {
            this.Identifier = 20132;
        }

        internal override void Encode()
        {
            this.Data.AddLong(this.Account.UserId);
            this.Data.AddString(this.Account.Token);
        }
    }
}