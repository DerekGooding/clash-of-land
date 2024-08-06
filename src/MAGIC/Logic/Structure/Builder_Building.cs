﻿using ClashLand.Logic.Components;
using ClashLand.Logic.Enums;

namespace ClashLand.Logic.Structure
{
    using ClashLand.Files;
    using ClashLand.Files.CSV_Helpers;
    using ClashLand.Files.CSV_Logic;

    internal class Builder_Building : ConstructionItem
    {
        public Builder_Building(Data data, Level level) : base(data, level)
        {
            AddComponent(new Hitpoint_Component());
            if (GetBuildingData.IsHeroBarrack)
            {
                Heroes hd = CSV.Tables.Get(Gamefile.Heroes).GetData(GetBuildingData.HeroType) as Heroes;
                AddComponent(new Hero_Base_Component(this, hd));
            }
            if (GetBuildingData.UpgradesUnits)
                AddComponent(new Unit_Upgrade_Component(this));
            if (GetBuildingData.UnitProduction[0] > 0)
            {
                AddComponent(new Unit_Production_Component(this));
            }
            if (GetBuildingData.Village2Housing > 0)
            {
                AddComponent(new Unit_Storage_V2_Componenent(this, 0));
            }
            if (GetBuildingData.BuildingClass == "Defense" || GetBuildingData.BuildingClass == "Wall")
            {
                AddComponent(new Combat_Component(this));
            }
            if (!string.IsNullOrEmpty(GetBuildingData.ProducesResource))
            {
                AddComponent(new Resource_Production_Component(this, level));
            }

            if (GetBuildingData.MaxStoredElixir2[0] > 0 || GetBuildingData.MaxStoredGold2[0] > 0)
            {
                AddComponent(new Resource_Storage_Component(this));
            }
        }

        internal override int ClassId => 7;

        public Buildings GetBuildingData => (Buildings)GetData();
    }
}