using ClashLand.Extensions.Binary;
using ClashLand.Logic;

namespace ClashLand.Packets.Messages.Client
{
    internal class Search_Clans : Message
    {
        public Search_Clans(Device Device, Reader Reader) : base(Device, Reader)
        {
            // SearchClans.
        }

        private const int m_vAllianceLimit = 40;
        private int m_vAllianceOrigin;
        private int m_vAllianceScore;
        private int m_vMaximumAllianceMembers;
        private int m_vMinimumAllianceLevel;
        private int m_vMinimumAllianceMembers;

        //string m_vSearchString;
        private byte m_vShowOnlyJoinableAlliances;

        private int m_vWarFrequency;

        internal override void Decode()
        {
            this.m_vWarFrequency = this.Reader.ReadInt32();
            this.m_vAllianceOrigin = this.Reader.ReadInt32();
            this.m_vMinimumAllianceMembers = this.Reader.ReadInt32();
            this.m_vMaximumAllianceMembers = this.Reader.ReadInt32();
            this.m_vAllianceScore = this.Reader.ReadInt32();
            this.m_vShowOnlyJoinableAlliances = this.Reader.ReadByte();
            this.Reader.ReadInt32();
            this.m_vMinimumAllianceLevel = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            /*if (m_vSearchString.Length < 15)
            {
                //Resources.DisconnectClient(Device);
            }
            else
            {
                //List<Clans> joinableAlliances = new List<Clans>();

                //foreach (Alliance _Alliance in ResourcesManager.m_vInMemoryAlliances.Values)
                {
                    //if (_Alliance.m_vAllianceName.Contains(m_vSearchString, StringComparison.OrdinalIgnoreCase))
                    {
                        //joinableAlliances.Add(_Alliance);
                    }
                }

                //AllianceListMessage p = new AllianceListMessage(Device);
                //p.m_vAlliances = joinableAlliances;
                //p.m_vSearchString = m_vSearchString;
                //p.Send();*/
        }
    }
}

//}