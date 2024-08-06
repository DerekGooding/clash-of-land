﻿using ClashLand.Core;
using ClashLand.Extensions;
using ClashLand.Extensions.List;
using ClashLand.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashLand.Packets.Messages.Server.Leaderboard
{
    internal class League_Players : Message
    {
        internal List<Level> Players_List;

        public League_Players(Device client) : base(client)
        {
            this.Identifier = 24503;
            this.Players_List = Players.Levels.Values.Where(t => t.Avatar.League == this.Device.Player.Avatar.League).OrderByDescending(t => t.Avatar.Trophies).Take(100).ToList() ??
                           new List<Level>();
        }

        internal override void Encode()
        {
            var i = 0;

            this.Data.AddInt((int)(DateTime.UtcNow.LastDayOfMonth() - DateTime.UtcNow).TotalSeconds);
            //this.Data.AddInt(1000000);
            this.Data.AddInt(this.Players_List.Count);

            foreach (var Player in this.Players_List)
            {
                this.Data.AddLong(Player.Avatar.UserId);
                this.Data.AddString(Player.Avatar.Name);
                this.Data.AddInt(i++);
                this.Data.AddInt(Player.Avatar.Trophies);
                this.Data.AddInt(Resources.Random.Next(0, 10)); //Previous month rank
                this.Data.AddInt(Player.Avatar.Level);

                this.Data.AddInt(Player.Avatar.Wins);
                this.Data.AddInt(Player.Avatar.Loses);

                this.Data.AddInt(100);
                this.Data.AddInt(1);

                this.Data.AddInt(Player.Avatar.League);
                this.Data.AddString(Player.Avatar.Region);
                this.Data.AddLong(Player.Avatar.UserId);
                this.Data.AddInt(3);
                this.Data.AddInt(2);
                this.Data.AddBool(Player.Avatar.ClanId > 0);
                //this.Data.AddLong(Player.Avatar.ClanId);
                if (Player.Avatar.ClanId > 0)
                {
                    var _Clan = Resources.Clans.Get(Player.Avatar.ClanId);
                    this.Data.AddLong(Player.Avatar.ClanId);
                    this.Data.AddString(_Clan.Name);
                    this.Data.AddInt(_Clan.Badge);
                }
                i++;
            }
        }
    }
}