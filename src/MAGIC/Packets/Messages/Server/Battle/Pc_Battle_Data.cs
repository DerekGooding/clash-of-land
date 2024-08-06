﻿using ClashLand.Extensions;
using ClashLand.Extensions.List;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using System;

namespace ClashLand.Packets.Messages.Server.Battle
{
    internal class Pc_Battle_Data : Message
    {
        internal Level Enemy = null;
        internal Battle_Mode BattleMode;

        public Pc_Battle_Data(Device Device) : base(Device)
        {
            this.Identifier = 24107;
        }

        internal override void Encode()
        {
            this.Enemy.Tick();
            using (Objects Home = new Objects(Enemy, Enemy.JSON))
            {
                this.Data.AddInt((int)(Home.Timestamp - DateTime.UtcNow).TotalSeconds);
                this.Data.AddInt(-1);

                this.Data.AddRange(Home.ToBytes);
                this.Data.AddRange(Enemy.Avatar.ToBytes);
                this.Data.AddRange(this.Device.Player.Avatar.ToBytes);

                this.Data.AddInt((int)this.BattleMode);
                this.Data.AddInt(0);
                this.Data.Add(0);
            }
        }

        internal override void Process()
        {
            if (this.BattleMode == Battle_Mode.PVP)
            {
                this.Device.Player.Avatar.Last_Attack_Enemy_ID.Add((int)this.Enemy.Avatar.UserId);

                if (this.Device.State == State.SEARCH_BATTLE)
                {
                    if (this.Device.Player.Avatar.Last_Attack_Enemy_ID.Count > 20)
                        this.Device.Player.Avatar.Last_Attack_Enemy_ID.RemoveAt(0);
                }

                this.Device.State = State.IN_PC_BATTLE;

                if (this.Device.Player.Avatar.Battle_ID == 0)
                {
                    Core.Resources.Battles.New(this.Device.Player, Core.Players.Get(this.Device.Player.Avatar.Last_Attack_Enemy_ID[this.Device.Player.Avatar.Last_Attack_Enemy_ID.Count - 1]));
                }
                else
                {
                    Core.Resources.Battles.Save(Core.Resources.Battles.Get(this.Device.Player.Avatar.Battle_ID));
                    Core.Resources.Battles.TryRemove(this.Device.Player.Avatar.Battle_ID);

                    Core.Resources.Battles.New(this.Device.Player, Core.Players.Get(this.Device.Player.Avatar.Last_Attack_Enemy_ID[this.Device.Player.Avatar.Last_Attack_Enemy_ID.Count - 1]));
                }
            }
            else if (this.BattleMode == Battle_Mode.AMICAL)
            {
                this.Device.State = State.IN_AMICAL_BATTLE;
            }
            else if (this.BattleMode == Battle_Mode.NEXT_BUTTON_DISABLE)
            {
                this.Device.State = State.IN_PC_BATTLE;
            }
        }
    }
}