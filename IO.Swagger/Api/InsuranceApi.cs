/* 
 * EVE Swagger Interface
 *
 * An OpenAPI for EVE Online
 *
 * OpenAPI spec version: 0.7.6
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IInsuranceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// List insurance levels
        /// </summary>
        /// <remarks>
        /// Return available insurance levels for all ship types  - --  This route is cached for up to 3600 seconds
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datasource">The server name you would like data from (optional, default to tranquility)</param>
        /// <param name="language">Language to use in the response (optional, default to en-us)</param>
        /// <param name="userAgent">Client identifier, takes precedence over headers (optional)</param>
        /// <param name="xUserAgent">Client identifier, takes precedence over User-Agent (optional)</param>
        /// <returns>List&lt;GetInsurancePrices200Ok&gt;</returns>
        List<GetInsurancePrices200Ok> GetInsurancePrices (string datasource = null, string language = null, string userAgent = null, string xUserAgent = null);

        /// <summary>
        /// List insurance levels
        /// </summary>
        /// <remarks>
        /// Return available insurance levels for all ship types  - --  This route is cached for up to 3600 seconds
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datasource">The server name you would like data from (optional, default to tranquility)</param>
        /// <param name="language">Language to use in the response (optional, default to en-us)</param>
        /// <param name="userAgent">Client identifier, takes precedence over headers (optional)</param>
        /// <param name="xUserAgent">Client identifier, takes precedence over User-Agent (optional)</param>
        /// <returns>ApiResponse of List&lt;GetInsurancePrices200Ok&gt;</returns>
        ApiResponse<List<GetInsurancePrices200Ok>> GetInsurancePricesWithHttpInfo (string datasource = null, string language = null, string userAgent = null, string xUserAgent = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// List insurance levels
        /// </summary>
        /// <remarks>
        /// Return available insurance levels for all ship types  - --  This route is cached for up to 3600 seconds
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datasource">The server name you would like data from (optional, default to tranquility)</param>
        /// <param name="language">Language to use in the response (optional, default to en-us)</param>
        /// <param name="userAgent">Client identifier, takes precedence over headers (optional)</param>
        /// <param name="xUserAgent">Client identifier, takes precedence over User-Agent (optional)</param>
        /// <returns>Task of List&lt;GetInsurancePrices200Ok&gt;</returns>
        System.Threading.Tasks.Task<List<GetInsurancePrices200Ok>> GetInsurancePricesAsync (string datasource = null, string language = null, string userAgent = null, string xUserAgent = null);

        /// <summary>
        /// List insurance levels
        /// </summary>
        /// <remarks>
        /// Return available insurance levels for all ship types  - --  This route is cached for up to 3600 seconds
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datasource">The server name you would like data from (optional, default to tranquility)</param>
        /// <param name="language">Language to use in the response (optional, default to en-us)</param>
        /// <param name="userAgent">Client identifier, takes precedence over headers (optional)</param>
        /// <param name="xUserAgent">Client identifier, takes precedence over User-Agent (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;GetInsurancePrices200Ok&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<GetInsurancePrices200Ok>>> GetInsurancePricesAsyncWithHttpInfo (string datasource = null, string language = null, string userAgent = null, string xUserAgent = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class InsuranceApi : IInsuranceApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsuranceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public InsuranceApi(String basePath)
        {
            this.Configuration = new IO.Swagger.Client.Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsuranceApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public InsuranceApi(IO.Swagger.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = IO.Swagger.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IO.Swagger.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// List insurance levels Return available insurance levels for all ship types  - --  This route is cached for up to 3600 seconds
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datasource">The server name you would like data from (optional, default to tranquility)</param>
        /// <param name="language">Language to use in the response (optional, default to en-us)</param>
        /// <param name="userAgent">Client identifier, takes precedence over headers (optional)</param>
        /// <param name="xUserAgent">Client identifier, takes precedence over User-Agent (optional)</param>
        /// <returns>List&lt;GetInsurancePrices200Ok&gt;</returns>
        public List<GetInsurancePrices200Ok> GetInsurancePrices (string datasource = null, string language = null, string userAgent = null, string xUserAgent = null)
        {
             ApiResponse<List<GetInsurancePrices200Ok>> localVarResponse = GetInsurancePricesWithHttpInfo(datasource, language, userAgent, xUserAgent);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List insurance levels Return available insurance levels for all ship types  - --  This route is cached for up to 3600 seconds
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datasource">The server name you would like data from (optional, default to tranquility)</param>
        /// <param name="language">Language to use in the response (optional, default to en-us)</param>
        /// <param name="userAgent">Client identifier, takes precedence over headers (optional)</param>
        /// <param name="xUserAgent">Client identifier, takes precedence over User-Agent (optional)</param>
        /// <returns>ApiResponse of List&lt;GetInsurancePrices200Ok&gt;</returns>
        public ApiResponse< List<GetInsurancePrices200Ok> > GetInsurancePricesWithHttpInfo (string datasource = null, string language = null, string userAgent = null, string xUserAgent = null)
        {

            var localVarPath = "/v1/insurance/prices/";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (datasource != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "datasource", datasource)); // query parameter
            if (language != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "language", language)); // query parameter
            if (userAgent != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "user_agent", userAgent)); // query parameter
            if (xUserAgent != null) localVarHeaderParams.Add("X-User-Agent", this.Configuration.ApiClient.ParameterToString(xUserAgent)); // header parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetInsurancePrices", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<GetInsurancePrices200Ok>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<GetInsurancePrices200Ok>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<GetInsurancePrices200Ok>)));
        }

        /// <summary>
        /// List insurance levels Return available insurance levels for all ship types  - --  This route is cached for up to 3600 seconds
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datasource">The server name you would like data from (optional, default to tranquility)</param>
        /// <param name="language">Language to use in the response (optional, default to en-us)</param>
        /// <param name="userAgent">Client identifier, takes precedence over headers (optional)</param>
        /// <param name="xUserAgent">Client identifier, takes precedence over User-Agent (optional)</param>
        /// <returns>Task of List&lt;GetInsurancePrices200Ok&gt;</returns>
        public async System.Threading.Tasks.Task<List<GetInsurancePrices200Ok>> GetInsurancePricesAsync (string datasource = null, string language = null, string userAgent = null, string xUserAgent = null)
        {
             ApiResponse<List<GetInsurancePrices200Ok>> localVarResponse = await GetInsurancePricesAsyncWithHttpInfo(datasource, language, userAgent, xUserAgent);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List insurance levels Return available insurance levels for all ship types  - --  This route is cached for up to 3600 seconds
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datasource">The server name you would like data from (optional, default to tranquility)</param>
        /// <param name="language">Language to use in the response (optional, default to en-us)</param>
        /// <param name="userAgent">Client identifier, takes precedence over headers (optional)</param>
        /// <param name="xUserAgent">Client identifier, takes precedence over User-Agent (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;GetInsurancePrices200Ok&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<GetInsurancePrices200Ok>>> GetInsurancePricesAsyncWithHttpInfo (string datasource = null, string language = null, string userAgent = null, string xUserAgent = null)
        {

            var localVarPath = "/v1/insurance/prices/";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (datasource != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "datasource", datasource)); // query parameter
            if (language != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "language", language)); // query parameter
            if (userAgent != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "user_agent", userAgent)); // query parameter
            if (xUserAgent != null) localVarHeaderParams.Add("X-User-Agent", this.Configuration.ApiClient.ParameterToString(xUserAgent)); // header parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetInsurancePrices", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<GetInsurancePrices200Ok>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<GetInsurancePrices200Ok>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<GetInsurancePrices200Ok>)));
        }

    }
}