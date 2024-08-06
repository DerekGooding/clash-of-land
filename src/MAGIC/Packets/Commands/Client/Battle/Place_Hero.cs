﻿using ClashLand.Core;
using ClashLand.Extensions.Binary;
using ClashLand.Files;
using ClashLand.Files.CSV_Logic;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using ClashLand.Logic.Structure.Slots.Items;

namespace ClashLand.Packets.Commands.Client.Battle
{
    internal class Place_Hero : Command
    {
        internal int GlobalId;
        internal int X;
        internal int Y;
        internal int Tick;

        internal Heroes Hero;

        public Place_Hero(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.X = this.Reader.ReadInt32();
            this.Y = this.Reader.ReadInt32();
            this.GlobalId = this.Reader.ReadInt32();
            this.Hero = CSV.Tables.Get(Gamefile.Heroes).GetDataWithID(GlobalId) as Heroes;

            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            if (this.Device.State == State.IN_PC_BATTLE)
            {
                if (!this.Device.Player.Avatar.Variables.IsBuilderVillage && !this.Device.Player.Avatar.Modes.IsAttackingOwnBase)
                {
                    var Battle = Core.Resources.Battles.Get(this.Device.Player.Avatar.Battle_ID);
                    Battle_Command Command =
                        new Battle_Command
                        {
                            Command_Type = this.Identifier,
                            Command_Base =
                                new Command_Base
                                {
                                    Base = new Base { Tick = this.Tick },
                                    Data = this.GlobalId,
                                    X = this.X,
                                    Y = this.Y
                                }
                        };
                    Battle.Add_Command(Command);

                    int Index = Battle.Replay_Info.Units.FindIndex(T => T[0] == this.GlobalId);
                    if (Index > -1)
                        Battle.Replay_Info.Units[Index][1]++;
                    else
                        Battle.Replay_Info.Units.Add(new[] { this.GlobalId, 1 });

                    Battle.Attacker.Heroes_Health.Add(new Slot(GlobalId, 0));
                }
            }
            else if (this.Device.State == State.IN_1VS1_BATTLE)
            {
                var Battle = Resources.Battles_V2.GetPlayer(this.Device.Player.Avatar.Battle_ID_V2,
                    this.Device.Player.Avatar.UserId);
                Battle_Command Command =
                    new Battle_Command
                    {
                        Command_Type = this.Identifier,
                        Command_Base =
                            new Command_Base
                            {
                                Base = new Base { Tick = this.Tick },
                                Data = this.GlobalId,
                                X = this.X,
                                Y = this.Y
                            }
                    };
                Battle.Add_Command(Command);

                int Index = Battle.Replay_Info.Units.FindIndex(T => T[0] == this.GlobalId);
                if (Index > -1)
                    Battle.Replay_Info.Units[Index][1]++;
                else
                    Battle.Replay_Info.Units.Add(new[] { this.GlobalId, 1 });

                Battle.Attacker.Heroes_Health.Add(new Slot(GlobalId, 0));
            }
        }
    }
}