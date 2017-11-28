using System;
using static TFLClient.Common.Enums;
using appReader = TFLClient.Common.AppSettingsReader;

namespace TFLClient.Common
{
    /// <summary>
    /// The common class for managing URL construction
    /// </summary>
    public static class UrlManager
    {
        #region Public methods

        /// <summary>
        /// Constructs the API URL.
        /// </summary>
        /// <returns>The constructed URL</returns>
        public static string ConstructAPIUrl(ApiCodes apicode, string[] urlParams)
        {
            string apiMethod = string.Format(appReader.GetApiMethodFormat(apicode), urlParams);

            if (string.IsNullOrEmpty(apiMethod))
            {
                throw new ArgumentNullException(string.Format("There's no API Method format configured for the passed Apicode: {0}", apicode.ToString()));
            }

            return string.Format(
                appReader.ApiUrlWithParams,
                apiMethod,
                appReader.AppId,
                appReader.AppKey);
        }

        #endregion
    }
}
