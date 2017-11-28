using System.Collections.Generic;
using System.Linq;
using TFLClient.Common;
using TFLClient.Exceptions.Interface;
using static TFLClient.Common.Enums;

namespace TFLClient.ResourceManager
{
    /// <summary>
    /// The class for managing the output text to be shown for the different inputs 
    /// given to the TFlClient program.
    /// </summary>
    public static class ResourceBuilder
    {
        #region Public Methods

        /// <summary>
        /// Gets the resource text.
        /// </summary>
        /// <param name="resourceKey">The resource key.</param>
        /// <returns>The resource text for the key</returns>
        public static string GetResourceText(string resourceKey)
        {
            return TFLClientResources.ResourceManager.GetString(resourceKey);
        }

        /// <summary>
        /// Gets the API result final output
        /// </summary>
        /// <param name="apicode">The apicode for the API method invoked.</param>
        /// <param name="apiJsonResult">The JSON result returned from the API.</param>
        /// <returns>
        /// The final output text based on the API result
        /// </returns>
        public static string GetResultText(ApiCodes apicode, string apiJsonResult)
        {
            string output = TFLClientResources.ResourceManager.GetString("TflApiResult_" + apicode);

            switch (apicode)
            {
                // If current API method is to get the Road Status
                case ApiCodes.RoadStatus:

                    // Extracting the dynamic parameters from the result text to be shown.
                    IEnumerable<string> requiredData = output.ExtractParametersWithinBraces();

                    // If there does exist any dynamic parameters
                    if (requiredData.Count() > 0)
                    {
                        // Invoking the extension method implemented on the String class to
                        // parse the JSON string and extract the data dictionary to fill in the
                        // dynamic parameters in the final output text.
                        IDictionary<string, string> parsedData = 
                            apiJsonResult.ParseToDictionary(requiredData);
                        
                        // From the above obtained data dictionary, formatting the final output text.
                        return output.FormatFromDictionary(parsedData);
                    }
                    else
                    {
                        // If there exist no dynamic parameters, simply return the text from
                        // the resource file.
                        return output;
                    }
                default:
                    return string.Empty;
            }
        }

        #region Exception handling texts

        /// <summary>
        /// Gets the exception text specifying to API issues.
        /// </summary>
        /// <param name="ex">The exception</param>
        /// <param name="args">The arguments.</param>
        /// <returns>
        /// The error to be shown for any API related issues
        /// </returns>
        public static string GetApiRequestExceptionText(ITFLApiRequestException ex, IEnumerable<string> args)
        {
            string output = TFLClientResources.ResourceManager.GetString(
                "TflApiRequestErrorCodeException_" + ex.GetMethodName() + "_" + ex.GetErrorCode()
            );

            switch (ex.GetErrorCode())
            {
                // The error code raised when a road status is being enquired
                // with the API and the API couldn't find the road
                case ErrorCodes.RoadNotFound:

                    // Extracting the dynamic parameters from the result text to be shown.
                    IList<string> requiredData = output.ExtractParametersWithinBraces().ToList<string>();
                    
                    // If there does exist any dynamic parameters
                    if (requiredData.Count() > 0)
                    {
                        IDictionary<string, string> argsDictionary = new Dictionary<string, string>();
                        argsDictionary.Add(requiredData[0], args.ToArray()[1]);

                        return output.FormatFromDictionary(argsDictionary);
                    }
                    else
                    {
                        return output;
                    }
                default:
                    return output;
            }
        }

        /// <summary>
        /// Gets the generic exception text.
        /// </summary>
        /// <param name="ex">The exception</param>
        /// <param name="args">The arguments.</param>
        /// <returns>
        /// The error to be shown for any generic errors
        /// </returns>
        public static string GetGenericExceptionText(ITFLBaseException ex, IEnumerable<string> args)
        {
            string output = TFLClientResources.ResourceManager.GetString(
                "TflApiRequestErrorCodeException_" + ex.GetErrorCode()
            );

            switch (ex.GetErrorCode())
            {
                case ErrorCodes.InvalidAPIMethod:
                case ErrorCodes.InvalidAPIParameters:
                    IList<string> requiredData = output.ExtractParametersWithinBraces().ToList<string>();

                    if (requiredData.Count() > 0)
                    {
                        IDictionary<string, string> argsDictionary = new Dictionary<string, string>();
                        argsDictionary.Add(requiredData[0], args.ToArray()[0]);

                        return output.FormatFromDictionary(argsDictionary);
                    }
                    else
                    {
                        return output;
                    }
                case ErrorCodes.EmptyParameters:
                default:
                    return output;
            }            
        }

        #endregion Exception handling texts

        #endregion Public Methods
    }
}
