﻿using ClashLand.Core.Networking;
using ClashLand.Extensions.Binary;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using ClashLand.Packets.Messages.Server.Battle;

namespace ClashLand.Packets.Commands.Client.Battle
{
    internal class Search_Opponent : Command
    {
        internal long Enemy_ID;
        internal bool Max_Seed_Achieved;
        internal Level Enemy_Player;
        private object p;

        public Search_Opponent(Device Device, object p) : base(Device)
        {
            this.p = p;
        }

        public Search_Opponent(Reader _Reader, Device _Client, int _ID) : base(_Reader, _Client, _ID)
        {
        }

        internal override void Decode()
        {
            this.Reader.ReadInt32();
            this.Reader.ReadInt32();
            base.Decode();
            //this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            if (this.Device.State == Logic.Enums.State.LOGGED)
            {
                this.Device.Player.Tick();
            }

            if (!this.Device.Player.Avatar.Modes.IsAttackingOwnBase)
            {
                this.Device.State = Logic.Enums.State.SEARCH_BATTLE;
                if (this.Device.Player.Avatar.Last_Attack_Enemy_ID.Count > 20 ||
                    this.Device.Player.Avatar.Last_Attack_Enemy_ID.Count == (Core.Players.Seed - 2))
                {
                    if (this.Device.Player.Avatar.Last_Attack_Enemy_ID.Count != 0)
                    {
                        this.Device.Player.Avatar.Last_Attack_Enemy_ID.RemoveAt(0);
                    }
                }
                while (this.Enemy_Player == null && this.Device.Player.Avatar.Last_Attack_Enemy_ID.Count <
                       Core.Players.Seed - 2)
                {
                    if (this.Enemy_ID != this.Device.Player.Avatar.UserId && this.Enemy_ID > 0)
                    {
                        if (this.Device.Player.Avatar.Last_Attack_Enemy_ID.FindIndex(P => P == this.Enemy_ID) < 0)
                        {
                            this.Enemy_Player = Core.Players.Get(this.Enemy_ID, false);

                            if (this.Enemy_Player == null)
                            {
                                this.Device.Player.Avatar.Last_Attack_Enemy_ID.Add(Enemy_ID);

                                if (this.Device.Player.Avatar.Last_Attack_Enemy_ID.Count > 20 ||
                                    this.Device.Player.Avatar.Last_Attack_Enemy_ID.Count >
                                    Core.Players.Seed - 2)
                                    this.Device.Player.Avatar.Last_Attack_Enemy_ID.RemoveAt(0);
                            }
                        }
                        else
                        {
                            if (this.Enemy_ID < Core.Players.Seed - 1 && !this.Max_Seed_Achieved)
                            {
                                this.Enemy_ID++;
                            }
                            else
                            {
                                if (this.Enemy_ID < 1) break;
                                this.Enemy_ID--;
                                this.Max_Seed_Achieved = true;
                            }
                        }
                    }
                    else
                    {
                        if (this.Enemy_ID < Core.Players.Seed - 1 && !this.Max_Seed_Achieved)
                        {
                            this.Enemy_ID++;
                        }
                        else
                        {
                            if (this.Enemy_ID < 1)
                            {
                                break;
                            }
                            this.Enemy_ID--;
                            this.Max_Seed_Achieved = true;
                        }
                    }
                }

                if (this.Enemy_Player != null)
                    new Pc_Battle_Data(this.Device) { Enemy = this.Enemy_Player, BattleMode = Battle_Mode.PVP }.Send();
                else
                    new Battle_Failed(this.Device).Send();
            }
            else
            {
                new Pc_Battle_Data(this.Device) { Enemy = this.Device.Player, BattleMode = Battle_Mode.NEXT_BUTTON_DISABLE }.Send();
            }
        }
    }
}