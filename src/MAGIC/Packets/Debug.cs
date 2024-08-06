﻿using ClashLand.Core.Networking;
using ClashLand.Logic;
using ClashLand.Packets.Messages.Server;

namespace ClashLand.Packets
{
    internal class Debug
    {
        internal Device Device;
        internal string[] Parameters;

        internal Debug(Device Device, params string[] Parameters)
        {
            this.Device = Device;
            this.Parameters = Parameters;
        }

        internal virtual void Process()
        {
            // Process.
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
    }
}