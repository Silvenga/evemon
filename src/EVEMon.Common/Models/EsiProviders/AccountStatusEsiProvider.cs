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
    //Another weird esiprovider because esi doesnt provide account level info, so we fake it until we fully integrate esitokens
    public class AccountStatusEsiProvider : IEsiProvider<SerializableAPIAccountStatus>
    {
        private readonly ICharacterApi _characterApi;

        public Enum Provides { get; } = CCPAPICharacterMethods.AccountStatus;

        public AccountStatusEsiProvider()
        {
            _characterApi = new CharacterApi();

        }

        public CCPAPIResult<SerializableAPIAccountStatus> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var characterId = GetCharacterId(accessToken);

            var characterInfo = _characterApi.GetCharactersCharacterId((int) characterId, dataSource);

            var result = new CCPAPIResult<SerializableAPIAccountStatus>
            {
                Result = new SerializableAPIAccountStatus
                {
                    CreateDate = characterInfo.Birthday.GetValueOrDefault(),
                    PaidUntil = DateTime.MaxValue //Yup, esi doesnt have this info, so fake it
                }
            };


            return result;
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
