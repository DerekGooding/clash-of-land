﻿using ClashLand.Files.CSV_Logic;
using ClashLand.Logic.Structure;
using Newtonsoft.Json.Linq;

namespace ClashLand.Logic.Components
{
    internal class Unit_Production_Component : Component
    {
        internal bool IsSpellForge;

        public Unit_Production_Component(GameObject go) : base(go)
        {
            SetProductionType(go);
        }

        internal override int Type => 3;

        public void SetProductionType(GameObject go)
        {
            var b = (ConstructionItem)GetParent;
            var bd = (Buildings)b.GetData();
            this.IsSpellForge = bd.IsSpellForge();
        }

        internal override void Load(JObject jsonObject)
        {
            var unitProdObject = (JObject)jsonObject["unit_prod"];
            if (unitProdObject != null)
                this.IsSpellForge = unitProdObject["unit_type"].ToObject<int>() == 1;
        }

        internal override JObject Save(JObject jsonObject)
        {
            var unitProdObject = new JObject { { "m", 1 }, { "unit_type", this.IsSpellForge ? 1 : 0 } };
            jsonObject.Add("unit_prod", unitProdObject);
            return jsonObject;
        }
    }
}