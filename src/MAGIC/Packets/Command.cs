﻿using ClashLand.Extensions;
using ClashLand.Extensions.Binary;
using ClashLand.Logic;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ClashLand.Packets
{
    internal class Command
    {
        internal const int MaxEmbeddedDepth = 10;

        internal int Identifier;

        internal int SubTick1;
        internal int SubTick2;

        internal int SubHighID;
        internal int SubLowID;

        internal Reader Reader;
        internal Device Device;

        internal List<byte> Data;
        public int Id { get; set; }

        internal Command(Device Device)
        {
            this.Device = Device;
            this.Data = new List<byte>();
        }

        internal Command(Reader Reader, Device Device, int Identifier)
        {
            this.Identifier = Identifier;
            this.Device = Device;
            this.Reader = Reader;
        }

        internal virtual void Decode()
        {
            // Decode.
        }

        internal virtual void Encode()
        {
            // Encode.
        }

        internal virtual void Process()
        {
            // Process.
        }

        internal void Debug()
        {
            Console.WriteLine(Utils.Padding(this.GetType().Name, 15) + " : " + BitConverter.ToString(this.Reader.ReadBytes((int)(this.Reader.BaseStream.Length - this.Reader.BaseStream.Position))));
        }

        internal void ShowValues()
        {
            //Console.WriteLine(Environment.NewLine);

            foreach (FieldInfo Field in this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (Field != null)
                {
                    Console.WriteLine(Utils.Padding(this.GetType().Name) + " - " + Utils.Padding(Field.Name) + " : " + Utils.Padding(!string.IsNullOrEmpty(Field.Name) ? (Field.GetValue(this) != null ? Field.GetValue(this).ToString() : "(null)") : "(null)", 40));
                }
            }
        }
    }
}