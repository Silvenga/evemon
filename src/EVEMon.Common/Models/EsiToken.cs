using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVEMon.Common.Attributes;
using EVEMon.Common.CustomEventArgs;
using EVEMon.Common.Serialization.Settings;

namespace EVEMon.Common.Models
{
    /// <summary>
    /// Represents a Esi Token
    /// </summary>
    [EnforceUIThreadAffinity]
    public sealed class EsiToken
    {

        #region Fields

        private bool m_queried;
        private bool m_monitored;
        private bool m_updatePending;
        private bool m_characterListUpdated;

        #endregion


        #region Constructors

        /// <summary>
        /// Common constructor base.
        /// </summary>
        private EsiToken()
        {
            EveMonClient.TimerTick += EveMonClient_TimerTick;
        }

        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        /// <param name="serial"></param>
        internal EsiToken(SerializableEsiToken serial)
            : this()
        {
            ClientID = serial.ClientID;
            ClientSecret = serial.ClientSecret;
            RefreshToken = serial.RefreshToken;
            Expiration = serial.Expiration;
            m_monitored = serial.Monitored;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the Client ID
        /// </summary>
        /// <value>The Client ID</value>
        public string ClientID { get; }

        /// <summary>
        /// Gets or sets the Client Secret
        /// </summary>
        /// <value>The Client Secret.</value>
        public string ClientSecret { get; }

        /// <summary>
        /// Gets or sets the refresh token
        /// </summary>
        /// <value>The Refresh Token.</value>
        public string RefreshToken { get; }

        /// <summary>
        /// Gets or sets the token expiration.
        /// </summary>
        /// <value>The token expiration.</value>
        public DateTime Expiration { get; }

        /// <summary>
        /// Gets the character identities for this API key.
        /// </summary>
        public IEnumerable<CharacterIdentity> CharacterIdentities 
            => EveMonClient.CharacterIdentities.Where(characterID => characterID.EsiTokens.Contains(this));

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EsiToken"/> is monitored.
        /// </summary>
        /// <value><c>true</c> if monitored; otherwise, <c>false</c>.</value>
        public bool Monitored
        {
            get { return m_monitored; }
            set
            {
                m_monitored = value;
                EveMonClient.OnESITokenMonitoredChanged();
            }
        }

        /// <summary>
        /// Gets true if at least one of the CCP characters is monitored.
        /// </summary>
        public bool HasMonitoredCharacters
            => CharacterIdentities
                .Select(id => id.CCPCharacter)
                .Any(ccpCharacter => ccpCharacter != null && ccpCharacter.Monitored);

        /// <summary>
        /// Gets true if this Token got queried or is not monitored.
        /// </summary>
        public bool IsProcessed => m_queried || !m_monitored;

        #endregion



        #region Inherited events

        /// <summary>
        /// Called when the object gets disposed.
        /// </summary>
        internal void Dispose()
        {
            // Unsubscribe events
            EveMonClient.TimerTick -= EveMonClient_TimerTick;
        }

        #endregion


        #region Global Events

        /// <summary>
        /// Updates the API key info and account status on a timer tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EveMonClient_TimerTick(object sender, EventArgs e)
        {
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Tries the add or update async the esi token
        /// </summary>
        public static void TryAddOrUpdateAsync(string clientId, string clientSecret, string authCode,
                                               EventHandler<EsiTokenCreationEventArgs> callback)
        {
            //TODO: do stuff later
            callback(null, new EsiTokenCreationEventArgs());
        }

        #endregion


        #region Importation / Exportation

        /// <summary>
        /// Updates the API key info and characters list with the given CCP data.
        /// </summary>
        /// <param name="result"></param>
        //private void Import(CCPAPIResult<SerializableAPIKeyInfo> result)
        //{
        //    Type = GetCredentialsType(result);
        //    AccessMask = result.Result.Key.AccessMask;
        //    Expiration = result.Result.Key.Expiration;

        //    ImportIdentities(result.HasError ? null : result.Result.Key.Characters);
        //}

        /// <summary>
        /// Updates the characters list with the given CCP data.
        /// </summary>
        /// <param name="identities"></param>
        //private void ImportIdentities(IEnumerable<ISerializableCharacterIdentity> identities)
        //{
        //    // Clear the API key on this character
        //    foreach (CharacterIdentity id in EveMonClient.CharacterIdentities.Where(id => id.EsiTokens.Contains(this)))
        //    {
        //        id.EsiTokens.Remove(this);
        //    }

        //    // Return if there were errors in the query
        //    if (identities == null)
        //        return;

        //    // Assign owned identities to this API key
        //    List<ISerializableCharacterIdentity> serializableCharacterIdentities = identities.ToList();
        //    foreach (CharacterIdentity id in serializableCharacterIdentities.Select(
        //        serialID => EveMonClient.CharacterIdentities[serialID.ID] ??
        //                    EveMonClient.CharacterIdentities.Add(serialID.ID, serialID.Name)))
        //    {
        //        // Update the other info as they may have changed
        //        ISerializableCharacterIdentity characterIdentity = serializableCharacterIdentities.First(x => x.ID == id.CharacterID);
        //        id.CorporationID = characterIdentity.CorporationID;
        //        id.CorporationName = characterIdentity.CorporationName;
        //        id.AllianceID = characterIdentity.AllianceID;
        //        id.AllianceName = characterIdentity.AllianceName;
        //        id.FactionID = characterIdentity.FactionID;
        //        id.FactionName = characterIdentity.FactionName;

        //        // Add the API key to the identity
        //        id.EsiTokens.Add(this);

        //        if (id.CCPCharacter == null)
        //            continue;

        //        // Update the other info
        //        id.CCPCharacter.CorporationID = id.CorporationID;
        //        id.CCPCharacter.CorporationName = id.CorporationName;
        //        id.CCPCharacter.AllianceID = id.AllianceID;
        //        id.CCPCharacter.AllianceName = id.AllianceName;
        //        id.CCPCharacter.FactionID = id.FactionID;
        //        id.CCPCharacter.FactionName = id.FactionName;

        //        // Notify subscribers
        //        EveMonClient.OnCharacterUpdated(id.CCPCharacter);
        //    }

        //    m_characterListUpdated = true;

        //    // Fires the event regarding the character list update
        //    //EveMonClient.OnCharacterListUpdated(this);

        //    // API collection changed, so we'll need to reprocess accounts.
        //    //EveMonClient.OnAPIKeyCollectionChanged();
        //}

        /// <summary>
        /// Exports the data to a serialization object.
        /// </summary>
        /// <returns></returns>
        internal SerializableEsiToken Export()
        {
            SerializableEsiToken serial = new SerializableEsiToken
                                            {
                                                ClientID = ClientID,
                                                ClientSecret = ClientSecret,
                                                RefreshToken = RefreshToken,
                                                Expiration = Expiration,
                                                Monitored = m_monitored,
                                            };

            return serial;
        }

        #endregion
    
        #region Overridden Methods

        /// <summary>
        /// Gets a string representation of this API key, under the given format : 123456 (John Doe, Jane Doe).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // If no characters on this API key, return only the API key ID
            if (!CharacterIdentities.Any())
                return "";

            // Otherwise, return the chars' names into parenthesis
            StringBuilder names = new StringBuilder();
            foreach (CharacterIdentity id in CharacterIdentities)
            {
                names.Append(id.CharacterName);
                if (id != CharacterIdentities.Last())
                    names.Append(", ");
            }
            return $"({names})";
        }

        #endregion
    }
}
