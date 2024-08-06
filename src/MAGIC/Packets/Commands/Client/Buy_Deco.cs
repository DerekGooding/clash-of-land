﻿using ClashLand.Core;
using ClashLand.Extensions.Binary;
using ClashLand.Files;
using ClashLand.Files.CSV_Logic;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using ClashLand.Logic.Structure;

namespace ClashLand.Packets.Commands.Client
{
    internal class Buy_Deco : Command
    {
        internal int BuildingId;
        internal int Tick;
        internal Vector Vector;

        public Buy_Deco(Reader reader, Device client, int id) : base(reader, client, id)
        {
            this.Vector = new Vector();
        }

        internal override void Decode()
        {
            this.Vector.X = this.Reader.ReadInt32();
            this.Vector.Y = this.Reader.ReadInt32();
            this.BuildingId = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            var ca = this.Device.Player.Avatar;
            var bd = (Decos)CSV.Tables.Get(Gamefile.Decos).GetDataWithID(BuildingId);
            if (!ca.Variables.IsBuilderVillage)
            {
                var b = new Deco(bd, this.Device.Player);

                if (ca.HasEnoughResources(bd.GetBuildResource().GetGlobalID(), bd.GetBuildCost()))
                {
                    ca.Resources.Minus(bd.GetGlobalID(), bd.GetBuildCost());
                    b.SetPositionXY(this.Vector);
                    this.Device.Player.GameObjectManager.AddGameObject(b);
                }
            }
            else
            {
                var b = new Builder_Deco(bd, this.Device.Player);
                if (ca.HasEnoughResources(bd.GetBuildResource().GetGlobalID(), bd.GetBuildCost()))
                {
                    ca.Resources.Minus(bd.GetGlobalID(), bd.GetBuildCost());
                    b.SetPositionXY(this.Vector);
                    this.Device.Player.GameObjectManager.AddGameObject(b);
                }
            }
        }
    }
}