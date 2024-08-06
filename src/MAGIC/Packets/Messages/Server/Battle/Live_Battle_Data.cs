using ClashLand.Core.Networking;
using ClashLand.Extensions.List;
using ClashLand.Logic;
using System;
using System.Threading;

namespace ClashLand.Packets.Messages.Server.Battle
{
    internal class Live_Battle_Data : Message
    {
        public Live_Battle_Data(Device Device) : base(Device)
        {
            this.Identifier = 24119;
        }

        internal override void Encode()
        {
            this.Data.AddIntEndian((int)(this.Device.Player.Avatar.LoginTime - DateTime.UtcNow).TotalSeconds);
            this.Data.AddInt(0); //Command count
        }

        internal override void Process()
        {
            Thread.Sleep(1500);
            this.Device.Keep_Alive.Send();
            new Live_Battle_Data(this.Device).Send();
        }
    }
}