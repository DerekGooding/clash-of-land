using ClashLand.Core;
using ClashLand.Core.Networking;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using ClashLand.Packets.Messages.Server;
using System;
using System.Linq;
using System.Text;

namespace ClashLand.Packets.Debugs
{
    internal class sysmsg : Debug
    {
        internal StringBuilder Sysmsg;

        public sysmsg(Device device, params string[] Parameters) : base(device, Parameters)
        {
        }

        internal override void Process()
        {
            if (this.Device.Player.Avatar.Rank >= Rank.ADMIN)
                try
                {
                    this.Sysmsg = new StringBuilder();
                    this.Sysmsg.AppendLine("Welcome to Clashology Private Servers");
                    foreach (var _Device in Devices._Devices.Values.ToList())
                    {
                        new Global_Chat_Entry(_Device)
                        {
                            Message = Sysmsg.ToString(),
                            Message_Sender = this.Device.Player.Avatar,
                            Bot = true
                        }.Send();
                    }
                }
                catch (Exception)
                {
                    SendChatMessage("Command Processor: Insufficient privileges.");
                }
        }
    }
}