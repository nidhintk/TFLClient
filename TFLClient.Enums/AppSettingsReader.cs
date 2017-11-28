using System.Text;
using static TFLClient.Common.Enums;

namespace TFLClient.Common
{
    /// <summary>
    /// The common class for reading Application settings
    /// </summary>
    public static class AppSettingsReader
    {
        #region Private Properties

        /// <summary>
        /// Gets the API URL.
        /// </summary>
        /// <value>
        /// The API URL.
        /// </value>
        private static string ApiUrl
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["TFLApi"];
            }
        }

        /// <summary>
        /// Gets the API parameters.
        /// </summary>
        /// <value>
        /// The API parameters.
        /// </value>
        private static string ApiParams
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["TFLApiParams"];
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the API URL with parameters.
        /// </summary>
        /// <value>
        /// The API URL with parameters.
        /// </value>
        public static string ApiUrlWithParams
        {
            get
            {
                return new StringBuilder(ApiUrl).Append(ApiParams).ToString();
            }
        }

        /// <summary>
        /// Gets the user agent.
        /// </summary>
        /// <value>
        /// The user agent.
        /// </value>
        public static string UserAgent
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["userAgentString"];
            }
        }

        /// <summary>
        /// Gets the application key.
        /// </summary>
        /// <value>
        /// The application key.
        /// </value>
        public static string AppKey
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["appKey"];
            }
        }

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public static string AppId
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["appId"];
            }
        }
        
        /// <summary>
        /// Gets the response URI for unauthorised access.
        /// </summary>
        /// <value>
        /// The response URI for unauthorised access.
        /// </value>
        public static string ResponseUriForUnauthorisedAccess
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["unauthorisedUri"];
            }
        }        

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the API method format.
        /// </summary>
        /// <param name="apicode">The apicode.</param>
        /// <returns>The API Method format from the config file</returns>
        public static string GetApiMethodFormat(ApiCodes apicode)
        {
            switch (apicode)
            {
                case ApiCodes.RoadStatus:
                    return System.Configuration.ConfigurationSettings.AppSettings[apicode.ToString()];
                default:
                    return string.Empty;
            }
        }

        #endregion
    }
}
