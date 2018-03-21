using System;
using System.Collections.Generic;
using System.Linq;

using EVEMon.Common.Collections;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using IO.Swagger.Client;

namespace EVEMon.Common.Models.EsiProviders
{
    public class CharacterInfoEsiProvider : IEsiProvider<SerializableAPICharacterInfo>
    {
        private readonly ICharacterApi _charactorApi;
        private readonly ICorporationApi _corporationApi;
        private readonly ILocationApi _locationApi;
        private readonly IUniverseApi _universeApi;

        public Enum Provides { get; } = CCPAPICharacterMethods.CharacterInfo;

        public CharacterInfoEsiProvider()
        {
            var configuration = new Configuration
            {
                UserAgent = "EveMon - Development"
            };
            _charactorApi = new CharacterApi(configuration);
            _corporationApi = new CorporationApi(configuration);
            _locationApi = new LocationApi(configuration);
            _universeApi = new UniverseApi(configuration);
        }

        public CCPAPIResult<SerializableAPICharacterInfo> Invoke(Dictionary<string, string> legacyPostData, string accessToken)
        {
            var characterId = int.Parse(legacyPostData["characterID"]);

            var result = new CCPAPIResult<SerializableAPICharacterInfo>
            {
                Result = new SerializableAPICharacterInfo
                {
                    LastKnownLocation = GetSolarSystem(characterId, accessToken),
                    SecurityStatus = GetSecurityStatus(characterId),
                    ShipName = GetShipName(characterId, accessToken),
                    ShipTypeName = GetShipType(characterId, accessToken)
                }
            };


            result.Result.EmploymentHistory.Clear();
            result.Result.EmploymentHistory.AddRange(GetCorperationHistory(characterId));

            return result;
        }

        private string GetSolarSystem(int characterId, string accessToken)
        {
            var location = _locationApi.GetCharactersCharacterIdLocation(characterId, token: accessToken);
            var solarSystem = _universeApi.GetUniverseSystemsSystemId(location.SolarSystemId);

            return solarSystem.Name;
        }

        private double GetSecurityStatus(int characterId)
        {
            var character = _charactorApi.GetCharactersCharacterId(characterId);
            return character.SecurityStatus.GetValueOrDefault();
        }

        private string GetShipName(int characterId, string accessToken)
        {
            var location = _locationApi.GetCharactersCharacterIdShip(characterId, token: accessToken);
            return location.ShipName;
        }

        private string GetShipType(int characterId, string accessToken)
        {
            var location = _locationApi.GetCharactersCharacterIdShip(characterId, token: accessToken);
            return location.ShipTypeId.ToString(); // TODO
        }

        private IEnumerable<SerializableEmploymentHistoryListItem> GetCorperationHistory(int characterId)
        {
            var corpHistory = _charactorApi.GetCharactersCharacterIdCorporationhistory(characterId);
            var history = corpHistory.Select(x => new SerializableEmploymentHistoryListItem
            {
                CorporationID = x.CorporationId.GetValueOrDefault(),
                CorporationName = _corporationApi.GetCorporationsCorporationId(x.CorporationId.GetValueOrDefault()).CorporationName,
                RecordID = x.RecordId.GetValueOrDefault(),
                StartDate = x.StartDate.GetValueOrDefault(),

            });
            return history;
        }
    }
}
