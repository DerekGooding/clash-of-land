using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Commands.Client
{
    internal class CancelUnitProductionV2 : Command
    {
        public CancelUnitProductionV2(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
        }

        internal override void Decode()
        {
            this.Debug();
        }

        internal override void Process()
        {
            base.Process();
        }
    }
}