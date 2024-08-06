﻿using ClashLand.Core.Database;
using ClashLand.Extensions;
using ClashLand.Logic;
using ClashLand.Logic.Structure.Slots.Items;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;

namespace ClashLand.Core
{
    internal class Player_Region : ConcurrentDictionary<string, List_Regions>
    {
        internal readonly List<Timer> LTimers = new List<Timer>();

        internal Player_Region()
        {
            this.Fetch();
            this.Run();
        }

        internal void Run()
        {
            foreach (Timer Timer in this.LTimers)
            {
                Timer.Start();
            }
        }

        internal void Fetch()
        {
            foreach (var _Id in MySQL_V2.GetTopPlayer())
            {
                this.Add("INTERNATIONAL", Players.Get(_Id));
                //this.Add("Australia", Players.Get(_Id));
            }

            Timer Timer = new Timer
            {
                Interval = TimeSpan.FromMinutes(0.5).TotalMilliseconds,
                AutoReset = true,
            };

            Timer.Elapsed += (_Sender, _Args) =>
            {
                this.TryRemove("INTERNATIONAL");
                //this.TryRemove("Australia");
                foreach (var _Id in MySQL_V2.GetTopPlayer())
                {
                    this.Add("INTERNATIONAL", Players.Get(_Id));
                    //this.Add("Australia", Players.Get(_Id));
                }
            };

            this.LTimers.Add(Timer);
        }

        internal void Add(string Region, Level Player)
        {
            if (!string.IsNullOrEmpty(Region))
            {
                if (this.ContainsKey(Region))
                {
                    int Index = this[Region].Level.FindIndex(ds => ds.Avatar.UserId == Player.Avatar.UserId);
                    if (Index > -1)
                        this[Region].Level[Index] = Player;
                    else
                        this[Region].Level.Add(Player);
                }
                else
                {
                    this.TryAdd(Region, new List_Regions(Player));
                }
            }
        }

        internal void Add(Level Player)
        {
            if (!string.IsNullOrEmpty(Player.Avatar.Region))
            {
                if (this.ContainsKey(Player.Avatar.Region))
                {
                    int Index = this[Player.Avatar.Region].Level.FindIndex(ds => ds.Avatar.UserId == Player.Avatar.UserId);
                    if (Index > -1)
                        this[Player.Avatar.Region].Level[Index] = Player;
                    else
                        this[Player.Avatar.Region].Level.Add(Player);
                }
                else
                {
                    this.TryAdd(Player.Avatar.Region, new List_Regions(Player));
                }
            }
        }

        internal void Remove(Level Player)
        {
            if (!string.IsNullOrEmpty(Player.Avatar.Region))
            {
                if (this.ContainsKey(Player.Avatar.Region))
                {
                    this[Player.Avatar.Region].Remove(Player);
                    if (this[Player.Avatar.Region].Level.Count < 1)
                        this.TryRemove(Player.Avatar.Region);
                }
            }
        }

        internal List<Level> Get_Region(Level Player)
        {
            if (!string.IsNullOrEmpty(Player.Avatar.Region))
            {
                if (this.ContainsKey(Player.Avatar.Region))
                {
                    return this[Player.Avatar.Region].Level;
                }
                this.TryAdd(Player.Avatar.Region, new List_Regions(Player));
                return this[Player.Avatar.Region].Level;
            }
            return null;
        }

        internal List<Level> Get_Region(string region)
        {
            if (!string.IsNullOrEmpty(region))
            {
                if (this.ContainsKey(region))
                {
                    return this[region].Level;
                }
                this.TryAdd(region, new List_Regions(null));
                return this[region].Level;
            }
            return null;
        }
    }
}