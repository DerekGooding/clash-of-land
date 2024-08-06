using ClashLand.Core.Networking;
using ClashLand.Extensions.Binary;
using ClashLand.Logic;
using ClashLand.Packets.Messages.Server;

namespace ClashLand.Packets.Messages.Client
{
    internal class AskForBookmarkMessage : Message
    {
        internal int bookmarks;

        public AskForBookmarkMessage(Device Device, Reader Reader) : base(Device, Reader)
        {
            this.Identifier = 14341;
        }

        internal override void Decode()
        {
            this.bookmarks = this.Reader.ReadInt32();
        }

        public void Process(Level level)
        {
            new BookmarksListMessage(Device).Send();
        }
    }
}