namespace ClashLand.Packets.Commands.Client
{
    using ClashLand.Extensions.Binary;
    using ClashLand.Logic;

    internal class ShieldCostSeen : Command
    {
        public ShieldCostSeen(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
        }

        internal override void Decode()
        {
            this.Reader.ReadInt32();
            this.Reader.ReadByte();

            this.Reader.ReadInt32();
        }

        internal override void Process()
        {
        }
    }
}