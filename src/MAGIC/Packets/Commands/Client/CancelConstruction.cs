namespace ClashLand.Packets.Commands.Client
{
    using ClashLand.Extensions.Binary;
    using ClashLand.Logic;

    internal class CancelConstruction : Command
    {
        public CancelConstruction(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
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