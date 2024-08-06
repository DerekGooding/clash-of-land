﻿using ClashLand.Core.Networking;
using ClashLand.Logic;
using ClashLand.Packets.Messages.Server.Leaderboard;

namespace ClashLand.Packets.Messages.Client.Leaderboard
{
    internal class Request_Local_Clans : Message
    {
        public Request_Local_Clans(Device Device) : base(Device)
        {
        }

        internal override void Decode()
        {
        }

        internal override void Process()
        {
            if (this.Device.Player.Avatar.Variables.IsBuilderVillage)
            {
            }
            else
            {
                new Local_Clans(this.Device).Send();
            }
        }
    }
}