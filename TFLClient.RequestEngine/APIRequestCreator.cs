using System;
using System.IO;
using System.Net;
using TFLClient.Common;

namespace TFLClient.RequestEngine
{
    /// <summary>
    /// The class responsible for creating a web request to the API
    /// </summary>
    public static class APIRequestCreator
    {
        #region Public Methods

        /// <summary>
        /// Invokes the get request.
        /// </summary>
        /// <param name="apiUrl">The API URL.</param>
        /// <returns>
        /// The result from the API call
        /// </returns>
        public static string InvokeGetRequest(string apiUrl)
        {
            // Creating a web request to the API URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);

            // Setting the method type
            request.Method = "GET";

            // Setting the User agent
            request.UserAgent = AppSettingsReader.UserAgent;

            // Settting the automatic decompression
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            // Setting the security protocol
            ServicePointManager.SecurityProtocol = 
                SecurityProtocolType.Tls | 
                SecurityProtocolType.Tls11 | 
                SecurityProtocolType.Tls12;

            // Skip validation of SSL/TLS certificate
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // Invoking the API
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // If the content contains the identifier for Unauthorised access,
            // throw the UnauthorisedAccessException
            if (response.ResponseUri.ToString().Contains(AppSettingsReader.ResponseUriForUnauthorisedAccess))
            {
                throw new UnauthorizedAccessException("Access is unauthorised!!");
            }

            // Reading from the response stream to extract the content
            string content = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            // Returning the final result
            return content;
        }

        #endregion
    }
}
