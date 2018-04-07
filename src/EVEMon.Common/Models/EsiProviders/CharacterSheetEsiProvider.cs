﻿using System;
using System.Collections.Generic;
using System.Linq;

using EVEMon.Common.Collections;
using EVEMon.Common.Constants;
using EVEMon.Common.Data;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Datafiles;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using IO.Swagger.Model;

namespace EVEMon.Common.Models.EsiProviders
{
    public class CharacterSheetEsiProvider : IEsiProvider<SerializableAPICharacterSheet>
    {
        private readonly ICharacterApi _characterApi;
        private readonly ICorporationApi _corporationApi;
        private readonly ILocationApi _locationApi;
        private readonly IUniverseApi _universeApi;
        private readonly IWalletApi _walletApi;
        private readonly ISkillsApi _skillsApi;
        private readonly IClonesApi _clonesApi;


        public Enum Provides { get; } = CCPAPICharacterMethods.CharacterSheet;

        public CharacterSheetEsiProvider()
        {
            _characterApi = new CharacterApi();
            _corporationApi = new CorporationApi();
            _locationApi = new LocationApi();
            _universeApi = new UniverseApi();
            _walletApi = new WalletApi();
            _skillsApi = new SkillsApi();
            _clonesApi = new ClonesApi();
        }

        public CCPAPIResult<SerializableAPICharacterSheet> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var characterId = int.Parse(legacyPostData["characterID"]);

            var characterInfo = _characterApi.GetCharactersCharacterId(characterId, dataSource);
            var characterAttributes = _skillsApi.GetCharactersCharacterIdAttributes(characterId, dataSource, accessToken);
            var characterClones = _clonesApi.GetCharactersCharacterIdClones(characterId, dataSource, accessToken);
            


            var result = new CCPAPIResult<SerializableAPICharacterSheet>
            {
                Result = new SerializableAPICharacterSheet
                {
                    ID = characterId,
                    Name = characterInfo.Name,
                    Gender = characterInfo.Gender.ToString(),
                    CorporationID = characterInfo.CorporationId.GetValueOrDefault(),
                    //TODO: Corp Name
                    Birthday = characterInfo.Birthday.GetValueOrDefault(),
                    AllianceID = characterInfo.AllianceId.GetValueOrDefault(),
                    //TODO: Alliance Name
                    FactionID = characterInfo.FactionId.GetValueOrDefault(),
                    //TODO: Faction Name
                    Ancestry = GetAncestryName(characterInfo.AncestryId.GetValueOrDefault(), dataSource),
                    BloodLine = GetBloodLineName(characterInfo.BloodlineId.GetValueOrDefault(), dataSource),
                    LastKnownLocation = GetCharacterLocation(characterId, dataSource, accessToken),
                    SecurityStatus = GetSecurityStatus(characterId, dataSource),
                    ShipName = GetShipName(characterId, dataSource, accessToken),
                    ShipTypeName = GetShipTypeName(characterId, dataSource, accessToken),
                    Balance = GetWalletBalance(characterId, dataSource, accessToken),
                    Attributes = new SerializableCharacterAttributes
                    {
                        Charisma = characterAttributes.Charisma.GetValueOrDefault(),
                        Intelligence = characterAttributes.Intelligence.GetValueOrDefault(),
                        Memory = characterAttributes.Memory.GetValueOrDefault(),
                        Perception = characterAttributes.Perception.GetValueOrDefault(),
                        Willpower = characterAttributes.Willpower.GetValueOrDefault()
                    },
                    FreeRespecs = (short) characterAttributes.BonusRemaps.GetValueOrDefault(),
                    //We cant tell the difference here (possibly by checking accrued remap cooldowndate?)
                    LastRespecDate = characterAttributes.LastRemapDate.GetValueOrDefault(),
                    LastTimedRespec = characterAttributes.LastRemapDate.GetValueOrDefault(),
                    
                    
                }
            };


            result.Result.EmploymentHistory.Clear();
            result.Result.EmploymentHistory.AddRange(GetCorporationHistory(characterId, dataSource));

            //Not supported
            result.Result.Certificates.Clear();

            return result;
        }

        private decimal GetWalletBalance(int characterId, string dataSource, string accessToken)
        {
            var result = _walletApi.GetCharactersCharacterIdWallet(characterId, dataSource, accessToken);
            return (decimal) result.GetValueOrDefault();
        }

        private string GetBloodLineName(int bloodlineId, string dataSource)
        {
            var bloodlines = _universeApi.GetUniverseBloodlines(dataSource);
            return bloodlines.Single(x => x.BloodlineId == bloodlineId).Name;
        }

        private string GetAncestryName(int ancestryId, string dataSource)
        {
            var bloodlines = _universeApi.GetUniverseAncestries(dataSource);
            return bloodlines.Single(x => x.Id == ancestryId).Name;
        }

        private string GetCharacterLocation(int characterId, string dataSource, string accessToken)
        {
            var location = _locationApi.GetCharactersCharacterIdLocation(characterId, dataSource, accessToken);
            //Handle that these are optional
            if (location.StructureId.HasValue)
            {
                var structure = _universeApi.GetUniverseStructuresStructureId(location.StructureId.Value, dataSource);
                return structure.Name;
            }

            if(location.StationId.HasValue)
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

        private IEnumerable<SerializableEmploymentHistory> GetCorporationHistory(int characterId, string dataSource)
        {
            var corpHistory = _characterApi.GetCharactersCharacterIdCorporationhistory(characterId, dataSource);
            //Ew casts
            var corpNameMapping =
                GetCorpNames(corpHistory.Select(x => x.CorporationId).ToList(), dataSource);
            var history = corpHistory.Select(x => new SerializableEmploymentHistory
            {
                CorporationID = x.CorporationId.GetValueOrDefault(),
                CorporationName = corpNameMapping[x.CorporationId.GetValueOrDefault()],
                StartDate = x.StartDate.GetValueOrDefault(),
            });
            return history;
        }

        private Dictionary<int, string> GetCorpNames(List<int?> ids, string dataSource)
        {
            //Endpoint maxes out at 1k ids passed
            var chunkedIds = ids.ChunkBy(1000);

            //TODO: dont like using swaggger classes
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
