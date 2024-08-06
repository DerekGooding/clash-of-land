using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Commands.Client
{
    internal class SaveVillageLayout : Command
    {
        public SaveVillageLayout(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.Reader.Read();
            this.Reader.ReadInt32();
            this.Reader.ReadInt32();
            this.Reader.ReadInt32();
        }
    }
}