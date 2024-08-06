namespace ClashLand.Packets.Commands.Client.Unknown
{
    using ClashLand.Extensions.Binary;
    using ClashLand.Logic;

    internal class Unknown_585 : Command
    {
        public Unknown_585(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
        }

        public int Tick { get; private set; }

        internal override void Decode()
        {
            this.Reader.ReadByte();
            this.Reader.ReadInt32();
            base.Decode();
        }
    }
}