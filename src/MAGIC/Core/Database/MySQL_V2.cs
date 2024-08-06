﻿using ClashLand.Extensions;
using ClashLand.Logic;
using ClashLand.Logic.Enums;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ClashLand.Core.Database
{
    internal class MySQL_V2
    {
        internal static string Credentials;

        internal static JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Include,
            NullValueHandling = NullValueHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            Converters = { new Utils.ArrayReferencePreservngConverter() },
        };

        internal static List<Level> GetPlayerViaFID(List<string> ID)
        {
            const string SQL = "SELECT ID FROM player WHERE FacebookID=@FacebookID";
            List<Level> Level = new List<Level>();
            using (MySqlConnection Conn = new MySqlConnection(Credentials))
            {
                Conn.Open();
                foreach (var _ID in ID)
                {
                    using (MySqlCommand CMD = new MySqlCommand(SQL, Conn))
                    {
                        CMD.Parameters.AddWithValue("@FacebookID", _ID);
                        CMD.Prepare();
                        long UserID = Convert.ToInt64(CMD.ExecuteScalar());
                        Level User = Players.Get(UserID);
                        if (User != null)
                            Level.Add(User);
                    }
                }
            }
            return Level;
        }

        internal static void GetAllSeed()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
                {
                    Server = Utils.ParseConfigString("MysqlIPAddress"),
                    UserID = Utils.ParseConfigString("MysqlUsername"),
                    Port = (uint)Utils.ParseConfigInt("MysqlPort"),
                    Pooling = false,
                    Database = Utils.ParseConfigString("MysqlDatabase"),
                    MinimumPoolSize = 1
                };

                if (!string.IsNullOrWhiteSpace(Utils.ParseConfigString("MysqlPassword")))
                {
                    builder.Password = Utils.ParseConfigString("MysqlPassword");
                }

                Credentials = builder.ToString();

                using (MySqlConnection Conn = new MySqlConnection(Credentials))
                {
                    Conn.Open();

                    using (MySqlCommand CMD = new MySqlCommand("SELECT coalesce(MAX(ID), 0) FROM player", Conn))
                    {
                        CMD.Prepare();
                        Players.Seed = Convert.ToInt64(CMD.ExecuteScalar()) + 1;
                    }

                    using (MySqlCommand CMD = new MySqlCommand("SELECT coalesce(MAX(ID), 0) FROM clan", Conn))
                    {
                        CMD.Prepare();
                        Resources.Clans.Seed = Convert.ToInt64(CMD.ExecuteScalar()) + 1;
                    }

                    using (MySqlCommand CMD = new MySqlCommand("SELECT coalesce(MAX(ID), 0) FROM battle", Conn))
                    {
                        CMD.Prepare();
                        Resources.Battles.Seed = Convert.ToInt64(CMD.ExecuteScalar()) + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Loggers.Log("An exception occured when reconnecting to the MySQL Server.", true, Defcon.ERROR);
                Loggers.Log("Please check your database configuration!", true, Defcon.ERROR);
                Loggers.Log(ex.Message, true, Defcon.ERROR);
                Console.ReadKey();
            }
        }

        internal static long GetClanSeed()
        {
            const string SQL = "SELECT coalesce(MAX(ID), 0) FROM clan";
            long Seed = -1;

            using (MySqlConnection Conn = new MySqlConnection(Credentials))
            {
                Conn.Open();

                using (MySqlCommand CMD = new MySqlCommand(SQL, Conn))
                {
                    CMD.Prepare();
                    Seed = Convert.ToInt64(CMD.ExecuteScalar());
                }
            }

            return Seed;
        }

        internal static long GetBattleSeed()
        {
            const string SQL = "SELECT coalesce(MAX(ID), 0) FROM battle";
            long Seed = -1;

            using (MySqlConnection Conn = new MySqlConnection(Credentials))
            {
                Conn.Open();

                using (MySqlCommand CMD = new MySqlCommand(SQL, Conn))
                {
                    CMD.Prepare();
                    Seed = Convert.ToInt64(CMD.ExecuteScalar());
                }
            }

            return Seed;
        }

        internal static List<long> GetTopPlayer()
        {
            const string SQL = "SELECT ID FROM player ORDER BY TROPHIES DESC LIMIT 100";
            List<long> Seed = new List<long>(100);

            using (MySqlConnection Conn = new MySqlConnection(Credentials))
            {
                Conn.Open();

                using (MySqlCommand CMD = new MySqlCommand(SQL, Conn))
                {
                    CMD.Prepare();

                    var reader = CMD.ExecuteReader();
                    while (reader.Read())
                    {
                        Seed.Add(Convert.ToInt64(reader["ID"]));
                    }
                }
            }

            return Seed;
        }

        internal static long GetPlayerSeed()
        {
            try
            {
                const string SQL = "SELECT coalesce(MAX(ID), 0) FROM player";
                long Seed = -1;

                using (MySqlConnection Connections = new MySqlConnection(Credentials))
                {
                    Connections.Open();
                    using (MySqlCommand CMD = new MySqlCommand(SQL, Connections))
                    {
                        CMD.Prepare();
                        Seed = Convert.ToInt64(CMD.ExecuteScalar());
                    }
                }
                return Seed;
            }
            catch (Exception ex)
            {
                Loggers.Log("An exception occured when reconnecting to the MySQL Server.", true, Defcon.ERROR);
                Loggers.Log("Please check your database configuration!", true, Defcon.ERROR);
                Loggers.Log(ex.Message, true, Defcon.ERROR);
                Console.ReadKey();
            }
            return 0;
        }
    }
}