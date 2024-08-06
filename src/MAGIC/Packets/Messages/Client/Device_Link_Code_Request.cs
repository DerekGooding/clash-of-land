using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Messages.Client
{
    internal class Device_Link_Code_Request : Message
    {
        public Device_Link_Code_Request(Device Device, Reader Reader) : base(Device, Reader)
        {
            // Device_Link_Code_Request.
        }
    }
}