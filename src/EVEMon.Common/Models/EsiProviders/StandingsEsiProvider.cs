using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using EVEMon.Common.Collections;
using EVEMon.Common.Enumerations;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;

namespace EVEMon.Common.Models.EsiProviders
{
    public class StandingsEsiProvider : IEsiProvider<SerializableAPIStandings>
    {
        private readonly ICharacterApi _characterApi;
        private readonly IUniverseApi _universeApi;

        public Enum Provides { get; } = CCPAPICharacterMethods.Standings;

        public StandingsEsiProvider()
        {
            _characterApi = new CharacterApi();
            _universeApi = new UniverseApi();
        }

        public CCPAPIResult<SerializableAPIStandings> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var characterId = int.Parse(legacyPostData["characterID"]);

            var result = new CCPAPIResult<SerializableAPIStandings>
            {
                Result = new SerializableAPIStandings
                {
                    CharacterNPCStandings = new SerializableStandings()
                }
            };

            var standings = _characterApi.GetCharactersCharacterIdStandings(characterId, dataSource, accessToken);

            var agentStandings = standings
                    .Where(x => x.FromType == IO.Swagger.Model.GetCharactersCharacterIdStandings200Ok.FromTypeEnum.Agent)
                    .Select(x => new SerializableStandingsListItem
                    {
                        //TODO: name
                        Name = x.FromId.ToString(),
                        Group = StandingGroup.Agents,
                        ID = x.FromId.GetValueOrDefault(),
                        StandingValue = x.Standing.GetValueOrDefault()
                    }).ToList();

            result.Result.CharacterNPCStandings.AgentStandings =
                new Collection<SerializableStandingsListItem>(agentStandings);

            var npcStandings = standings
                .Where(x => x.FromType == IO.Swagger.Model.GetCharactersCharacterIdStandings200Ok.FromTypeEnum.Npccorp)
                .Select(x => new SerializableStandingsListItem
                {
                    //TODO: name
                    Name = x.FromId.ToString(),
                    Group = StandingGroup.NPCCorporations,
                    ID = x.FromId.GetValueOrDefault(),
                    StandingValue = x.Standing.GetValueOrDefault()
                }).ToList();

            result.Result.CharacterNPCStandings.NPCCorporationStandings =
                new Collection<SerializableStandingsListItem>(npcStandings);

            var factionsStandings = standings
                .Where(x => x.FromType == IO.Swagger.Model.GetCharactersCharacterIdStandings200Ok.FromTypeEnum.Faction)
                .Select(x => new SerializableStandingsListItem
                {
                    //TODO: name
                    Name = x.FromId.ToString(),
                    Group = StandingGroup.Factions,
                    ID = x.FromId.GetValueOrDefault(),
                    StandingValue = x.Standing.GetValueOrDefault()
                }).ToList();

            result.Result.CharacterNPCStandings.FactionStandings =
                new Collection<SerializableStandingsListItem>(factionsStandings);

            return result;
        } 
    }
}
