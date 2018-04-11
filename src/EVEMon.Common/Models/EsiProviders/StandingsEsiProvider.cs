using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using EVEMon.Common.Collections;
using EVEMon.Common.Enumerations;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using IO.Swagger.Model;

namespace EVEMon.Common.Models.EsiProviders
{
    public class StandingsEsiProvider : IEsiProvider<SerializableAPIStandings>
    {
        private readonly ICharacterApi _characterApi;
        private readonly ICorporationApi _corporationApi;
        private readonly IUniverseApi _universeApi;

        public Enum Provides { get; } = CCPAPICharacterMethods.Standings;

        public StandingsEsiProvider()
        {
            _characterApi = new CharacterApi();
            _corporationApi = new CorporationApi();
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

            result.Result.CharacterNPCStandings.AgentStandings = GetAgentStandings(standings, dataSource);
            result.Result.CharacterNPCStandings.NPCCorporationStandings = GetNpcCorpStandings(standings, dataSource);
            result.Result.CharacterNPCStandings.FactionStandings = GetFactionStandings(standings, dataSource);

            return result;
        }

        private Collection<SerializableStandingsListItem> GetAgentStandings(List<GetCharactersCharacterIdStandings200Ok> standings, string dataSource)
        {
            var filterdStandings = standings
                .Where(x => x.FromType == GetCharactersCharacterIdStandings200Ok.FromTypeEnum.Agent);

            //ew casts
            var agentNameLookup =
                GetAgentNames(filterdStandings.Select(x => (long?) x.FromId).ToList(), dataSource);

            var agentStandings = filterdStandings
                .Select(x => new SerializableStandingsListItem
            {
                Name = agentNameLookup[x.FromId.GetValueOrDefault()],
                Group = StandingGroup.Agents,
                ID = x.FromId.GetValueOrDefault(),
                StandingValue = x.Standing.GetValueOrDefault()
            }).ToList();

            return new Collection<SerializableStandingsListItem>(agentStandings);
        }

        private Collection<SerializableStandingsListItem> GetNpcCorpStandings(List<GetCharactersCharacterIdStandings200Ok> standings, string dataSource)
        {
            var filterdStandings = standings
                .Where(x => x.FromType == GetCharactersCharacterIdStandings200Ok.FromTypeEnum.Npccorp);

            //ew casts
            var ncpCorpLookup =
                GetNpcCorpNames(filterdStandings.Select(x => x.FromId).ToList(), dataSource);

            var npCorpStandings = filterdStandings
                .Select(x => new SerializableStandingsListItem
                {
                    Name = ncpCorpLookup[x.FromId.GetValueOrDefault()],
                    Group = StandingGroup.NPCCorporations,
                    ID = x.FromId.GetValueOrDefault(),
                    StandingValue = x.Standing.GetValueOrDefault()
                }).ToList();

            return new Collection<SerializableStandingsListItem>(npCorpStandings);
        }


        private Collection<SerializableStandingsListItem> GetFactionStandings(List<GetCharactersCharacterIdStandings200Ok> standings, string dataSource)
        {
            var filterdStandings = standings
                .Where(x => x.FromType == GetCharactersCharacterIdStandings200Ok.FromTypeEnum.Faction);

            //ew casts
            var factionLookup =
                GetNpcFactionNames(filterdStandings.Select(x => x.FromId.GetValueOrDefault()).ToList(), dataSource);

            var factionStandings = filterdStandings
                .Select(x => new SerializableStandingsListItem
                {
                    Name = factionLookup[x.FromId.GetValueOrDefault()],
                    Group = StandingGroup.Factions,
                    ID = x.FromId.GetValueOrDefault(),
                    StandingValue = x.Standing.GetValueOrDefault()
                }).ToList();

            return new Collection<SerializableStandingsListItem>(factionStandings);
        }

        //TODO: abstract this better

        private Dictionary<long, string> GetAgentNames(List<long?> ids, string dataSource)
        {
            //Endpoint maxes out at 1k ids passed
            var chunkedIds = ids.ChunkBy(1000);

            //TODO: dont like using swaggger classes
            var names = new List<GetCharactersNames200Ok>();

            foreach (var chunk in chunkedIds)
            {
                var namesResult = _characterApi.GetCharactersNames(chunk, dataSource);

                names.AddRange(namesResult);
            }

            return names
                .Where(x => x.CharacterId.HasValue)
                .ToDictionary(x => x.CharacterId.GetValueOrDefault(), x => x.CharacterName);

        }

        private Dictionary<int, string> GetNpcCorpNames(List<int?> ids, string dataSource)
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

        //Yea apparently the universe api doesnt handle alliances that are factions?
        private Dictionary<int, string> GetNpcFactionNames(List<int> ids, string dataSource)
        {
            var factions = _universeApi.GetUniverseFactions(dataSource);

            return factions.Where(x => ids.Contains(x.FactionId.GetValueOrDefault()))
                .ToDictionary(x => x.FactionId.GetValueOrDefault(), x => x.Name);
        }
    }
}
