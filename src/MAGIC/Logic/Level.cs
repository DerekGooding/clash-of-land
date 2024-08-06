﻿using ClashLand.Logic.Manager;
using ClashLand.Logic.Structure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ClashLand.Logic
{
    internal class Level
    {
        internal Device Device;
        internal Player Avatar;

        internal GameObjectManager GameObjectManager;
        internal Village_Worker_Manager VillageWorkerManager;
        internal Builder_Village_Worker_Manager BuilderVillageWorkerManager;
        internal object Variables;

        internal Level()
        {
            this.BuilderVillageWorkerManager = new Builder_Village_Worker_Manager();
            this.VillageWorkerManager = new Village_Worker_Manager();
            this.GameObjectManager = new GameObjectManager(this);
            this.Avatar = new Player();
        }

        internal Level(long id)
        {
            this.BuilderVillageWorkerManager = new Builder_Village_Worker_Manager();
            this.VillageWorkerManager = new Village_Worker_Manager();
            this.GameObjectManager = new GameObjectManager(this);
            this.Avatar = new Player(id);
        }

        internal string JSON
        {
            get => JsonConvert.SerializeObject(GameObjectManager.JSON, Formatting.Indented);
            set => this.GameObjectManager.JSON = JObject.Parse(value);
        }

        internal void Reset()
        {
            var gameObjects = GameObjectManager.GetAllGameObjects();
            foreach (List<GameObject> t in gameObjects)
                t.Clear();
        }

        internal void Tick()
        {
            this.Avatar.LastTick = DateTime.UtcNow;
            GameObjectManager.Tick();
        }

        internal ComponentManager GetComponentManager => this.GameObjectManager.GetComponentManager();

        internal bool HasFreeVillageWorkers => this.VillageWorkerManager.GetFreeWorkers() > 0;
        internal bool HasFreeBuilderVillageWorkers => this.BuilderVillageWorkerManager.GetFreeWorkers() > 0;
    }
}