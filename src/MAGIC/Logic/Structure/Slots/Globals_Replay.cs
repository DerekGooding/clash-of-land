﻿using ClashLand.Logic.Structure.Slots.Items;
using Newtonsoft.Json;

namespace ClashLand.Logic.Structure.Slots
{
    internal class Globals_Replay
    {
        [JsonProperty("Village2")] internal Village_2 Village_2 = new Village_2();
        [JsonProperty("KillSwitches")] internal Kill_Switches KillSwitches = new Kill_Switches();
    }
}