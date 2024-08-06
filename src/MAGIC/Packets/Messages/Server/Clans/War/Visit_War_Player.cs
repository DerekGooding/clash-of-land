﻿using ClashLand.Extensions.List;
using ClashLand.Logic;
using System;

namespace ClashLand.Packets.Messages.Server.Clans.War
{
    internal class Visit_War_Player : Message
    {
        internal Level Avatar;

        public Visit_War_Player(Device Device) : base(Device)
        {
            this.Identifier = 25000;
        }

        internal override void Encode()
        {
            using (Objects Home = new Objects(Avatar = this.Device.Player, Avatar.JSON))
            {
                this.Data.AddInt((int)(Home.Timestamp - DateTime.UtcNow).TotalSeconds);
                this.Data.AddInt(-1);

                this.Data.AddRange(Home.ToBytes);
            }
            this.Data.AddHexa("00000000010000000D002197300000000D0021973001000000210039C8C50000000E547572656C277320546872616C6C5B00255200000001000000050000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000190000000000000001000000000000000900000008496E66696E6974650000000F3130303030313233303435323734340000006600000B1F0000000200000002000004B00000003C0000082E0000000000000000000000000000000000000000000000000000000000000000010000015202E8A8A0030000000100001AF4000000000000000100000000000000000000000006002DC6C10081B320002DC6C20081B320002DC6C300027100002DC6C400249F00002DC6C500249F00002DC6C600002EE000000006002DC6C100061CF7002DC6C20005E4E9002DC6C300000322002DC6C400000000002DC6C500000000002DC6C6000000000000000F003D09000000001A003D090100000000003D090200000000003D090300000001003D090400000001003D090500000000003D090600000001003D090700000000003D090800000000003D090900000000003D090A00000000003D090B00000000003D090C00000000003D090D00000000003D090F0000000000000006018CBA8000000001018CBA8100000001018CBA8200000001018CBA8300000001018CBA8500000001018CBA89000000010000000C003D090000000005003D090100000005003D090200000004003D090300000005003D090400000004003D090500000004003D090600000004003D090700000002003D090800000002003D090900000001003D090A00000002003D090B0000000300000003018CBA8000000003018CBA8100000004018CBA82000000040000000201AB3F000000000A01AB3F01000000080000000201AB3F000000000001AB3F01000000000000000201AB3F000000000301AB3F010000000300000048003D09000000000000000000003D09000000000000000001003D09000000000000000002003D09000000000000000003003D09000000000000000004003D09000000000000000005003D09000000000000000006003D09010000000000000000003D09010000000000000001003D09010000000000000002003D09010000000000000003003D09010000000000000004003D09010000000000000005003D09010000000000000006003D09020000000000000000003D09020000000000000001003D09020000000000000002003D09020000000000000003003D09020000000000000004003D09030000000000000000003D09030000000000000001003D09030000000000000002003D09030000000000000003003D09030000000000000004003D09030000000000000005003D09030000000000000006003D09040000000000000000003D09040000000000000001003D09040000000000000002003D09040000000000000003003D09040000000000000004003D09050000000000000000003D09050000000000000001003D09050000000000000002003D09050000000000000003003D09050000000000000004003D09050000000000000005003D09060000000000000000003D09060000000000000001003D09060000000000000002003D09060000000000000003003D09060000000000000004003D09060000000000000005003D09070000000000000000003D09070000000000000001003D09070000000000000002003D09080000000000000000003D09080000000000000001003D09080000000000000002003D09080000000000000003003D09080000000000000004003D09090000000000000000003D09090000000000000001003D09090000000000000002003D09090000000000000003003D09090000000000000004003D090A0000000000000000003D090A0000000000000001003D090A0000000000000002003D090A0000000000000003003D090A0000000000000004003D090A0000000000000005003D090B0000000000000000003D090B0000000000000001003D090B0000000000000002003D090B0000000000000003003D090B0000000000000004003D090C0000000000000000003D090F0000000000000000003D090F0000000000000001018CBA890000000000000001018CBA8900000000000000020000001001406F4001406F4101406F4201406F4301406F4401406F4501406F4601406F4701406F4801406F4901406F4A01406F4B01406F4C01406F4D01406F4E01406F4F00000036015EF3C0015EF3C1015EF3C2015EF3C3015EF3C4015EF3C5015EF3C6015EF3C7015EF3C8015EF3C9015EF3CA015EF3CB015EF3CC015EF3CD015EF3CE015EF3CF015EF3D0015EF3D1015EF3D2015EF3D3015EF3D4015EF3D5015EF3D6015EF3D7015EF3D8015EF3D9015EF3DA015EF3DB015EF3DC015EF3DD015EF3DE015EF3DF015EF3E1015EF3E2015EF3E3015EF3E4015EF3E5015EF3E7015EF3E8015EF3EA015EF3EB015EF3EC015EF3ED015EF3EE015EF3F0015EF3F1015EF3F3015EF3F4015EF3F6015EF3F7015EF3F9015EF3FC015EF3FD015EF3FF00000048015EF3C00000000B015EF3C10000000B015EF3C20000000B015EF3C300000096015EF3C400000096015EF3C500000096015EF3C60000000A015EF3C70000000A015EF3C80000000A015EF3C900000561015EF3CA00000561015EF3CB00000561015EF3CC00000001015EF3CD00000001015EF3CE00000001015EF3CF1380930F015EF3D01380930F015EF3D11380930F015EF3D2165F946D015EF3D3165F946D015EF3D4165F946D015EF3D500000B79015EF3D600000B79015EF3D700000B79015EF3D800000004015EF3D900000004015EF3DA00000004015EF3DB000055D7015EF3DC000055D7015EF3DD000055D7015EF3DE0000066D015EF3DF0000066D015EF3E00000066D015EF3E100001B7F015EF3E200001B7F015EF3E300001B7F015EF3E4000009D3015EF3E5000009D3015EF3E6000009D3015EF3E7000004F4015EF3E8000004F4015EF3E9000004F4015EF3EA0000A2F9015EF3EB0000A2F9015EF3EC0000A2F9015EF3ED00000D02015EF3EE00000D02015EF3EF00000D02015EF3F0000F29D9015EF3F1000F29D9015EF3F2000F29D9015EF3F30000000E015EF3F40000000E015EF3F50000000E015EF3F600000210015EF3F700000210015EF3F800000210015EF3F90000006B015EF3FA0000006B015EF3FB0000006B015EF3FC000000EC015EF3FD000000EC015EF3FE000000EC015EF3FF00DE17F2015EF40000DE17F2015EF40100DE17F2015EF40200000001015EF40300000001015EF40400000001015EF40500000003015EF40600000003015EF407000000030000003201036640000000030103664100000003010366420000000301036643000000030103664400000003010366450000000301036646000000030103664700000003010366480000000301036649000000030103664A000000030103664B000000030103664C000000030103664D000000030103664E000000030103664F0000000301036650000000030103665100000003010366520000000301036653000000030103665400000003010366550000000301036656000000030103665700000003010366580000000301036659000000030103665A000000030103665B000000030103665C000000030103665D000000030103665E000000030103665F0000000301036660000000030103666100000003010366620000000301036663000000030103666400000003010366650000000301036666000000030103666700000003010366680000000301036669000000030103666A000000030103666B000000030103666C000000030103666D000000030103666E000000030103666F00000003010366700000000301036671000000030000003201036640000001F401036641000001F401036642000001F401036643000003E801036644000003E801036645000003E801036646000007D001036647000007D001036648000007D00103664900000BB80103664A00000BB80103664B00000BB80103664C00000FA00103664D00000FA00103664E00000FA00103664F00001388010366500000138801036651000013880103665200001770010366530000177001036654000017700103665500001B580103665600001B580103665700002710010366580000271001036659000027100103665A00003A980103665B00003A980103665C00003A980103665D00004E200103665E00004E200103665F00004E20010366600000753001036661000075300103666200007530010366630000C35001036664000186A001036665000186A001036666000186A001036667000249F001036668000249F001036669000249F00103666A00030D400103666B0003D0900103666C000493E00103666D00061A800103666E0007A1200103666F000927C001036670000AAE6001036671000C35000000003201036640000001F401036641000001F401036642000001F401036643000003E801036644000003E801036645000003E801036646000007D001036647000007D001036648000007D00103664900000BB80103664A00000BB80103664B00000BB80103664C00000FA00103664D00000FA00103664E00000FA00103664F00001388010366500000138801036651000013880103665200001770010366530000177001036654000017700103665500001B580103665600001B580103665700002710010366580000271001036659000027100103665A00003A980103665B00003A980103665C00003A980103665D00004E200103665E00004E200103665F00004E20010366600000753001036661000075300103666200007530010366630000C35001036664000186A00103666500041EB001036666000186A001036667000249F001036668000249F001036669000249F00103666A00030D400103666B0003D0900103666C000493E00103666D00061A800103666E0007A1200103666F000927C001036670000AAE6001036671000C35000000000000000000000000000000000502349340000000030234934200000000023493450000000102349346000000010234934758B181780000000B003D090000000001003D090100000002003D090300000001003D090400000001003D090600000001003D090700000002003D090800000002003D090900000001003D090A00000001003D090B00000001003D090D00000001000000000000000000000008003D09000000001D003D090100000000003D090300000001003D090400000001003D090600000001003D090800000000003D090D00000000018CBA89000000000000000E003D0903000A0000003D0905000A0000003D0906000C0000003D090700030000003D090800020000003D090900020000003D090A00180000003D090B000A0000003D090C00060000003D090D00020000003D090F00040000003D091700050000003D0918000A0000003D091E000C0000");
            //this.Data.AddHexa("59 16 48 FE 00 00 00 37 00 90 33 68 00 00 00 37 00 90 33 68 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 0D BE 64 65 00 00 78 9C D5 5D 4B 6F E4 38 0E FE 2B 83 3A E7 60 51 EF DC E7 32 D8 C5 02 73 5D 2C 0A D5 89 37 09 B6 F2 40 A5 92 EE C6 60 FE FB DA 65 49 31 69 DA 64 1D BB 0F D3 53 B2 3F 4A A6 3E 51 7C C8 EE BF 76 FD 8F B7 FD 67 7F DA DD 9A 9B DD B7 8F A7 E3 FD D3 CB C3 FB EE F6 DF 7F ED EE 0F E7 C3 D0 DC 8D 7F 86 8B 4F F7 BB 5B DF 95 3F 37 BB E3 E7 71 BC 78 B3 FB B1 BB 05 7B B3 FB 39 FE F5 F7 0D 86 39 0C 33 05 96 2F 28 37 81 02 05 75 18 04 05 14 2E A0 B1 C7 01 E5 3A 82 32 1E A3 6C 41 4D 03 34 70 41 99 48 51 64 80 AE A0 DC 84 8A 3C AA 4B 18 E5 B1 36 4C B8 C0 6C 12 86 18 D8 21 66 DA 19 60 54 44 3A B4 66 52 07 05 59 0C 4A 64 84 69 1A E1 02 46 46 98 09 6C 9A 31 BB 98 E6 80 60 A6 B2 63 E8 E5 F1 6D 98 38 7F 99 D3 53 FF B0 BB FD EF E1 F8 DE 4F B3 3F 71 C6 2C A6 1F 4F 89 31 58 58 04 4E 98 9F 64 99 6D DD 99 4A A5 58 06 96 D8 81 4D 0C 5B 50 05 D3 D2 D8 2F 59 E3 3C 94 15 40 67 8F A2 1C 8B 5A 30 85 A0 3C 42 41 E6 A7 81 A2 02 46 25 1D 2A 22 54 D6 3D 56 C2 5D 19 9E 5E 14 95 11 AA B0 4B 52 06 74 B8 AF C8 4F 3D 45 19 AC F8 4E A5 0C 00 6E BA EC C2 F6 10 14 4B 0D 2B 8D D0 71 D3 B5 30 07 14 E5 59 6D 48 A8 80 17 82 BD B4 2E 56 42 D1 12 48 23 8F 57 49 03 41 5A C2 F6 3E 6A 56 23 64 0E 24 30 C9 76 1C 48 50 9D C5 44 32 65 81 08 E3 B3 64 13 5B B1 7D 14 65 D9 BE A4 C7 72 EC 62 14 48 6B 09 91 40 87 0A F8 B9 60 C5 A6 E3 0D C2 CE F6 B0 8B 4D B7 1C 5F CA 06 B1 F0 0F E8 10 08 5F CC CA 10 32 46 91 AD 2D AD F8 22 78 A7 77 C4 EF C9 FC CA 26 1E 8C 33 68 84 D3 5E 65 FD F6 63 39 62 7A 40 65 B0 9C C5 CA E8 54 3C 73 EC AE 64 85 85 EA 3C EA 2B EB BA 0A 1C 48 D2 45 64 B9 29 AC 54 97 B8 AE 84 3D C9 65 0E 24 68 DD E3 2D A9 F8 64 D2 5C 79 C3 75 25 28 DD 13 5A 4C 64 72 12 6A 46 8B 71 C1 81 EF B8 15 97 55 5B A9 C7 6C C9 2B 9E 35 01 61 F3 92 74 20 EC C1 AC 78 E3 14 14 39 B5 0A 76 CC 73 5C 11 F8 E5 33 B7 D6 04 50 E8 B8 47 12 2C 7A 30 9C 89 93 7A 02 CE 34 4B 20 CB 0D 4F 02 39 6E 73 93 40 9E E9 09 84 69 0A 1C 21 16 EE 09 89 62 42 C4 46 BB 68 62 09 C3 C1 42 A8 94 48 68 CB A6 23 24 91 56 98 EF 2B 97 A5 66 D8 A5 06 2B 96 85 44 3F 91 84 52 7C F4 53 9E 68 61 DA F0 D0 A2 C1 46 20 F2 03 F3 BC 1D 1A E3 CE B9 30 6C 87 5C 09 43 05 9D C6 4A AF BA F1 B3 01 18 F0 8F 43 55 E3 54 AA 89 BC 2C EC 0D 44 1A C1 17 0B 2E F8 31 31 10 D8 14 F8 3B 61 8F 89 91 63 B1 60 C2 63 E2 40 C2 16 13 33 07 12 86 97 38 13 05 C2 16 9D 0C 07 12 9C 81 04 1C 48 B0 EF 89 33 51 92 4F 9C 1C 07 12 4C 54 E2 4C 94 E4 11 27 CE 44 49 B1 5F E2 18 21 F9 5F 89 63 84 E4 74 24 CC 08 5D 4E 20 77 C8 14 82 8E 47 D9 70 5D 49 20 4C 89 AC 03 91 38 A9 D3 A1 C8 B6 E5 34 DB 56 C6 4E AF F1 2A 10 89 92 82 0A 14 39 90 E4 C8 E4 C4 A2 04 FE E5 CC 2A 70 7B CD 9B AE 63 51 DB 8B DE 74 86 1D E1 82 EC 80 51 95 17 7E B2 F6 A6 63 93 8A 25 D8 5D EE 5E 64 0C C4 1F 76 1D 27 AC 38 D7 92 16 1C FB 3C DB 4B CA 74 9E 45 6D 53 D6 74 2C 91 84 F0 C9 74 3C 93 A4 79 4A 1C D3 45 14 CF A4 6D 9B 6E 5A C6 18 2D 45 A9 2F 63 D8 BE B6 B7 02 63 80 45 6D AF 46 63 70 60 0D 4E 63 62 8C C1 DC 28 BE 95 88 C2 DC 80 A0 43 61 6E 14 23 2D A2 22 8B 12 D8 6B 12 8B DA DE B0 8C C9 2C 6A DB 36 19 92 EF AD AE 99 30 5F 40 9C DD 95 88 17 54 9B BA 01 60 67 44 42 91 6D 49 95 B6 30 24 0F 5C E2 0E 11 85 7D 95 5A A9 91 50 D8 59 29 6B 5C 44 45 0E B5 AC C8 11 54 62 51 8B 88 21 63 14 C9 D3 C1 4A 67 38 51 67 5A 6A B7 C2 F2 0A 0C EF 32 76 56 A0 DC 88 4F 56 62 0A 87 65 C1 97 AC 1F AD D8 49 1F 17 B0 92 5A C6 D7 96 0A 15 CB DA 9A 19 5D AC 1C 83 85 39 BC 06 0C F0 6B 00 D8 64 39 55 4D 25 58 42 99 C5 ED F8 D5 B4 FC F0 A6 42 D7 CC BD C5 B2 B0 A9 4A 9A D4 89 B1 84 75 81 67 1D 45 65 16 25 D8 37 D7 B1 28 C1 96 3A B2 8B 45 1D 0A D8 9D 45 58 83 8E 58 A4 A4 EB 8B 58 A4 AC 43 91 82 42 A7 43 91 A2 A5 D1 A1 D8 04 B1 88 22 55 4B AB 43 61 6E 14 4F 40 42 91 14 71 35 63 12 0A 73 03 74 8C F2 84 1B 4E C5 0D 8F B9 01 3A 1E 92 64 30 E8 18 E5 D9 82 B6 88 C2 DC B0 3A 46 79 CC 0D AB 63 94 C7 DC B0 3A 46 F9 CC A2 04 BB 41 72 C2 E5 FC 81 E4 4D 05 CC 8D 92 81 13 51 24 6F 07 2B 28 BC 93 04 E2 FD 76 FC 6E 0A 78 13 6E 79 E1 E1 F6 C3 D3 F3 FE F0 F2 70 EC F1 AF FD F7 C3 09 B7 00 FE 69 F1 4F 87 7F 7A F2 73 7F F7 78 20 FD ED 0F A7 D3 F7 76 C6 C6 F3 29 26 9C D7 33 2D 37 AD A9 4F 0A D5 3F 13 02 DE 85 F9 58 B3 4C FA 32 BC C7 7B 60 C0 7B 60 AD ED 0A 01 60 48 EC A4 0B 9B 60 98 91 79 A3 AC 5F A5 09 E6 25 76 D7 48 13 52 73 26 1A EE 89 84 2C A0 89 C4 30 AA 8E 73 98 68 59 94 A0 BD E8 D8 11 0A 81 70 F4 57 69 49 08 90 63 B8 4A 9A C0 A2 79 DA 5A 21 4D 08 3C 23 CB 49 21 A1 6D E2 55 9C 14 72 EA 26 5D C7 49 61 C6 E7 29 70 85 34 81 75 89 35 D4 42 29 CE 90 E4 78 45 09 EB 22 B1 5C 15 0A AD 86 A4 C7 2B 4A E0 64 52 72 72 E5 18 07 95 A6 E4 A4 51 25 CA E6 19 F5 2D 69 9D 4E 9A 8E AB 56 75 06 C2 E4 0E BB 16 AA E3 0C 26 EB 38 69 57 AA 91 54 1A 5C 25 4D 58 7D F3 AC BD 42 9A B0 FA B2 63 F5 23 AC B2 AC B3 B7 36 E9 A4 29 8F D5 45 9D 34 1D B7 AD AA 30 60 32 71 68 BD 0E 45 1C 5A A7 41 01 29 0C 14 D4 B6 11 82 CE 70 A0 6D 7B 07 9D 92 91 56 35 02 25 21 F9 7C 09 15 46 F8 38 81 B6 4D 2A 74 D8 A4 96 58 45 02 B1 61 91 04 22 11 73 56 81 74 F6 B1 04 81 92 30 9D 79 2C 71 A8 20 CC 60 C6 95 40 59 02 91 E8 DA AB 40 3A C6 95 A0 5B 12 A6 63 5C 71 39 25 61 24 14 57 31 8E 1E 2D 57 31 8E 96 1A 54 E7 05 81 9C 2C 07 9E A7 38 91 0B AD D2 30 0A 9B 0A 7F 81 5D 94 89 F7 17 70 3A 19 4C 26 E2 52 66 A5 AD 94 4D C9 E0 5A 69 42 1A DC DA 29 7A C0 E2 2A 1F FD BC 5E B0 70 CB C1 61 14 49 19 03 9F 33 AE 27 DE 17 D2 02 96 86 6B 4F 35 5B 42 DD 0C 20 23 27 AF B2 AC BC 0C 01 16 A3 2A 21 60 1A 79 66 4F F0 D4 30 7B E1 1F 91 21 64 A4 BC 5A A2 A1 28 7C 5C 0B 2C 9D C1 95 E3 5A 65 37 5A D4 31 F1 51 33 68 F5 03 49 9C E5 BD 37 C2 D6 56 42 10 D8 1A 35 45 56 98 97 03 66 AB 76 DB E7 03 72 2E DC A8 36 0A 8B B7 24 A3 DA 10 48 7E BF 8E 6F DB C3 05 CB 27 EA B6 BD 45 B0 7C A2 4E F0 6B 68 82 5F 55 C0 84 96 E0 4F B3 04 10 63 E4 83 26 43 00 E4 5C 78 1D 83 60 7B F9 C4 BF 88 62 13 FF 22 8A 4D FC 8B A8 C0 A2 24 DD B2 7B 8A 90 D1 01 9A F8 EF 34 39 27 20 89 7F B3 66 D4 31 AA 25 FE B7 0B D1 55 9A C0 76 CF 16 8B A4 E7 25 87 C6 CB EC 8B 23 B7 5C 5F 22 6A C6 19 39 6A 91 AC 8F 57 C6 67 AA 63 0B 40 0B 08 AA D3 6F 40 0B 08 AA B7 EF A0 15 10 D2 DC B9 94 56 77 2B 20 A4 B9 17 29 A1 56 0A 08 C2 08 69 01 A1 53 D9 5B 5A 40 58 71 2B 28 CA B2 A8 ED EC 0E 04 C7 A2 24 6D 78 16 25 C4 6B E4 68 79 45 09 6C 0F 91 43 49 FB 08 C9 C7 DB 95 C3 09 14 95 39 F6 4A A8 88 B9 51 56 8A 88 22 C1 78 D0 A1 F8 97 53 24 14 79 5D D2 E9 50 24 BE B6 3A 94 E7 50 D2 2C C7 C0 A2 04 46 91 63 DE 15 25 B0 97 E4 C5 2B 4A 58 29 E4 A0 B7 5D F3 99 31 8A 9C F4 B6 3A 8F 4B 99 E7 2E B3 2F 59 21 92 E7 AE 8E B6 84 22 C5 EA B5 7A 08 F6 F6 5B 9E 7B F3 0D 88 32 F0 65 39 C4 60 61 1E 0B 5B 39 5D 53 1F 68 11 41 61 57 BF 25 B2 61 1E 87 2F E3 2E F2 40 09 A1 EA F7 0A A8 F2 48 8C D7 12 D3 76 EE 78 2E DF 5A C0 B1 4D 4B 40 97 18 CF AD 14 24 08 CA 7C A1 9A FB B3 50 12 9F E3 01 AC F0 96 7D 1E FE 3E 9C CF 87 BB FF ED 9F 5F EF FB DD ED F9 F4 D1 A3 A6 A9 AA BC 68 06 A6 CD 32 6D 8E 69 F3 5C 37 53 B5 79 D9 3E 95 9C 4B FB F3 F3 EB 38 25 A3 22 2E 0A B0 2C 4D CA 61 A1 45 FD 0B 88 3A F1 67 2D EC CA B1 1F 12 E5 B6 DC B8 14 96 46 9E AB 24 CA 6D 49 73 5D D0 BC A8 3E 91 28 B7 65 CD 85 28 37 6B AA 94 30 3F 36 AF F0 B7 25 69 E4 10 74 D6 D4 5D A1 65 CD 03 F2 B7 B7 51 B6 65 CD D1 EB E8 22 8A 3D 4E 2F A2 C8 CB 81 5E 87 AA EC 4B F3 08 5D F0 4E 2D C9 84 C3 4A 5A 8B A2 D8 F7 D1 85 F8 C8 D2 03 F2 6B A6 9C A0 22 8B 92 FA 62 0F C8 0B 15 6C 4B 0E C8 D7 E7 12 50 24 BF 6D 55 B9 1B 4B 13 DC 51 53 15 B7 E4 80 7C 9D 65 09 45 5E ED F3 FC BA AB 63 10 38 43 73 D9 4E 37 06 C2 19 AF 43 91 CC 43 D0 A1 22 AB 5B 81 69 F4 43 29 BA 35 6E 48 54 A8 3A 4B 62 5B 76 1A BF B5 25 70 06 0C DB D7 F6 EB 39 B6 1D 90 DF 7E 3D A7 BA 56 DB 07 97 6D 4B 69 17 69 79 33 AB BE 38 85 46 84 B9 5F D9 6D E8 F2 A6 DB 50 F2 F3 0B 53 65 C9 F4 78 EC 36 94 20 70 E1 6C 24 8C 8A 5F A8 D9 F9 BD 31 BF 47 0E F0 A1 26 20 BF 2D F9 ED C8 6F 4F 7F 17 05 E1 7E 26 E5 B8 C2 88 C8 D2 AB 7E FD 66 91 F4 77 F8 B9 12 D2 86 E3 33 8D 1D 51 61 46 A0 C8 A7 99 71 81 C8 B6 F2 42 A9 70 78 B6 C2 61 F9 F7 F9 C7 A7 99 CB 9A 79 D2 88 C7 45 D0 82 C8 CB 76 E0 1A 2D D7 E8 B8 46 CF F6 35 4D 16 73 61 9A B1 7A E1 C2 E7 1C 00 E5 9F 17 7E 6B C6 8F 5C AD 4A 29 6D AD 6C 29 81 AD C7 53 F5 D9 5F 5F 7D C9 17 6B 60 78 4D 94 1A 9F 70 DC CB B6 42 50 51 6B 66 85 55 5F 57 D8 2F 5A 7D 48 25 4C D8 54 5B DD 68 5B 58 D2 09 8B 2A 61 3A A7 A8 95 99 2C 72 B3 25 14 8E B4 8D CE 21 69 65 A6 62 EC 2E 89 05 86 F7 AA 23 81 B6 95 9F 5C E1 0E 7F 00 B9 4A 13 B8 D3 CA 4F 0E A1 04 57 A4 95 9F 30 4A 70 7B 5A F9 C9 23 94 E0 62 B5 F2 93 9F BB AF 22 2A E8 74 EE 74 D2 A2 4E 9A D7 49 4B 3A 69 AA B7 81 AD CB 57 49 13 E6 C8 2B B9 1A 54 3C F1 F8 04 44 45 09 9C F4 C0 A2 84 75 E1 09 27 BD 0E E5 74 AB C9 EA A4 79 9D B4 B5 5C 1B 91 16 54 D2 AA CF B8 9D 2A B7 5E C7 61 AB B3 00 AD 1C 26 8C 6D C5 0A 59 22 0D 3B 63 F5 DB 3C 74 AB B2 38 12 68 65 B2 AE 6E A8 20 94 E4 CB 46 23 F0 2F E8 2C AC D5 D9 EB 00 D7 E8 5D 9A C5 60 AF E1 84 34 8B 41 C7 FE EA 87 48 D2 BC CE 76 A8 BE 30 66 83 8E FD 55 9A 34 A7 11 5B 87 AC 9B BB 84 50 F5 8B 97 D2 1C 91 A3 4B 2B 71 2D 41 B5 C2 9E 45 AB 5A D0 52 2B EC 59 C4 22 09 05 18 A5 4B FC B5 C2 9E 9D A7 83 45 94 CA 3B AD C2 84 ED 29 AA BC D3 2A 4C D8 39 A3 CA 3B AD C2 84 EC 61 8C AC 72 04 6F 3B 26 D5 10 56 3E C7 4D 85 65 95 30 5D 86 32 75 2A 61 46 27 CC A8 84 75 3A 61 70 8D 30 61 DA 92 BD 46 98 40 A8 A4 A3 7A A7 5A 37 C9 63 42 75 FC 02 21 21 76 0A 08 65 8A E5 DE FE BC 82 9D 57 2B D7 F3 1A 25 4E 5B 04 E6 78 57 4E B3 6C CC 2F 97 9F BB BC 93 BC 11 91 D7 77 AF 85 84 67 C2 FE CC 4A 7C 4B 14 37 2F C8 FE 72 8A BB 38 84 5B 8A 5B F9 42 32 49 6C D2 F2 F2 CA A7 E6 A1 1E D8 F8 CF CD EE BE BF 7B 1D FF 7D 83 E1 7F 0F 9F 83 E0 D3 FE E9 7E FF F8 F4 F0 38 D6 2C E6 6D C7 D7 61 D0 D9 F9 29 10 7D 39 3C 0F AA DD FD FE 8F DF FE F9 FB 1F FF FA 73 37 DC 79 3C 3E 1D 5E EE FA 7D B9 F4 67 7F 38 FE F6 C7 C7 67 FF 72 FE B8 1F AE FF 78 DB 1F FB CF FE 52 D8 8C B3 DB 5B 77 E3 7E 32 6F BD 74 E8 AD B9 E4 2B BF 1D EE 1F C6 D6 51 07 A1 CB 2E 5F 32 58 ED F6 FE 4B 7A 9E 35 7F BC 3C 9D F7 9F 4F EF C3 7F EF 0E 6F 87 BB A7 F3 CF C9 14 E0 3B DE DF FA E3 71 71 DF C8 A7 FE F0 F0 D1 EF CF 3F DF FA C9 AD 3E F5 EF AF 1F A7 BB 7E FA 17 21 C6 E1 4C C7 3D 86 7B EF 5E CE 03 66 9C 9F AF 66 53 9A F3 78 B4 02 5F 82 F5 4B B6 5C F2 96 5C 70 7C 2F 9E 6F 0E AD 79 98 DB C7 FE F4 BA 7F 3F 1F CE B3 A1 43 42 63 B7 15 5E DA CD 4A 3B B4 F6 2A F7 71 98 EA F3 E3 9A DC 6E 45 2E 6D 87 C5 78 3F DE 1E 4E 87 71 09 F3 82 CD 9A E4 DC 24 8C EB 6D F1 C0 A8 A3 CF C3 E9 E9 F0 ED 38 9F D1 88 7A 81 A6 D5 C8 0F BF B4 C3 4A 7B 9D 4D E3 B2 73 90 07 A7 98 DC 50 67 D5 66 47 AE D4 89 35 A4 3D AC 74 15 E7 5D C5 C1 94 78 72 43 6A 02 87 27 BF 3B BC 9F 8F FD BE 3A E8 E5 E7 F9 F5 3C 5A AD 71 91 94 96 8F F7 FE 1E 35 5C 6E 19 16 CD 6E FC 37 52 66 37 5D 9A 86 DB CE AF DF 5F F6 83 ED 3B EE DB 39 86 F7 BB D7 53 3F 6E DA 11 FE FE 3F DE 3C A4 F2 01 00 00 00 19 0D 00 00 00 78 9C AB 56 4A 2D 4B CD 2B 29 56 B2 8A 8E AD 05 00 21 8C 04 C4 00 00 00 00 01 00 00 00 0D 00 21 97 30 00 00 00 0D 00 21 97 30 01 00 00 00 21 00 39 C8 C5 00 00 00 0E 54 75 72 65 6C 27 73 20 54 68 72 61 6C 6C 5B 00 25 52 00 00 00 01 00 00 00 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 00 00 00 19 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 09 00 00 00 08 49 6E 66 69 6E 69 74 65 00 00 00 0F 31 30 30 30 30 31 32 33 30 34 35 32 37 34 34 00 00 00 66 00 00 0B 1F 00 00 00 02 00 00 00 02 00 00 04 B0 00 00 00 3C 00 00 08 2E 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 01 52 02 E8 A8 A0 03 00 00 00 01 00 00 1A F4 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 06 00 2D C6 C1 00 81 B3 20 00 2D C6 C2 00 81 B3 20 00 2D C6 C3 00 02 71 00 00 2D C6 C4 00 24 9F 00 00 2D C6 C5 00 24 9F 00 00 2D C6 C6 00 00 2E E0 00 00 00 06 00 2D C6 C1 00 06 1C F7 00 2D C6 C2 00 05 E4 E9 00 2D C6 C3 00 00 03 22 00 2D C6 C4 00 00 00 00 00 2D C6 C5 00 00 00 00 00 2D C6 C6 00 00 00 00 00 00 00 0F 00 3D 09 00 00 00 00 1A 00 3D 09 01 00 00 00 00 00 3D 09 02 00 00 00 00 00 3D 09 03 00 00 00 01 00 3D 09 04 00 00 00 01 00 3D 09 05 00 00 00 00 00 3D 09 06 00 00 00 01 00 3D 09 07 00 00 00 00 00 3D 09 08 00 00 00 00 00 3D 09 09 00 00 00 00 00 3D 09 0A 00 00 00 00 00 3D 09 0B 00 00 00 00 00 3D 09 0C 00 00 00 00 00 3D 09 0D 00 00 00 00 00 3D 09 0F 00 00 00 00 00 00 00 06 01 8C BA 80 00 00 00 01 01 8C BA 81 00 00 00 01 01 8C BA 82 00 00 00 01 01 8C BA 83 00 00 00 01 01 8C BA 85 00 00 00 01 01 8C BA 89 00 00 00 01 00 00 00 0C 00 3D 09 00 00 00 00 05 00 3D 09 01 00 00 00 05 00 3D 09 02 00 00 00 04 00 3D 09 03 00 00 00 05 00 3D 09 04 00 00 00 04 00 3D 09 05 00 00 00 04 00 3D 09 06 00 00 00 04 00 3D 09 07 00 00 00 02 00 3D 09 08 00 00 00 02 00 3D 09 09 00 00 00 01 00 3D 09 0A 00 00 00 02 00 3D 09 0B 00 00 00 03 00 00 00 03 01 8C BA 80 00 00 00 03 01 8C BA 81 00 00 00 04 01 8C BA 82 00 00 00 04 00 00 00 02 01 AB 3F 00 00 00 00 0A 01 AB 3F 01 00 00 00 08 00 00 00 02 01 AB 3F 00 00 00 00 00 01 AB 3F 01 00 00 00 00 00 00 00 02 01 AB 3F 00 00 00 00 03 01 AB 3F 01 00 00 00 03 00 00 00 48 00 3D 09 00 00 00 00 00 00 00 00 00 00 3D 09 00 00 00 00 00 00 00 00 01 00 3D 09 00 00 00 00 00 00 00 00 02 00 3D 09 00 00 00 00 00 00 00 00 03 00 3D 09 00 00 00 00 00 00 00 00 04 00 3D 09 00 00 00 00 00 00 00 00 05 00 3D 09 00 00 00 00 00 00 00 00 06 00 3D 09 01 00 00 00 00 00 00 00 00 00 3D 09 01 00 00 00 00 00 00 00 01 00 3D 09 01 00 00 00 00 00 00 00 02 00 3D 09 01 00 00 00 00 00 00 00 03 00 3D 09 01 00 00 00 00 00 00 00 04 00 3D 09 01 00 00 00 00 00 00 00 05 00 3D 09 01 00 00 00 00 00 00 00 06 00 3D 09 02 00 00 00 00 00 00 00 00 00 3D 09 02 00 00 00 00 00 00 00 01 00 3D 09 02 00 00 00 00 00 00 00 02 00 3D 09 02 00 00 00 00 00 00 00 03 00 3D 09 02 00 00 00 00 00 00 00 04 00 3D 09 03 00 00 00 00 00 00 00 00 00 3D 09 03 00 00 00 00 00 00 00 01 00 3D 09 03 00 00 00 00 00 00 00 02 00 3D 09 03 00 00 00 00 00 00 00 03 00 3D 09 03 00 00 00 00 00 00 00 04 00 3D 09 03 00 00 00 00 00 00 00 05 00 3D 09 03 00 00 00 00 00 00 00 06 00 3D 09 04 00 00 00 00 00 00 00 00 00 3D 09 04 00 00 00 00 00 00 00 01 00 3D 09 04 00 00 00 00 00 00 00 02 00 3D 09 04 00 00 00 00 00 00 00 03 00 3D 09 04 00 00 00 00 00 00 00 04 00 3D 09 05 00 00 00 00 00 00 00 00 00 3D 09 05 00 00 00 00 00 00 00 01 00 3D 09 05 00 00 00 00 00 00 00 02 00 3D 09 05 00 00 00 00 00 00 00 03 00 3D 09 05 00 00 00 00 00 00 00 04 00 3D 09 05 00 00 00 00 00 00 00 05 00 3D 09 06 00 00 00 00 00 00 00 00 00 3D 09 06 00 00 00 00 00 00 00 01 00 3D 09 06 00 00 00 00 00 00 00 02 00 3D 09 06 00 00 00 00 00 00 00 03 00 3D 09 06 00 00 00 00 00 00 00 04 00 3D 09 06 00 00 00 00 00 00 00 05 00 3D 09 07 00 00 00 00 00 00 00 00 00 3D 09 07 00 00 00 00 00 00 00 01 00 3D 09 07 00 00 00 00 00 00 00 02 00 3D 09 08 00 00 00 00 00 00 00 00 00 3D 09 08 00 00 00 00 00 00 00 01 00 3D 09 08 00 00 00 00 00 00 00 02 00 3D 09 08 00 00 00 00 00 00 00 03 00 3D 09 08 00 00 00 00 00 00 00 04 00 3D 09 09 00 00 00 00 00 00 00 00 00 3D 09 09 00 00 00 00 00 00 00 01 00 3D 09 09 00 00 00 00 00 00 00 02 00 3D 09 09 00 00 00 00 00 00 00 03 00 3D 09 09 00 00 00 00 00 00 00 04 00 3D 09 0A 00 00 00 00 00 00 00 00 00 3D 09 0A 00 00 00 00 00 00 00 01 00 3D 09 0A 00 00 00 00 00 00 00 02 00 3D 09 0A 00 00 00 00 00 00 00 03 00 3D 09 0A 00 00 00 00 00 00 00 04 00 3D 09 0A 00 00 00 00 00 00 00 05 00 3D 09 0B 00 00 00 00 00 00 00 00 00 3D 09 0B 00 00 00 00 00 00 00 01 00 3D 09 0B 00 00 00 00 00 00 00 02 00 3D 09 0B 00 00 00 00 00 00 00 03 00 3D 09 0B 00 00 00 00 00 00 00 04 00 3D 09 0C 00 00 00 00 00 00 00 00 00 3D 09 0F 00 00 00 00 00 00 00 00 00 3D 09 0F 00 00 00 00 00 00 00 01 01 8C BA 89 00 00 00 00 00 00 00 01 01 8C BA 89 00 00 00 00 00 00 00 02 00 00 00 10 01 40 6F 40 01 40 6F 41 01 40 6F 42 01 40 6F 43 01 40 6F 44 01 40 6F 45 01 40 6F 46 01 40 6F 47 01 40 6F 48 01 40 6F 49 01 40 6F 4A 01 40 6F 4B 01 40 6F 4C 01 40 6F 4D 01 40 6F 4E 01 40 6F 4F 00 00 00 36 01 5E F3 C0 01 5E F3 C1 01 5E F3 C2 01 5E F3 C3 01 5E F3 C4 01 5E F3 C5 01 5E F3 C6 01 5E F3 C7 01 5E F3 C8 01 5E F3 C9 01 5E F3 CA 01 5E F3 CB 01 5E F3 CC 01 5E F3 CD 01 5E F3 CE 01 5E F3 CF 01 5E F3 D0 01 5E F3 D1 01 5E F3 D2 01 5E F3 D3 01 5E F3 D4 01 5E F3 D5 01 5E F3 D6 01 5E F3 D7 01 5E F3 D8 01 5E F3 D9 01 5E F3 DA 01 5E F3 DB 01 5E F3 DC 01 5E F3 DD 01 5E F3 DE 01 5E F3 DF 01 5E F3 E1 01 5E F3 E2 01 5E F3 E3 01 5E F3 E4 01 5E F3 E5 01 5E F3 E7 01 5E F3 E8 01 5E F3 EA 01 5E F3 EB 01 5E F3 EC 01 5E F3 ED 01 5E F3 EE 01 5E F3 F0 01 5E F3 F1 01 5E F3 F3 01 5E F3 F4 01 5E F3 F6 01 5E F3 F7 01 5E F3 F9 01 5E F3 FC 01 5E F3 FD 01 5E F3 FF 00 00 00 48 01 5E F3 C0 00 00 00 0B 01 5E F3 C1 00 00 00 0B 01 5E F3 C2 00 00 00 0B 01 5E F3 C3 00 00 00 96 01 5E F3 C4 00 00 00 96 01 5E F3 C5 00 00 00 96 01 5E F3 C6 00 00 00 0A 01 5E F3 C7 00 00 00 0A 01 5E F3 C8 00 00 00 0A 01 5E F3 C9 00 00 05 61 01 5E F3 CA 00 00 05 61 01 5E F3 CB 00 00 05 61 01 5E F3 CC 00 00 00 01 01 5E F3 CD 00 00 00 01 01 5E F3 CE 00 00 00 01 01 5E F3 CF 13 80 93 0F 01 5E F3 D0 13 80 93 0F 01 5E F3 D1 13 80 93 0F 01 5E F3 D2 16 5F 94 6D 01 5E F3 D3 16 5F 94 6D 01 5E F3 D4 16 5F 94 6D 01 5E F3 D5 00 00 0B 79 01 5E F3 D6 00 00 0B 79 01 5E F3 D7 00 00 0B 79 01 5E F3 D8 00 00 00 04 01 5E F3 D9 00 00 00 04 01 5E F3 DA 00 00 00 04 01 5E F3 DB 00 00 55 D7 01 5E F3 DC 00 00 55 D7 01 5E F3 DD 00 00 55 D7 01 5E F3 DE 00 00 06 6D 01 5E F3 DF 00 00 06 6D 01 5E F3 E0 00 00 06 6D 01 5E F3 E1 00 00 1B 7F 01 5E F3 E2 00 00 1B 7F 01 5E F3 E3 00 00 1B 7F 01 5E F3 E4 00 00 09 D3 01 5E F3 E5 00 00 09 D3 01 5E F3 E6 00 00 09 D3 01 5E F3 E7 00 00 04 F4 01 5E F3 E8 00 00 04 F4 01 5E F3 E9 00 00 04 F4 01 5E F3 EA 00 00 A2 F9 01 5E F3 EB 00 00 A2 F9 01 5E F3 EC 00 00 A2 F9 01 5E F3 ED 00 00 0D 02 01 5E F3 EE 00 00 0D 02 01 5E F3 EF 00 00 0D 02 01 5E F3 F0 00 0F 29 D9 01 5E F3 F1 00 0F 29 D9 01 5E F3 F2 00 0F 29 D9 01 5E F3 F3 00 00 00 0E 01 5E F3 F4 00 00 00 0E 01 5E F3 F5 00 00 00 0E 01 5E F3 F6 00 00 02 10 01 5E F3 F7 00 00 02 10 01 5E F3 F8 00 00 02 10 01 5E F3 F9 00 00 00 6B 01 5E F3 FA 00 00 00 6B 01 5E F3 FB 00 00 00 6B 01 5E F3 FC 00 00 00 EC 01 5E F3 FD 00 00 00 EC 01 5E F3 FE 00 00 00 EC 01 5E F3 FF 00 DE 17 F2 01 5E F4 00 00 DE 17 F2 01 5E F4 01 00 DE 17 F2 01 5E F4 02 00 00 00 01 01 5E F4 03 00 00 00 01 01 5E F4 04 00 00 00 01 01 5E F4 05 00 00 00 03 01 5E F4 06 00 00 00 03 01 5E F4 07 00 00 00 03 00 00 00 32 01 03 66 40 00 00 00 03 01 03 66 41 00 00 00 03 01 03 66 42 00 00 00 03 01 03 66 43 00 00 00 03 01 03 66 44 00 00 00 03 01 03 66 45 00 00 00 03 01 03 66 46 00 00 00 03 01 03 66 47 00 00 00 03 01 03 66 48 00 00 00 03 01 03 66 49 00 00 00 03 01 03 66 4A 00 00 00 03 01 03 66 4B 00 00 00 03 01 03 66 4C 00 00 00 03 01 03 66 4D 00 00 00 03 01 03 66 4E 00 00 00 03 01 03 66 4F 00 00 00 03 01 03 66 50 00 00 00 03 01 03 66 51 00 00 00 03 01 03 66 52 00 00 00 03 01 03 66 53 00 00 00 03 01 03 66 54 00 00 00 03 01 03 66 55 00 00 00 03 01 03 66 56 00 00 00 03 01 03 66 57 00 00 00 03 01 03 66 58 00 00 00 03 01 03 66 59 00 00 00 03 01 03 66 5A 00 00 00 03 01 03 66 5B 00 00 00 03 01 03 66 5C 00 00 00 03 01 03 66 5D 00 00 00 03 01 03 66 5E 00 00 00 03 01 03 66 5F 00 00 00 03 01 03 66 60 00 00 00 03 01 03 66 61 00 00 00 03 01 03 66 62 00 00 00 03 01 03 66 63 00 00 00 03 01 03 66 64 00 00 00 03 01 03 66 65 00 00 00 03 01 03 66 66 00 00 00 03 01 03 66 67 00 00 00 03 01 03 66 68 00 00 00 03 01 03 66 69 00 00 00 03 01 03 66 6A 00 00 00 03 01 03 66 6B 00 00 00 03 01 03 66 6C 00 00 00 03 01 03 66 6D 00 00 00 03 01 03 66 6E 00 00 00 03 01 03 66 6F 00 00 00 03 01 03 66 70 00 00 00 03 01 03 66 71 00 00 00 03 00 00 00 32 01 03 66 40 00 00 01 F4 01 03 66 41 00 00 01 F4 01 03 66 42 00 00 01 F4 01 03 66 43 00 00 03 E8 01 03 66 44 00 00 03 E8 01 03 66 45 00 00 03 E8 01 03 66 46 00 00 07 D0 01 03 66 47 00 00 07 D0 01 03 66 48 00 00 07 D0 01 03 66 49 00 00 0B B8 01 03 66 4A 00 00 0B B8 01 03 66 4B 00 00 0B B8 01 03 66 4C 00 00 0F A0 01 03 66 4D 00 00 0F A0 01 03 66 4E 00 00 0F A0 01 03 66 4F 00 00 13 88 01 03 66 50 00 00 13 88 01 03 66 51 00 00 13 88 01 03 66 52 00 00 17 70 01 03 66 53 00 00 17 70 01 03 66 54 00 00 17 70 01 03 66 55 00 00 1B 58 01 03 66 56 00 00 1B 58 01 03 66 57 00 00 27 10 01 03 66 58 00 00 27 10 01 03 66 59 00 00 27 10 01 03 66 5A 00 00 3A 98 01 03 66 5B 00 00 3A 98 01 03 66 5C 00 00 3A 98 01 03 66 5D 00 00 4E 20 01 03 66 5E 00 00 4E 20 01 03 66 5F 00 00 4E 20 01 03 66 60 00 00 75 30 01 03 66 61 00 00 75 30 01 03 66 62 00 00 75 30 01 03 66 63 00 00 C3 50 01 03 66 64 00 01 86 A0 01 03 66 65 00 01 86 A0 01 03 66 66 00 01 86 A0 01 03 66 67 00 02 49 F0 01 03 66 68 00 02 49 F0 01 03 66 69 00 02 49 F0 01 03 66 6A 00 03 0D 40 01 03 66 6B 00 03 D0 90 01 03 66 6C 00 04 93 E0 01 03 66 6D 00 06 1A 80 01 03 66 6E 00 07 A1 20 01 03 66 6F 00 09 27 C0 01 03 66 70 00 0A AE 60 01 03 66 71 00 0C 35 00 00 00 00 32 01 03 66 40 00 00 01 F4 01 03 66 41 00 00 01 F4 01 03 66 42 00 00 01 F4 01 03 66 43 00 00 03 E8 01 03 66 44 00 00 03 E8 01 03 66 45 00 00 03 E8 01 03 66 46 00 00 07 D0 01 03 66 47 00 00 07 D0 01 03 66 48 00 00 07 D0 01 03 66 49 00 00 0B B8 01 03 66 4A 00 00 0B B8 01 03 66 4B 00 00 0B B8 01 03 66 4C 00 00 0F A0 01 03 66 4D 00 00 0F A0 01 03 66 4E 00 00 0F A0 01 03 66 4F 00 00 13 88 01 03 66 50 00 00 13 88 01 03 66 51 00 00 13 88 01 03 66 52 00 00 17 70 01 03 66 53 00 00 17 70 01 03 66 54 00 00 17 70 01 03 66 55 00 00 1B 58 01 03 66 56 00 00 1B 58 01 03 66 57 00 00 27 10 01 03 66 58 00 00 27 10 01 03 66 59 00 00 27 10 01 03 66 5A 00 00 3A 98 01 03 66 5B 00 00 3A 98 01 03 66 5C 00 00 3A 98 01 03 66 5D 00 00 4E 20 01 03 66 5E 00 00 4E 20 01 03 66 5F 00 00 4E 20 01 03 66 60 00 00 75 30 01 03 66 61 00 00 75 30 01 03 66 62 00 00 75 30 01 03 66 63 00 00 C3 50 01 03 66 64 00 01 86 A0 01 03 66 65 00 04 1E B0 01 03 66 66 00 01 86 A0 01 03 66 67 00 02 49 F0 01 03 66 68 00 02 49 F0 01 03 66 69 00 02 49 F0 01 03 66 6A 00 03 0D 40 01 03 66 6B 00 03 D0 90 01 03 66 6C 00 04 93 E0 01 03 66 6D 00 06 1A 80 01 03 66 6E 00 07 A1 20 01 03 66 6F 00 09 27 C0 01 03 66 70 00 0A AE 60 01 03 66 71 00 0C 35 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 05 02 34 93 40 00 00 00 03 02 34 93 42 00 00 00 00 02 34 93 45 00 00 00 01 02 34 93 46 00 00 00 01 02 34 93 47 58 B1 81 78 00 00 00 0B 00 3D 09 00 00 00 00 01 00 3D 09 01 00 00 00 02 00 3D 09 03 00 00 00 01 00 3D 09 04 00 00 00 01 00 3D 09 06 00 00 00 01 00 3D 09 07 00 00 00 02 00 3D 09 08 00 00 00 02 00 3D 09 09 00 00 00 01 00 3D 09 0A 00 00 00 01 00 3D 09 0B 00 00 00 01 00 3D 09 0D 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 08 00 3D 09 00 00 00 00 1D 00 3D 09 01 00 00 00 00 00 3D 09 03 00 00 00 01 00 3D 09 04 00 00 00 01 00 3D 09 06 00 00 00 01 00 3D 09 08 00 00 00 00 00 3D 09 0D 00 00 00 00 01 8C BA 89 00 00 00 00 00 00 00 0E 00 3D 09 03 00 0A 00 00 00 3D 09 05 00 0A 00 00 00 3D 09 06 00 0C 00 00 00 3D 09 07 00 03 00 00 00 3D 09 08 00 02 00 00 00 3D 09 09 00 02 00 00 00 3D 09 0A 00 18 00 00 00 3D 09 0B 00 0A 00 00 00 3D 09 0C 00 06 00 00 00 3D 09 0D 00 02 00 00 00 3D 09 0F 00 04 00 00 00 3D 09 17 00 05 00 00 00 3D 09 18 00 0A 00 00 00 3D 09 1E 00 0C 00 00".Replace(" ", ""));
        }
    }
}