using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EVEMon.Common.Collections;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace EVEMon.Common.Models.EsiProviders
{
    public class CharacterNameEsiProvider : IEsiProvider<SerializableAPICharacterName>
    {
        private readonly IUniverseApi _universeApi;

        public Enum Provides { get; } = CCPAPIGenericMethods.CharacterName;

        public CharacterNameEsiProvider()
        {
            _universeApi = new UniverseApi();

        }

        public CCPAPIResult<SerializableAPICharacterName> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var characterStringIds = legacyPostData["ids"].Split(',');

            var ids = characterStringIds.Select(x => (int?) int.Parse(x)).ToList();

            var result = new CCPAPIResult<SerializableAPICharacterName>
            {
                Result = new SerializableAPICharacterName()
            };

            result.Result.Entities.Clear();
            result.Result.Entities.AddRange(GetNames(ids, dataSource));

            return result;
        }

        private IEnumerable<SerializableCharacterNameListItem> GetNames(List<int?> ids, string dataSource)
        {
            //Endpoint maxes out at 1k ids passed
            var chunkedIds = ids.ChunkBy(1000);

            //TODO: do linq magic
            var names = new List<PostUniverseNames200Ok>();

            foreach (var chunk in chunkedIds)
            {
                var namesResult = _universeApi.PostUniverseNames(chunk, dataSource);

                names.AddRange(namesResult);
            }

            return names
                .Where(x => x.Id.HasValue)
                .Select(x => new SerializableCharacterNameListItem
                 {
                     ID = x.Id.Value,
                     Name = x.Name
                }).ToList();
        }
    }
}
