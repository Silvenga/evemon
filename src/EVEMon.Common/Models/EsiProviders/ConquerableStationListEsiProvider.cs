using System;
using System.Collections.Generic;
using System.Linq;
using EVEMon.Common.Collections;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace EVEMon.Common.Models.EsiProviders
{
    public class ConquerableStationListEsiProvider : IEsiProvider<SerializableAPIConquerableStationList>
    {
        private readonly ISovereigntyApi _sovereigntyApi;
        private readonly IUniverseApi _universeApi;

        public Enum Provides { get; } = CCPAPIGenericMethods.ConquerableStationList;

        public ConquerableStationListEsiProvider()
        {
            _sovereigntyApi = new SovereigntyApi();
            _universeApi = new UniverseApi();

        }

        public CCPAPIResult<SerializableAPIConquerableStationList> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var result = new CCPAPIResult<SerializableAPIConquerableStationList>
            {
                Result = new SerializableAPIConquerableStationList()
            };

            result.Result.Outposts.Clear();
            result.Result.Outposts.AddRange(GetOutposts(dataSource));

            return result;
        }

        private IEnumerable<SerializableOutpost> GetOutposts(string dataSource)
        {
            var sovStructures = _sovereigntyApi.GetSovereigntyStructures(dataSource);

            //TODO: be not hard coded, I hope its complete
            var outpostTypeIds = new List<int> { 21646, 21645, 21644, 21642, 12242, 12294, 12295 };

            var outpostSovStructures = sovStructures.Where(x => outpostTypeIds.Contains(x.StructureTypeId.GetValueOrDefault())).ToList();

            var outpostIds = outpostSovStructures.Select(x => (int?) x.StructureId).ToList();

            var outpostNames = GetOutpostNames(outpostIds, dataSource);

            var outposts = outpostSovStructures.Select(x => new SerializableOutpost
            {
                //TODO: handle corp or alliance

                //Below parts are commented out because we making 2k calls to replicate this endpoint, its slow and painful
                //We only get alliance id not corp id from the sov endpoint

                //CorporationID = outpostDetails.Owner.GetValueOrDefault(),
                //CorporationName =
                //    _corporationApi
                //        .GetCorporationsCorporationId(outpostDetails.Owner.GetValueOrDefault(), dataSource)
                //        .CorporationName,
                SolarSystemID = x.SolarSystemId.GetValueOrDefault(),
                StationID = x.StructureId.GetValueOrDefault(),
                StationName = outpostNames[(int) x.StructureId.GetValueOrDefault()],
                StationTypeID = x.StructureTypeId.GetValueOrDefault(),
            });

            return outposts;
        }

        private Dictionary<int, string> GetOutpostNames(List<int?> ids, string dataSource)
        {
            //Endpoint maxes out at 1k ids passed
            var chunkedIds = ids.ChunkBy(1000);

            //TODO: dont like using swaggger classes
            var names = new List<PostUniverseNames200Ok>();

            foreach (var chunk in chunkedIds)
            {
                var namesResult = _universeApi.PostUniverseNames(chunk, dataSource);

                names.AddRange(namesResult);
            }

            return names
                    .Where(x => x.Category == PostUniverseNames200Ok.CategoryEnum.Station)
                    .Where(x => x.Id.HasValue)
                    .ToDictionary(x => x.Id.GetValueOrDefault(), x => x.Name);

        }
    }
}
