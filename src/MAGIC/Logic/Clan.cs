﻿using ClashLand.Extensions.List;
using ClashLand.Logic.Enums;
using ClashLand.Logic.Structure.Slots;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ClashLand.Logic
{
    internal class Clan
    {
        [JsonProperty("clan_id")] internal long Clan_ID;

        [JsonProperty("r_trophi")] internal int Required_Trophies;
        [JsonProperty("BB_trophi")] internal int Required_BB_Trophies;

        [JsonProperty("origin")] internal int Origin;
        [JsonProperty("badge")] internal int Badge;

        [JsonProperty("name")] internal string Name = string.Empty;
        [JsonProperty("desc")] internal string Description = string.Empty;

        [JsonProperty("level")] internal int Level = 1;
        [JsonProperty("experience")] internal int Experience;
        [JsonProperty("hide")] internal bool Hide_From_Public;

        [JsonProperty("win")] internal int Won_War;
        [JsonProperty("lost")] internal int Lost_War;
        [JsonProperty("draw")] internal int Draw_War;

        [JsonProperty("war_frequency")] internal int War_Frequency;
        [JsonProperty("war_history")] internal bool War_History;
        [JsonProperty("war_amical")] internal bool War_Amical;

        [JsonProperty("type")] internal Hiring Type = Hiring.OPEN;

        [JsonProperty("members")] internal Members Members;
        [JsonProperty("chats")] internal Chats Chats;

        internal int Donations
        {
            get
            {
                return this.Members.Values.ToList().Sum(Member => Member.Donations);
            }
        }

        internal int BuilderTrophies
        {
            get
            {
                return this.Members.Values.ToList().Sum(Member => (Member.Player.Avatar.Builder_Trophies / 2));
            }
        }

        internal int Trophies
        {
            get
            {
                return this.Members.Values.ToList().Sum(Member => (Member.Player.Avatar.Trophies / 2));
            }
        }

        internal Clan()
        {
            this.Members = new Members(this);
            this.Chats = new Chats(this);
        }

        internal Clan(long ClanID = 0)
        {
            this.Clan_ID = ClanID;

            this.Members = new Members(this);
            this.Chats = new Chats(this);
        }

        internal byte[] ToBytes
        {
            get
            {
                List<byte> _Packet = new List<byte>();

                _Packet.AddLong(this.Clan_ID);

                _Packet.AddString(this.Name);

                _Packet.AddInt(this.Badge);
                _Packet.AddInt((int)this.Type);
                _Packet.AddInt(this.Members.Values.Count);
                _Packet.AddInt(this.Trophies);
                _Packet.AddInt(this.BuilderTrophies);

                _Packet.AddInt(this.Required_Trophies);
                _Packet.AddInt(this.Required_BB_Trophies);

                _Packet.AddInt(this.Won_War);
                _Packet.AddInt(this.Lost_War);
                _Packet.AddInt(this.Draw_War);

                _Packet.AddInt(2000001);
                _Packet.AddInt(this.War_Frequency);
                _Packet.AddInt(this.Origin);

                _Packet.AddInt(this.Experience);
                _Packet.AddInt(this.Level);

                _Packet.AddInt(0);
                _Packet.AddBool(this.War_History);
                _Packet.AddInt(0);
                _Packet.AddBool(this.War_Amical);

                return _Packet.ToArray();
            }
        }

        internal byte[] ToBytesHeader()
        {
            var Packet = new List<byte>();

            Packet.AddLong(this.Clan_ID);
            Packet.AddString(this.Name);
            Packet.AddInt(this.Badge);
            Packet.AddBool(this.Members.Count <= 1); //Founded a clan bool
            Packet.AddInt(Level);
            Packet.AddInt(1);
            Packet.AddInt(-1);

            return Packet.ToArray();
        }
    }
}