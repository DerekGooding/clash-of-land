using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Messages.Client
{
    internal class Device_Link_Menu_Closed : Message
    {
        public Device_Link_Menu_Closed(Device Device, Reader Reader) : base(Device, Reader)
        {
            // DeviceLinkMenuClosed.
        }
    }
}