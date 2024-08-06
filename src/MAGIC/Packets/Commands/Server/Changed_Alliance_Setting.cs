using ClashLand.Extensions.List;
using ClashLand.Logic;

namespace ClashLand.Packets.Commands.Server
{
    internal class Changed_Alliance_Setting : Command
    {
        internal Clan Clan;

        public Changed_Alliance_Setting(Device client) : base(client)
        {
            this.Identifier = 6;
        }

        internal override void Encode()
        {
            this.Data.AddLong(this.Clan.Clan_ID);
            this.Data.AddInt(this.Clan.Badge);
            this.Data.AddInt(this.Clan.Level);
            this.Data.AddInt(-1);
        }
    }
}