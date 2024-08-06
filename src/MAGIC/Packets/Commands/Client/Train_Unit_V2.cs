﻿using ClashLand.Extensions.Binary;
using ClashLand.Files;
using ClashLand.Files.CSV_Logic;
using ClashLand.Logic;
using ClashLand.Logic.Components;
using ClashLand.Logic.Enums;
using ClashLand.Logic.Structure;

namespace ClashLand.Packets.Commands.Client
{
    internal class Train_Unit_V2 : Command
    {
        internal int BuildingID;
        internal int Unknown1;
        internal Characters Unit;
        internal int Tick;

        public Train_Unit_V2(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.BuildingID = this.Reader.ReadInt32();
            this.Unknown1 = this.Reader.ReadInt32();
            this.Unit = CSV.Tables.Get(Gamefile.Characters).GetDataWithID(this.Reader.ReadInt32()) as Characters;
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            var go = this.Device.Player.GameObjectManager.GetBuilderVillageGameObjectByID(this.BuildingID);
            if (go != null)
            {
                Builder_Building b = (Builder_Building)go;
                Unit_Storage_V2_Componenent c = b.GetUnitStorageV2Component();
                c?.AddUnit(this.Unit);
            }
        }
    }
}