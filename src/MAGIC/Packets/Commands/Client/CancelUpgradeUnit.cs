namespace ClashLand.Packets.Commands.Client
{
    using ClashLand.Extensions.Binary;
    using ClashLand.Logic;

    internal class CancelUpgradeUnit : Command
    {
        public CancelUpgradeUnit(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
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