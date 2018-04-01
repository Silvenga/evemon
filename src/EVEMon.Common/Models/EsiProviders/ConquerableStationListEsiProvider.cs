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
    public class ConquerableStationListEsiProvider : IEsiProvider<SerializableAPIConquerableStationList>
    {
        private readonly ISovereigntyApi _sovereigntyApi;
        private readonly IUniverseApi _universeApi;
        private readonly ICorporationApi _corporationApi;

        public Enum Provides { get; } = CCPAPIGenericMethods.ConquerableStationList;

        public ConquerableStationListEsiProvider()
        {
            _sovereigntyApi = new SovereigntyApi();
            _universeApi = new UniverseApi();
            _corporationApi = new CorporationApi();

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

            var outpostSovStructures = sovStructures.Where(x => outpostTypeIds.Contains(x.StructureTypeId.GetValueOrDefault()));

            var outposts = new List<SerializableOutpost>();
            foreach (var outpost in outpostSovStructures)
            {
                //Below parts are commented out because we making 2k calls to replicate this endpoint, its slow and painful
                //We need a centralized cache, or lazy load

                //bleh casts
                //var outpostDetails = _universeApi.GetUniverseStationsStationId((int?) outpost.StructureId.GetValueOrDefault(), dataSource);

                var o = new SerializableOutpost
                {
                    //CorporationID = outpostDetails.Owner.GetValueOrDefault(),
                    //CorporationName =
                    //    _corporationApi
                    //        .GetCorporationsCorporationId(outpostDetails.Owner.GetValueOrDefault(), dataSource)
                    //        .CorporationName,
                    SolarSystemID = outpost.SolarSystemId.GetValueOrDefault(),
                    StationID = outpost.StructureId.GetValueOrDefault(),
                    //StationName = outpostDetails.Name,
                    StationName = outpost.StructureId.GetValueOrDefault().ToString(), //TODO use real name
                    StationTypeID = outpost.StructureTypeId.GetValueOrDefault(),
                    
                };

                outposts.Add(o);
            }

            return outposts;
        }
    }
}
