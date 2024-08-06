﻿using ClashLand.Extensions.Binary;
using ClashLand.Logic;
using ClashLand.Logic.Structure;

namespace ClashLand.Packets.Commands.Client
{
    internal class Collect_Resources : Command
    {
        internal int BuildingID;
        internal int Tick;

        public Collect_Resources(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.BuildingID = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            var Object = this.Device.Player.Avatar.Variables.IsBuilderVillage ? this.Device.Player.GameObjectManager.GetBuilderVillageGameObjectByID(this.BuildingID) : this.Device.Player.GameObjectManager.GetGameObjectByID(this.BuildingID);

            ((ConstructionItem)Object)?.GetResourceProductionComponent(false)?.CollectResources();
        }
    }
}