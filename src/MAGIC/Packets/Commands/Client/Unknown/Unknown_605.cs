﻿namespace ClashLand.Packets.Commands.Client.Unknown
{
    using ClashLand.Extensions.Binary;
    using ClashLand.Logic;

    internal class Unknown_605 : Command
    {
        public Unknown_605(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
        }

        /*internal override int Type
        {
            get
            {
                return 605;
            }
        }*/
        public int Tick { get; private set; }

        internal override void Decode()
        {
        }
    }
}