﻿using ClashLand.Extensions.Binary;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using ClashLand.Logic.Structure.Slots.Items;

namespace ClashLand.Packets.Commands.Client.Battle
{
    internal class Hero_Rage : Command
    {
        internal int GlobalId;
        internal int Tick;

        public Hero_Rage(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.GlobalId = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            if (this.Device.State == State.IN_PC_BATTLE)
            {
                if (!this.Device.Player.Avatar.Variables.IsBuilderVillage && !this.Device.Player.Avatar.Modes.IsAttackingOwnBase)
                {
                    var Battle = Core.Resources.Battles.Get(this.Device.Player.Avatar.Battle_ID);
                    Battle_Command Command = new Battle_Command
                    {
                        Command_Type = this.Identifier,
                        Command_Base = new Command_Base { Base = { Tick = this.Tick }, Data = this.GlobalId }
                    };
                    Battle.Add_Command(Command);
                }
            }
            else if (this.Device.State == State.IN_1VS1_BATTLE)
            {
                var Battle = Core.Resources.Battles_V2.GetPlayer(this.Device.Player.Avatar.Battle_ID_V2,
                    this.Device.Player.Avatar.UserId);

                Battle_Command Command = new Battle_Command
                {
                    Command_Type = this.Identifier,
                    Command_Base = new Command_Base { Base = { Tick = this.Tick }, Data = this.GlobalId }
                };
                Battle.Add_Command(Command);
            }
        }
    }
}