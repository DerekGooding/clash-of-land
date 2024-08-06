﻿using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Commands.Client
{
    internal class Move_Building : Command
    {
        internal int BuildingId;
        internal int Tick;
        internal Vector Position;

        public Move_Building(Reader reader, Device client, int id) : base(reader, client, id)
        {
            this.Position = new Vector(0, 0);
        }

        internal override void Decode()
        {
            this.Position.X = this.Reader.ReadInt32();
            this.Position.Y = this.Reader.ReadInt32();
            this.BuildingId = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            var go = this.Device.Player.Avatar.Variables.IsBuilderVillage ? this.Device.Player.GameObjectManager.GetBuilderVillageGameObjectByID(BuildingId) : this.Device.Player.GameObjectManager.GetGameObjectByID(BuildingId);
            go?.SetPositionXY(Position);
        }
    }
}