using ClashLand.Logic.Structure.Slots.Items;
using System;
using System.Collections.Generic;

namespace ClashLand.Logic.Structure.Slots
{
    internal class Battle_Commands : List<Battle_Command>
    {
        public void Add(Battle Battle, Battle_Command Command)
        {
            if (Battle.Preparation_Time > 0)
                Battle.Preparation_Skip = (int)Math.Round(Battle.Preparation_Time);

            this.Add(Command);
        }

        public void Add(Items.Battle_V2 Battle, Battle_Command Command)
        {
            if (Battle.Preparation_Time > 0)
                Battle.Preparation_Skip = (int)Math.Round(Battle.Preparation_Time);

            this.Add(Command);
        }
    }
}