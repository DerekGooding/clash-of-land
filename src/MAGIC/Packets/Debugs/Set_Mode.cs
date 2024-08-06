using ClashLand.Logic;
using System.Text;

namespace ClashLand.Packets.Debugs
{
    internal class Set_Mode : Debug
    {
        internal StringBuilder Help;

        public Set_Mode(Device device, params string[] Parameters) : base(device, Parameters)
        {
        }

        internal override void Process()
        {
            base.Process();
        }
    }
}