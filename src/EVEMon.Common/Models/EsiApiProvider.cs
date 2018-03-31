using System;
using System.Linq;
using System.Xml.Xsl;

using EVEMon.Common.Models.EsiProviders;
using EVEMon.Common.Serialization.Eve;

namespace EVEMon.Common.Models
{
    public class EsiApiProvider : APIProvider
    {
        private readonly EsiProviderRegister _register;


        public EsiApiProvider()
        {
            _register = new EsiProviderRegister();
        }

        protected override void QueryMethodAsync<T>(Enum method, Action<CCPAPIResult<T>> callback, string postData, XslCompiledTransform transform)
        {
            var provider = _register.GetProviderFor<T>(method);
            var providerInstalled = provider != null;

            if (!providerInstalled)
            {
                base.QueryMethodAsync(method, callback, postData, transform);
            }
            else
            {
                // TODO HACK
                var keyValues = postData?.Split('&').Select(x => x.Split('=')).ToDictionary(x => x[0], x => x[1]);

                var result = provider.Invoke(keyValues, DataSource, "ADD THIS THING");
                callback(result);
            }
        }
    }
}