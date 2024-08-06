using ClashLand.Logic;

namespace ClashLand.Packets.Messages.Client.Battle
{
    internal class CancelDuelMatchmakeMessage : Message
    {
        public CancelDuelMatchmakeMessage(Device Device) : base(Device)
        {
            this.Identifier = 14103;
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