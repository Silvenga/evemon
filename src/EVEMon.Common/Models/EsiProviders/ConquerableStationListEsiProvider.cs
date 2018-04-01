using System;
using System.Collections.Generic;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using IO.Swagger.Client;

namespace EVEMon.Common.Models.EsiProviders
{
    public class ConquerableStationListEsiProvider : IEsiProvider<SerializableAPIConquerableStationList>
    {
        private readonly IStatusApi _statusApi;

        public Enum Provides { get; } = CCPAPIGenericMethods.ConquerableStationList;

        public ConquerableStationListEsiProvider()
        {
            _statusApi = new StatusApi();
        }

        public CCPAPIResult<SerializableAPIConquerableStationList> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var status = _statusApi.GetStatus(dataSource);

            var result = new CCPAPIResult<SerializableAPIConquerableStationList>
            {
                Result = new SerializableAPIConquerableStationList
                {
                    Outposts = { }
                } 
            };

            return result;
        }
    }
}
