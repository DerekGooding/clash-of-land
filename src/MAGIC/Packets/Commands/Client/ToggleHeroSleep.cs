namespace ClashLand.Packets.Commands.Client
{
    using ClashLand.Extensions.Binary;
    using ClashLand.Logic;

    internal class ToggleHeroSleep : Command
    {
        public ToggleHeroSleep(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
        }

        internal override void Decode()
        {
            this.Debug();
        }

        internal override void Process()
        {
            base.Process();
        }
    }
}