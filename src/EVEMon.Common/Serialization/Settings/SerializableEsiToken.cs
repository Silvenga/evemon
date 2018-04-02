using System;
using System.Xml.Serialization;

namespace EVEMon.Common.Serialization.Settings
{
    public sealed class SerializableEsiToken
    {
        [XmlAttribute("clientID")]
        public string ClientID { get; set; }

        [XmlAttribute("clientSecret")]
        public string ClientSecret { get; set; }

        [XmlAttribute("refreshToken")]
        public string RefreshToken { get; set; }

        [XmlAttribute("expires")]
        public DateTime Expiration { get; set; }

        [XmlAttribute("lastUpdate")]
        public DateTime LastUpdate { get; set; }

        [XmlAttribute("monitored")]
        public bool Monitored { get; set; }
    }
}
