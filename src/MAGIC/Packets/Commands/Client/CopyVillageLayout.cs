using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Commands.Client
{
    internal class CopyVillageLayout : Command
    {
        public CopyVillageLayout(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        public int PasteLayoutID;

        public int CopiedLayoutID;

        public int Tick;

        internal override void Decode()
        {
            this.Tick = this.Reader.ReadInt32();
            this.CopiedLayoutID = this.Reader.ReadInt32();
            this.PasteLayoutID = this.Reader.ReadInt32();
        }
    }
}