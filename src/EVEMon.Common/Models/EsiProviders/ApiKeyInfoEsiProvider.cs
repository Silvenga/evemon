using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using Newtonsoft.Json;

namespace EVEMon.Common.Models.EsiProviders
{
    //This provider is weird, but allows for faster iteration when working with the api, because clearing cache, may not be needed once token integration works
    public class ApiKeyInfoEsiProvider : IEsiProvider<SerializableAPIKeyInfo>
    {
        private readonly ICharacterApi _characterApi;
        private readonly ILocationApi _locationApi;

        public Enum Provides { get; } = CCPAPIGenericMethods.APIKeyInfo;

        public ApiKeyInfoEsiProvider()
        {
            _characterApi = new CharacterApi();
            _locationApi = new LocationApi();

        }

        public CCPAPIResult<SerializableAPIKeyInfo> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {

            var result = new CCPAPIResult<SerializableAPIKeyInfo>
            {
                Result = new SerializableAPIKeyInfo
                {
                    Key = new SerializableAPIKeyItem
                    {
                        //Dont bother setting expiration its going to get wonky assume non expire
                        AccessMask = 133169114, //full access mask
                        Type = "Account", //set to an account so it looks like an account key with one toon
                    }
                }
            };

            result.Result.Key.Characters.Clear();
            result.Result.Key.Characters.Add(GetCharacterFromToken(dataSource, accessToken));

            return result;
        }

        private SerializableCharacterListItem GetCharacterFromToken(string dataSource, string accessToken)
        {
            var characterId = GetCharacterId(accessToken);

            var characterInfo = _characterApi.GetCharactersCharacterId((int?) characterId, dataSource, accessToken);
            var location = _locationApi.GetCharactersCharacterIdShip((int?) characterId, dataSource, accessToken);

            return new SerializableCharacterListItem
            {
                Name = characterInfo.Name,
                ID = characterId,
                AllianceID = characterInfo.AllianceId.GetValueOrDefault(),
                CorporationID = characterInfo.CorporationId.GetValueOrDefault(),
                //FactionID = characterInfo.
                ShipTypeID = location.ShipTypeId.GetValueOrDefault(),
                //TODO: names
            };

        }

        private long GetCharacterId(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var verifyResult = client.GetAsync("https://login.eveonline.com/oauth/verify").Result;

            if (!verifyResult.IsSuccessStatusCode)
            {
                throw new Exception($"Could not verify token {verifyResult.ReasonPhrase}");
            }

            var tokenCharacter = JsonConvert.DeserializeObject<TokenCharacter>(verifyResult.Content.ReadAsStringAsync().Result);

            return long.Parse(tokenCharacter.CharacterID);
        }

        private class TokenCharacter
        {
            public string CharacterID { get; set; }
            public string CharacterName { get; set; }
            public DateTime ExpiresOn { get; set; }
            public string Scopes { get; set; }
            public string TokenType { get; set; }
            public string CharacterOwnerHash { get; set; }
            public string IntellectualProperty { get; set; }
        }
    }
}
