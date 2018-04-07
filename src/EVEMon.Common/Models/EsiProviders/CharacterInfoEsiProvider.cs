﻿using System;
using System.Collections.Generic;
using System.Linq;

using EVEMon.Common.Collections;
using EVEMon.Common.Constants;
using EVEMon.Common.Data;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using IO.Swagger.Model;

namespace EVEMon.Common.Models.EsiProviders
{
    public class CharacterInfoEsiProvider : IEsiProvider<SerializableAPICharacterInfo>
    {
        private readonly ICharacterApi _characterApi;
        private readonly ICorporationApi _corporationApi;
        private readonly ILocationApi _locationApi;
        private readonly IUniverseApi _universeApi;

        public Enum Provides { get; } = CCPAPICharacterMethods.CharacterInfo;

        public CharacterInfoEsiProvider()
        {
            _characterApi = new CharacterApi();
            _corporationApi = new CorporationApi();
            _locationApi = new LocationApi();
            _universeApi = new UniverseApi();
        }

        public CCPAPIResult<SerializableAPICharacterInfo> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var characterId = int.Parse(legacyPostData["characterID"]);

            var result = new CCPAPIResult<SerializableAPICharacterInfo>
            {
                Result = new SerializableAPICharacterInfo
                {
                    LastKnownLocation = GetCharacterLocation(characterId, dataSource, accessToken),
                    SecurityStatus = GetSecurityStatus(characterId, dataSource),
                    ShipName = GetShipName(characterId, dataSource, accessToken),
                    ShipTypeName = GetShipTypeName(characterId, dataSource, accessToken)
                }
            };

            result.Result.EmploymentHistory.Clear();
            result.Result.EmploymentHistory.AddRange(GetCorporationHistory(characterId, dataSource));

            return result;
        }

        private string GetCharacterLocation(int characterId, string dataSource, string accessToken)
        {
            var location = _locationApi.GetCharactersCharacterIdLocation(characterId, dataSource, accessToken);
            //Handle that these are optional
            if (location.StructureId.HasValue)
            {
                var structure = _universeApi.GetUniverseStructuresStructureId(location.StructureId.Value, dataSource, accessToken);
                return structure.Name;
            }

            if (location.StationId.HasValue)
            {
                var station = _universeApi.GetUniverseStationsStationId(location.StationId.Value, dataSource);
                return station.Name;
            }

            var solarSystem = _universeApi.GetUniverseSystemsSystemId(location.SolarSystemId, dataSource);

            return solarSystem.Name;
        }

        private double GetSecurityStatus(int characterId, string dataSource)
        {
            var character = _characterApi.GetCharactersCharacterId(characterId, dataSource);
            return character.SecurityStatus.GetValueOrDefault();
        }

        private string GetShipName(int characterId, string dataSource, string accessToken)
        {
            var location = _locationApi.GetCharactersCharacterIdShip(characterId, dataSource, accessToken);
            return location.ShipName;
        }

        private string GetShipTypeName(int characterId, string dataSource, string accessToken)
        {
            var location = _locationApi.GetCharactersCharacterIdShip(characterId, dataSource, accessToken);
            var shipTypeId = location.ShipTypeId.GetValueOrDefault();
            var ship = StaticItems.GetItemByID(shipTypeId);
            return ship == null || shipTypeId == 0 ? EveMonConstants.UnknownText : ship.Name;
        }

        private IEnumerable<SerializableEmploymentHistoryListItem> GetCorporationHistory(int characterId, string dataSource)
        {
            var corpHistory = _characterApi.GetCharactersCharacterIdCorporationhistory(characterId, dataSource);
            var corpNameMapping =
                GetCorpNames(corpHistory.Select(x => x.CorporationId).ToList(), dataSource);
            var history = corpHistory.Select(x => new SerializableEmploymentHistoryListItem
            {
                CorporationID = x.CorporationId.GetValueOrDefault(),
                CorporationName = corpNameMapping[x.CorporationId.GetValueOrDefault()],
                RecordID = x.RecordId.GetValueOrDefault(),
                StartDate = x.StartDate.GetValueOrDefault(),
            });
            return history;
        }

        private Dictionary<int, string> GetCorpNames(List<int?> ids, string dataSource)
        {
            //Endpoint maxes out at 1k ids passed
            var chunkedIds = ids
                             .Distinct()
                             .ToList()
                             .ChunkBy(1000);

            //TODO: dont like using swagger classes
            var names = new List<GetCorporationsNames200Ok>();

            foreach (var chunk in chunkedIds)
            {
                var namesResult = _corporationApi.GetCorporationsNames(chunk, dataSource);
                names.AddRange(namesResult);
            }

            return names
                   .Where(x => x.CorporationId.HasValue)
                   .ToDictionary(x => x.CorporationId.GetValueOrDefault(), x => x.CorporationName);
        }
    }
}