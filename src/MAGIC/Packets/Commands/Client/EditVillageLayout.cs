using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Commands.Client
{
    internal class EditVillageLayout : Command
    {
        internal int X;
        internal int Y;
        internal int BuildingID;
        internal int Layout;

        public EditVillageLayout(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.X = this.Reader.ReadInt32();
            this.Y = this.Reader.ReadInt32();
            this.BuildingID = this.Reader.ReadInt32();
            this.Layout = this.Reader.ReadInt32();
            this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            /*if (Layout != level.Avatar.GetActiveLayout())
            {
                GameObject go = level.GameObjectManager.GetGameObjectByID(BuildingID);
                go.SetPositionXY(X, Y, Layout);
            } */
        }
    }
}