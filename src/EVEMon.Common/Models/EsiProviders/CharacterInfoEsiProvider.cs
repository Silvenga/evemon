using System;

using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

namespace EVEMon.Common.Models.EsiProviders
{
    public class CharacterInfoEsiProvider : IEsiProvider<SerializableAPICharacterInfo>
    {
        public Enum Provides { get; } = CCPAPICharacterMethods.CharacterInfo;

        public CCPAPIResult<SerializableAPICharacterInfo> Invoke(string legacyPostData)
        {
            throw new NotImplementedException();
        }
    }
}
