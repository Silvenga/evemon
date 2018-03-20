using System;

using EVEMon.Common.Serialization.Eve;

namespace EVEMon.Common.Models.EsiProviders
{
    public interface IEsiProvider
    {
        Enum Provides { get; }
    }

    public interface IEsiProvider<T> : IEsiProvider
    {
        CCPAPIResult<T> Invoke(string legacyPostData);
    }
}