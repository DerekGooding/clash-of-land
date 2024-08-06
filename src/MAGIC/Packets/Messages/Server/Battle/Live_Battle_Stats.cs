﻿using ClashLand.Extensions.List;
using ClashLand.Logic;

namespace ClashLand.Packets.Messages.Server.Battle
{
    internal class Live_Battle_Stats : Message
    {
        public Live_Battle_Stats(Device Device) : base(Device)
        {
            this.Identifier = 24340;
        }

        internal override void Encode()
        {
            this.Data.AddHexa("00 00 00 03 00 00 00 0A 00 22 3D EE 00 00 00 13 00 12 E8 34 00 00 00 5D 00 1B BF CE"
                .Replace(" ", ""));
        }
    }
}