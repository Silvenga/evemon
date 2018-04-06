using System;
using System.Xml.Serialization;
using EVEMon.Common.Extensions;

namespace EVEMon.Common.Serialization.Eve
{
    /// <summary>
    /// Represents a serializable version of the account status. Used for querying CCP.
    /// </summary>
    public sealed class SerializableAPIAccountStatus
    {
        [XmlElement("userID")]
        public long ID { get; set; }

        [XmlElement("paidUntil")]
        public string PaidUntilXml
        {
            get { return PaidUntil.DateTimeToTimeString(); }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    PaidUntil = value.TimeStringToDateTime();
            }
        }

        [XmlElement("createDate")]
        public string CreateDateXml
        {
            get { return CreateDate.DateTimeToTimeString(); }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    CreateDate = value.TimeStringToDateTime();
            }
        }

        /// <summary>
        /// The date and time the account expires.
        /// </summary>
        [XmlIgnore]
        public DateTime PaidUntil { get; set; }

        /// <summary>
        /// The date and time the account was created.
        /// </summary>
        [XmlIgnore]
        public DateTime CreateDate { get; set; }
    }
}