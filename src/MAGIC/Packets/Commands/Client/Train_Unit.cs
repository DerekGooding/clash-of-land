﻿using ClashLand.Extensions.Binary;
using ClashLand.Files;
using ClashLand.Files.CSV_Logic;
using ClashLand.Logic;
using ClashLand.Logic.Enums;

namespace ClashLand.Packets.Commands.Client
{
    internal class Train_Unit : Command
    {
        internal Characters Troop;
        internal Spells Spell;

        internal int GlobalId;
        internal int Count;
        internal int Tick;

        internal bool IsSpell;

        public Train_Unit(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.Reader.ReadInt32();
            this.Reader.ReadUInt32();
            this.GlobalId = this.Reader.ReadInt32();
            if (this.GlobalId >= 26000000)
            {
                this.IsSpell = true;
                this.Spell = CSV.Tables.Get(Gamefile.Spells).GetDataWithID(GlobalId) as Spells;
            }
            else
            {
                this.Troop = CSV.Tables.Get(Gamefile.Characters).GetDataWithID(GlobalId) as Characters;
            }
            this.Count = this.Reader.ReadInt32();
            this.Reader.ReadUInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            Player _Player = this.Device.Player.Avatar;

            if (IsSpell)
            {
                _Player.Add_Spells(this.Spell.GetGlobalID(), Count);
            }
            else
            {
                _Player.Add_Unit(this.Troop.GetGlobalID(), Count);
            }
        }
    }
}