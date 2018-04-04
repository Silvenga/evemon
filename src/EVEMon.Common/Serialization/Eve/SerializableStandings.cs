using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using EVEMon.Common.Enumerations;

namespace EVEMon.Common.Serialization.Eve
{
    public sealed class SerializableStandings
    {
        private Collection<SerializableStandingsListItem> m_agentStandings;
        private Collection<SerializableStandingsListItem> m_npcCorporationStandings;
        private Collection<SerializableStandingsListItem> m_factionStandings;

        public SerializableStandings()
        {
            m_agentStandings = new Collection<SerializableStandingsListItem>();
            m_npcCorporationStandings = new Collection<SerializableStandingsListItem>();
            m_factionStandings = new Collection<SerializableStandingsListItem>();
        }

        [XmlArray("agents")]
        [XmlArrayItem("agent")]
        public Collection<SerializableStandingsListItem> AgentStandings
        {
            get
            {
                foreach (SerializableStandingsListItem agentStanding in m_agentStandings)
                {
                    agentStanding.Group = StandingGroup.Agents;
                }
                return m_agentStandings;
            }
            set => m_agentStandings = value;
        }

        [XmlArray("NPCCorporations")]
        [XmlArrayItem("NPCCorporation")]
        public Collection<SerializableStandingsListItem> NPCCorporationStandings
        {
            get
            {
                foreach (SerializableStandingsListItem npcCorporationStanding in m_npcCorporationStandings)
                {
                    npcCorporationStanding.Group = StandingGroup.NPCCorporations;
                }
                return m_npcCorporationStandings;
            }
            set => m_npcCorporationStandings = value;
        }

        [XmlArray("factions")]
        [XmlArrayItem("faction")]
        public Collection<SerializableStandingsListItem> FactionStandings
        {
            get
            {
                foreach (SerializableStandingsListItem factionStanding in m_factionStandings)
                {
                    factionStanding.Group = StandingGroup.Factions;
                }
                return m_factionStandings;
            }
            set => m_factionStandings = value;
        }

        [XmlIgnore]
        public IEnumerable<SerializableStandingsListItem> All
        {
            get
            {
                List<SerializableStandingsListItem> standings = new List<SerializableStandingsListItem>();
                standings.AddRange(AgentStandings);
                standings.AddRange(NPCCorporationStandings);
                standings.AddRange(FactionStandings);
                return standings;
            }
        }
    }
}