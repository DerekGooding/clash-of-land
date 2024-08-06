using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Commands.Client
{
    internal class SetActiveVillageLayout : Command
    {
        private int Layout;

        public SetActiveVillageLayout(Reader reader, Device client, int id) : base(reader, client, id)
        {
            //Layout = br.ReadInt32();
            //Console.WriteLine(br.ReadInt32());
            //Console.WriteLine(br.ReadInt32());
        }

        internal override void Decode()
        {
            this.Layout = this.Reader.ReadInt32();
        }
    }
}