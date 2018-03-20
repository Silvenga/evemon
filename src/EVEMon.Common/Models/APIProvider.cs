using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Xsl;
using EVEMon.Common.Attributes;
using EVEMon.Common.Constants;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Extensions;
using EVEMon.Common.Serialization.Eve;
using EVEMon.Common.Threading;

namespace EVEMon.Common.Models
{

    /// <summary>
    /// Serializable class abstracting an API queries provider and its configuration.
    /// </summary>
    [EnforceUIThreadAffinity]
    public class APIProvider
    {
        private static APIProvider s_ccpProvider;
        private static APIProvider s_ccpTestProvider;
        private static XslCompiledTransform s_rowsetsTransform;

        private readonly List<APIMethod> m_methods;
        private bool m_supportsCompressedResponse;

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal APIProvider()
        {
            m_methods = new List<APIMethod>(APIMethod.CreateDefaultSet());
            Url = new Uri("http://your-custom-API-provider.com");
            Name = "your provider's name";
        }


        #region Properties

        /// <summary>
        /// Returns the name of this APIConfiguration.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns the server host for this APIConfiguration.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Returns a list of APIMethodsEnum supported by this APIConfiguration.
        /// </summary>
        public IEnumerable<APIMethod> Methods => m_methods;

        /// <summary>
        /// Gets or sets a value indicating whether the provider supports compressed responses.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the provider supports compressed responses; otherwise, <c>false</c>.
        /// </value>
        public bool SupportsCompressedResponse
        {
            get { return IsDefault || this == TestProvider || m_supportsCompressedResponse; }
            set { m_supportsCompressedResponse = value; }
        }

        /// <summary>
        /// Returns true if this APIConfiguration represents the default API service.
        /// </summary>
        public bool IsDefault => this == DefaultProvider;

        /// <summary>
        /// Gets the default API provider
        /// </summary>
        public static APIProvider DefaultProvider
            => s_ccpProvider ??
               (s_ccpProvider = new EsiApiProvider
               {
                   Url = new Uri(NetworkConstants.APIBase),
                   Name = "CCP"
               });

        /// <summary>
        /// Gets the test API provider
        /// </summary>
        public static APIProvider TestProvider
            => s_ccpTestProvider ??
               (s_ccpTestProvider = new APIProvider
               {
                   Url = new Uri(NetworkConstants.APITestBase),
                   Name = "CCP Test API"
               });

        #endregion


        #region Helpers

        /// <summary>
        /// Returns the request method.
        /// </summary>
        /// <param name="requestMethod">An APIMethodsEnum enumeration member specifying the method for which the URL is required.</param>
        public APIMethod GetMethod(Enum requestMethod)
        {
            foreach (APIMethod method in m_methods.Where(method => method.Method.Equals(requestMethod)))
            {
                return method;
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the full canonical URL for the specified APIMethod as constructed from the Server and APIMethod properties.
        /// </summary>
        /// <param name="requestMethod">An APIMethodsEnum enumeration member specifying the method for which the URL is required.</param>
        /// <returns>A String representing the full URL path of the specified method.</returns>
        public Uri GetMethodUrl(Enum requestMethod)
        {
            // Gets the proper data
            Uri url = Url;
            string path = GetMethod(requestMethod).Path;
            if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(url.AbsoluteUri))
            {
                url = s_ccpProvider.Url;
                path = s_ccpProvider.GetMethod(requestMethod).Path;
            }

            // Build the uri
            Uri baseUri = url;
            UriBuilder uriBuilder = new UriBuilder(baseUri);
            uriBuilder.Path = Path.Combine(uriBuilder.Path, path);
            return uriBuilder.Uri;
        }

        #endregion


        #region Queries



        /// <summary>
        /// Query a method without arguments.
        /// </summary>
        /// <typeparam name="T">The type of the deserialization object.</typeparam>
        /// <param name="method"></param>
        /// <param name="callback">The callback to invoke once the query has been completed.</param>
        public void QueryMethodAsync<T>(Enum method, Action<CCPAPIResult<T>> callback)
        {
            QueryMethodAsync(method, callback, null, RowsetsTransform);
        }

        /// <summary>
        /// Query a method with the provided arguments for an API key.
        /// </summary>
        /// <typeparam name="T">The type of the deserialization object.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="keyId">The API key's ID</param>
        /// <param name="verificationCode">The API key's verification code</param>
        /// <param name="callback">The callback to invoke once the query has been completed.</param>
        public void QueryMethodAsync<T>(Enum method, long keyId, string verificationCode, Action<CCPAPIResult<T>> callback)
        {
            string postData = String.Format(CultureConstants.InvariantCulture, NetworkConstants.PostDataBase,
                keyId, verificationCode);
            QueryMethodAsync(method, callback, postData, RowsetsTransform);
        }

        /// <summary>
        /// Query a method with the provided arguments for a character.
        /// </summary>
        /// <typeparam name="T">The type of the deserialization object.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="keyId">The API key's ID</param>
        /// <param name="verificationCode">The API key's verification code</param>
        /// <param name="id">The character or corporation ID.</param>
        /// <param name="callback">The callback to invoke once the query has been completed.</param>
        /// <exception cref="System.ArgumentNullException">method</exception>
        public void QueryMethodAsync<T>(Enum method, long keyId, string verificationCode, long id,
            Action<CCPAPIResult<T>> callback)
        {
            method.ThrowIfNull(nameof(method));

            string postData = GetPostDataString(method, keyId, verificationCode, id);

            QueryMethodAsync(method, callback, postData, RowsetsTransform);
        }

        /// <summary>
        /// Query a method with the provided arguments for a character messages and contracts.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="keyId">The API key's ID</param>
        /// <param name="verificationCode">The API key's verification code</param>
        /// <param name="id">The character ID.</param>
        /// <param name="messageID">The message ID.</param>
        /// <param name="callback">The callback.</param>
        public void QueryMethodAsync<T>(Enum method, long keyId, string verificationCode, long id, long messageID,
            Action<CCPAPIResult<T>> callback)
        {
            string postData = String.Format(CultureConstants.InvariantCulture, GetPostDataFormat(method),
                keyId, verificationCode, id, messageID);
            QueryMethodAsync(method, callback, postData, RowsetsTransform);
        }

        /// <summary>
        /// Query a method with the provided arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="ids">The ids.</param>
        /// <param name="callback">The callback.</param>
        public void QueryMethodAsync<T>(Enum method, string ids, Action<CCPAPIResult<T>> callback)
        {
            string postData = String.Format(CultureConstants.InvariantCulture, NetworkConstants.PostDataIDsOnly,
                ids);
            QueryMethodAsync(method, callback, postData, RowsetsTransform);
        }

        #endregion


        #region Querying helpers

        /// <summary>
        /// Query this method with the provided HTTP POST data.
        /// </summary>
        /// <typeparam name="T">The subtype to deserialize (the deserialized type being <see cref="CCPAPIResult{T}"/>).</typeparam>
        /// <param name="method">The method to query</param>
        /// <param name="postData">The http POST data</param>
        /// <param name="transform">The XSL transform to apply, may be null.</param>
        /// <returns>The deserialized object</returns>
        private CCPAPIResult<T> QueryMethod<T>(Enum method, string postData, XslCompiledTransform transform)
        {
            // Download
            Uri url = GetMethodUrl(method);
            CCPAPIResult<T> result = Util.DownloadAPIResult<T>(url, SupportsCompressedResponse, postData, transform);

            // On failure with a custom method, fallback to CCP
            return ShouldRetryWithCCP(result) ? s_ccpProvider.QueryMethod<T>(method, postData, transform) : result;
        }

        /// <summary>
        /// Asynchrnoneously queries this method with the provided HTTP POST data.
        /// </summary>
        /// <typeparam name="T">The subtype to deserialize (the deserialized type being <see cref="CCPAPIResult{T}" />).</typeparam>
        /// <param name="method">The method to query</param>
        /// <param name="callback">The callback to invoke once the query has been completed.</param>
        /// <param name="postData">The http POST data</param>
        /// <param name="transform">The XSL transform to apply, may be null.</param>
        /// <exception cref="System.ArgumentNullException">callback; The callback cannot be null.</exception>
        protected virtual void QueryMethodAsync<T>(Enum method, Action<CCPAPIResult<T>> callback, string postData,
            XslCompiledTransform transform)
        {
            // Check callback not null
            callback.ThrowIfNull(nameof(callback), "The callback cannot be null.");

            // Lazy download
            Uri url = GetMethodUrl(method);

            Util.DownloadAPIResultAsync<T>(url, SupportsCompressedResponse, postData, transform)
                .ContinueWith(task =>
                {
                    // On failure with a custom provider, fallback to CCP
                    if (ShouldRetryWithCCP(task.Result))
                    {
                        APIProvider ccpProvider = EveMonClient.APIProviders.CurrentProvider.Url.Host != TestProvider.Url.Host
                            ? s_ccpProvider
                            : s_ccpTestProvider;
                        ccpProvider.QueryMethodAsync(method, callback, postData, transform);
                        return;
                    }

                    // Invokes the callback
                    Dispatcher.Invoke(() => callback.Invoke(task.Result));
                });
        }

        /// <summary>
        /// Checks whether the query must be retrieved with CCP as the default provider.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ShouldRetryWithCCP(IAPIResult result)
            => s_ccpProvider != this && s_ccpTestProvider != this && result.HasError &&
               result.ErrorType != CCPAPIErrors.CCP;

        /// <summary>
        /// Gets the post data string.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="keyId">The key identifier.</param>
        /// <param name="verificationCode">The verification code.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private static string GetPostDataString(Enum method, long keyId, string verificationCode, long id)
        {
            if (method.Equals(CCPAPICharacterMethods.CharacterInfo) && keyId == 0 && string.IsNullOrEmpty(verificationCode))
            {
                return String.Format(CultureConstants.InvariantCulture, NetworkConstants.PostDataCharacterIDOnly, id);
            }

            if (method.Equals(CCPAPICorporationMethods.CorporationSheet) && keyId == 0 && string.IsNullOrEmpty(verificationCode))
            {
                return String.Format(CultureConstants.InvariantCulture, NetworkConstants.PostDataCorporationIDOnly, id);
            }

            if (method.Equals(CCPAPICharacterMethods.WalletJournal) || method.Equals(CCPAPICharacterMethods.WalletTransactions))
            {
                return String.Format(CultureConstants.InvariantCulture, NetworkConstants.PostDataWithCharIDAndRowCount,
                    keyId, verificationCode, id, 2560);
            }

            return String.Format(CultureConstants.InvariantCulture, NetworkConstants.PostDataWithCharID,
                keyId, verificationCode, id);
        }

        /// <summary>
        /// Gets the post data format.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        private static string GetPostDataFormat(Enum method)
        {
            if (method.GetType() == typeof(CCPAPIGenericMethods))
            {
                if (method.ToString().Contains("Contract"))
                    return NetworkConstants.PostDataWithCharIDAndContractID;

                if (method.ToString().Contains("Planetary"))
                    return NetworkConstants.PostDataWithCharIDAndPlanetID;
            }

            return NetworkConstants.PostDataWithCharIDAndIDS;
        }

        /// <summary>
        /// Gets the XSLT used for transforming rowsets into something deserializable by <see cref="System.Xml.Serialization.XmlSerializer"/>
        /// </summary>
        internal static XslCompiledTransform RowsetsTransform
            => s_rowsetsTransform ?? (s_rowsetsTransform = Util.LoadXslt(Properties.Resources.RowsetsXSLT));

        #endregion


        /// <summary>
        /// Returns the configuration name as a String.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;
    }
}