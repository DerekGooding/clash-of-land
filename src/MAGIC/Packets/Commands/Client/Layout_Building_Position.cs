using ClashLand.Extensions.Binary;
using ClashLand.Logic;
using System.Collections.Generic;

namespace ClashLand.Packets.Commands.Client
{
    internal class Layout_Building_Position : Command
    {
        internal List<BuildingToMove> Buildings;

        public Layout_Building_Position(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
        }

        public int Tick { get; private set; }

        internal override void Decode()
        {
            this.Reader.ReadInt32();
            int buildingCount = this.Reader.ReadInt32();
            this.Buildings = new List<BuildingToMove>(buildingCount);

            for (int i = 0; i < buildingCount; i++)
            {
                this.Buildings.Add(new BuildingToMove
                {
                    X = this.Reader.ReadInt32(),
                    Y = this.Reader.ReadInt32(),
                    Id = this.Reader.ReadInt32()
                });
            }

            base.Decode();
        }
    }
}