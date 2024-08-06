﻿using ClashLand.Extensions.Binary;
using ClashLand.Logic;
using ClashLand.Logic.Components;

namespace ClashLand.Packets.Commands.Client
{
    internal class Gear_Up : Command
    {
        internal int Building_ID;
        internal int Tick;

        public Gear_Up(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.Building_ID = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            var go = this.Device.Player.Avatar.Variables.IsBuilderVillage ? this.Device.Player.GameObjectManager.GetBuilderVillageGameObjectByID(this.Building_ID) : this.Device.Player.GameObjectManager.GetGameObjectByID(this.Building_ID);

            if (go?.GetComponent(1, true) == null)
                return;

            var a = ((Combat_Component)go.GetComponent(1, false));
            a.GearUp = 1;
            if (a.AltAttackMode)
            {
                a.AttackMode = true;
                a.AttackModeDraft = true;
            }
        }
    }
}