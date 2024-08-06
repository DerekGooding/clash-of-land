﻿using ClashLand.Core.Database;
using ClashLand.Core.Events;
using ClashLand.Extensions;
using ClashLand.Files;
using ClashLand.Logic.Enums;
using ClashLand.Packets;
using System;

namespace ClashLand.Core
{
    internal class Classes
    {
        internal MessageFactory MFactory;
        internal CommandFactory CFactory;
        internal DebugFactory DFactory;

        internal CSV CSV;
        internal Home Home;
        internal NPC Npc;
        internal Game_Events Game_Events;
        internal Timers Timers;
        internal Redis Redis;
        internal Fingerprint Fingerprint;
        internal EventsHandler Events;
        internal Test Test;

        internal Classes()
        {
            this.MFactory = new MessageFactory();
            this.CFactory = new CommandFactory();
            this.DFactory = new DebugFactory();
            Loggers.Initialize();
            Fingerprint = new Fingerprint();
            this.CSV = new CSV();
            this.Home = new Home();
            this.Npc = new NPC();
            this.Game_Events = new Game_Events();
            this.Fingerprint = new Fingerprint();
            switch (Constants.Database)
            {
                case DBMS.Redis:
                case DBMS.Both:
                    this.Redis = new Redis();
                    break;
            }

            this.Events = new EventsHandler();
#if DEBUG
            Console.WriteLine("We loaded " + MessageFactory.Messages.Count + " messages, " + CommandFactory.Commands.Count + " commands, and " + DebugFactory.Debugs.Count + " debug commands.\n");
#endif
            this.Timers = new Timers();

            this.Test = new Test();

            MySQL_V2.GetAllSeed();
        }
    }
}