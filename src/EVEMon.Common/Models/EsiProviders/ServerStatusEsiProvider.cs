using System;
using System.Collections.Generic;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using IO.Swagger.Client;

namespace EVEMon.Common.Models.EsiProviders
{
    public class ServerStatusEsiProvider : IEsiProvider<SerializableAPIServerStatus>
    {
        private readonly IStatusApi _statusApi;

        public Enum Provides { get; } = CCPAPIGenericMethods.ServerStatus;

        public ServerStatusEsiProvider()
        {
            _statusApi = new StatusApi();
        }

        public CCPAPIResult<SerializableAPIServerStatus> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var status = _statusApi.GetStatus(dataSource);

            var result = new CCPAPIResult<SerializableAPIServerStatus>
            {
                Result = new SerializableAPIServerStatus
                {
                    CCPOpen = (!status.Vip.GetValueOrDefault()).ToString(), //yea a hack because CCPOpen isnt a thing anymore in ESI
                    Players = status.Players.GetValueOrDefault()
                } 
            };

            return result;
        }
    }
}
