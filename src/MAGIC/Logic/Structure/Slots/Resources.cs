﻿using ClashLand.Extensions.List;
using ClashLand.Logic.Structure.Slots.Items;
using System.Collections.Generic;
using System.Linq;

namespace ClashLand.Logic.Structure.Slots
{
    internal class Resources : List<Slot>
    {
        internal Player Player;

        internal Resources()
        {
            // Resources.
        }

        internal Resources(Player _Player, bool Initialize = false)
        {
            this.Player = _Player;

            if (Initialize)
                this.Initialize();
        }

        internal int Gems => this.Get(Enums.Resource.Diamonds);

        internal int Get(int Gl_ID)
        {
            int i = this.FindIndex(R => R.Data == Gl_ID);

            if (i > -1)
                return this[i].Count;

            return 0;
        }

        internal int Get(Enums.Resource Global)
        {
            return this.Get(3000000 + (int)Global);
        }

        internal void Set(int Global, int Count)
        {
            int i = this.FindIndex(R => R.Data == Global);

            if (i > -1)
                this[i].Count = Count;
            else
                this.Add(new Slot(Global, Count));
        }

        internal void Set(Enums.Resource Resource, int Count)
        {
            this.Set(3000000 + (int)Resource, Count);
        }

        internal void Plus(int Global, int Count)
        {
            int i = this.FindIndex(R => R.Data == Global);

            if (i > -1)
                this[i].Count += Count;
            else this.Add(new Slot(Global, Count));
        }

        internal void Plus(Enums.Resource Resource, int Count)
        {
            this.Plus(3000000 + (int)Resource, Count);
        }

        internal bool Minus(int Global, int Count)
        {
            int i = this.FindIndex(R => R.Data == Global);

            if (i > -1)
                if (this[i].Count >= Count)
                {
                    this[i].Count -= Count;
                    return true;
                }

            return false;
        }

        internal void Minus(Enums.Resource _Resource, int _Value)
        {
            int Index = this.FindIndex(T => T.Data == 3000000 + (int)_Resource);

            if (Index > -1)
            {
                this[Index].Count -= _Value;
            }
        }

        internal byte[] ToBytes
        {
            get
            {
                List<byte> Packet = new List<byte>();

                Packet.AddInt(this.Count - 1);
                foreach (Slot Resource in this.Skip(1))
                {
                    Packet.AddInt(Resource.Data);
                    Packet.AddInt(Resource.Count);
                }

                return Packet.ToArray();
            }
        }

        /* [Obsolete]
         internal void ResourceChangeHelper(int GlobalID, int count)
         {
             int current = this.Get(GlobalID);
             int newResourceValue = Math.Max(current + count, 0);
             if (count >= 1)
             {
                 int resourceCap = this.Player.Resources_Cap.Get(GlobalID);
                 if (current < resourceCap)
                 {
                     if (newResourceValue > resourceCap)
                     {
                         newResourceValue = resourceCap;
                     }
                 }
             }
             this.Plus(GlobalID, count);
         }

         [Obsolete]
         internal void ResourceChangeHelper(Enums.Resource resource, int count)
         {
             int current = this.Get(resource);
             int newResourceValue = Math.Max(current + count, 0);
            if (count >= 1)
             {
                 int resourceCap = this.Player.Resources_Cap.Get(resource);
                 if (resourceCap > current)
                 {
                     if (newResourceValue > resourceCap)
                     {
                         newResourceValue = resourceCap;
                     }
                 }
             }
             this.Plus(resource, count);
         }*/

        internal void Initialize()
        {
#if DEBUG
            this.Set(Enums.Resource.Diamonds, 600000);

            this.Set(Enums.Resource.Gold, 10000000);
            this.Set(Enums.Resource.Elixir, 10000000);
            this.Set(Enums.Resource.DarkElixir, 10000000);
            this.Set(Enums.Resource.Builder_Elixir, 10000000);
            this.Set(Enums.Resource.Builder_Gold, 10000000);
            //this.Set(Enums.Resource.Trophies, 300000);
#else
            this.Set(Enums.Resource.Diamonds, (CSV.Tables.Get(Enums.Gamefile.Globals).GetData("STARTING_DIAMONDS") as Globals).NumberValue);
            this.Set(Enums.Resource.Gold, (CSV.Tables.Get(Enums.Gamefile.Globals).GetData("STARTING_GOLD") as Globals).NumberValue);
            this.Set(Enums.Resource.Elixir, (CSV.Tables.Get(Enums.Gamefile.Globals).GetData("STARTING_ELIXIR") as Globals).NumberValue);
            this.Set(Enums.Resource.Builder_Elixir, (CSV.Tables.Get(Enums.Gamefile.Globals).GetData("STARTING_GOLD2") as Globals).NumberValue);
            this.Set(Enums.Resource.Builder_Gold, (CSV.Tables.Get(Enums.Gamefile.Globals).GetData("STARTING_ELIXIR2") as Globals).NumberValue);
#endif
        }
    }
}