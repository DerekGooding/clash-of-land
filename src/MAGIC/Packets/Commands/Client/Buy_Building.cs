﻿using ClashLand.Extensions.Binary;
using ClashLand.Files;
using ClashLand.Files.CSV_Logic;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using ClashLand.Logic.Structure;

namespace ClashLand.Packets.Commands.Client
{
    internal class Buy_Building : Command
    {
        internal int BuildingId;
        internal int Tick;
        internal Vector Vector;

        public Buy_Building(Reader reader, Device client, int id) : base(reader, client, id)
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
            var bd = (Buildings)CSV.Tables.Get(Gamefile.Buildings).GetDataWithID(BuildingId);
            if (!ca.Variables.IsBuilderVillage)
            {
                var b = new Building(bd, this.Device.Player);

                if (ca.HasEnoughResources(bd.GetBuildResource(0).GetGlobalID(), bd.GetBuildCost(0)))
                {
                    if (bd.IsWorkerBuilding())
                    {
                        if (this.Device.Player.VillageWorkerManager.WorkerCount > 0)
                        {
                            int Cost = 0;
                            var row = CSV.Tables.Get(Gamefile.Globals);
                            if (this.Device.Player.VillageWorkerManager.WorkerCount == 1)
                            {
                                Cost = ((Globals)row.GetData("WORKER_COST_2ND")).NumberValue;
                            }
                            else if (this.Device.Player.VillageWorkerManager.WorkerCount == 2)
                            {
                                Cost = ((Globals)row.GetData("WORKER_COST_3RD")).NumberValue;
                            }
                            else if (this.Device.Player.VillageWorkerManager.WorkerCount == 3)
                            {
                                Cost = ((Globals)row.GetData("WORKER_COST_4TH")).NumberValue;
                            }
                            else if (this.Device.Player.VillageWorkerManager.WorkerCount >= 4)
                            {
                                Cost = ((Globals)row.GetData("WORKER_COST_5TH")).NumberValue;
                            }

                            var rd = bd.GetBuildResource(0);
                            ca.Resources.Minus(rd.GetGlobalID(), Cost);
                        }
                        b.StartConstructing(this.Vector, false);
                        this.Device.Player.GameObjectManager.AddGameObject(b);
                        return;
                    }

                    if (this.Device.Player.HasFreeVillageWorkers)
                    {
                        var rd = bd.GetBuildResource(0);
                        ca.Resources.Minus(rd.GetGlobalID(), bd.GetBuildCost(0));

                        b.StartConstructing(this.Vector, this.Device.Player.Avatar.Variables.IsBuilderVillage);
                        this.Device.Player.GameObjectManager.AddGameObject(b);
                    }
                }
            }
            else
            {
                var b = new Builder_Building(bd, this.Device.Player);
                if (ca.HasEnoughResources(bd.GetBuildResource(0).GetGlobalID(), bd.GetBuildCost(0)))
                {
                    if (bd.IsWorker2Building())
                    {
                        b.StartConstructing(this.Vector, true);
                        this.Device.Player.GameObjectManager.AddGameObject(b);
                        return;
                    }

                    if (this.Device.Player.HasFreeBuilderVillageWorkers)
                    {
                        var rd = bd.GetBuildResource(0);
                        ca.Resources.Minus(rd.GetGlobalID(), bd.GetBuildCost(0));

                        b.StartConstructing(this.Vector, true);
                        this.Device.Player.GameObjectManager.AddGameObject(b);
                    }
                }
            }
        }
    }
}