using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Commands.Client.Unknown
{
    internal class Unknown_560 : Command
    {
        public Unknown_560(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
        }

        public int Tick { get; private set; }

        internal override void Decode()
        {
            base.Decode();
            int Count = this.Reader.ReadInt32();

            for (int i = 0; i < Count; i++)
            {
                this.Reader.ReadInt64();
            }
        }
    }
}