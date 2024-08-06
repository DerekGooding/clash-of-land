using ClashLand.Logic.Structure.Slots.Items;
using System;
using System.Collections.Generic;

namespace ClashLand.Logic.Structure.Slots
{
    internal class Units : List<Slot>, ICloneable
    {
        internal Player Player;

        internal Units()
        {
            // Units.
        }

        internal Units(Player _Player)
        {
            this.Player = _Player;
        }

        internal Units Clone()
        {
            return this.MemberwiseClone() as Units;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}