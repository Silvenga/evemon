using System;
using System.Collections.Generic;

using EVEMon.Common.Serialization.Eve;

namespace EVEMon.Common.Models.EsiProviders
{
    public interface IEsiProvider
    {
        Enum Provides { get; }
    }

    public interface IEsiProvider<T> : IEsiProvider
    {
        CCPAPIResult<T> Invoke(Dictionary<string, string> legacyPostData, string accessToken);
    }
}