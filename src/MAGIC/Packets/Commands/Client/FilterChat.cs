using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Commands.Client
{
    internal class FilterChat : Command
    {
        public FilterChat(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }
    }
}