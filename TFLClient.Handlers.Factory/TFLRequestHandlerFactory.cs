using System;
using TFLClient.Exceptions;
using TFLClient.Handlers.Interface;
using static TFLClient.Common.Enums;

namespace TFLClient.Handlers.Factory
{
    /// <summary>
    /// This class acts as a Factory and is responsible for creating 
    /// the required handler based on the input API Method
    /// </summary>
    public static class TFLRequestHandlerFactory
    {
        /// <summary>
        /// Creates the TFL request handler.
        /// </summary>
        /// <param name="apiArguments">The API arguments.</param>
        /// <returns>
        /// The Handler for processing the API request
        /// </returns>
        /// <exception cref="TFLClient.Exceptions.TFLGenericException">Invalid API method specified!!</exception>
        public static IHandleTFLBaseInfoRequest CreateTFLRequestHandler(string[] apiArguments)
        {
            ApiCodes apiCode = ApiCodes.None;

            if(apiArguments.Length == 0)
            {
                // Throw a TFLGenericException since there are no arguments passed in
                throw new TFLGenericException(
                    "The parameters are not specified as inputs",
                    ErrorCodes.EmptyParameters
                );
            }

            // Trying to parse the API code passed in as argument
            if (Enum.TryParse<ApiCodes>(apiArguments[0], out apiCode))
            {
                switch (apiCode)
                {
                    // To retrieve the Road Status
                    case ApiCodes.RoadStatus:
                        // Invoking the RoadInfo request handler
                        return new TFLRoadInfoRequestHandler(apiArguments);
                }
            }

            // Throw a TFLGenericException since the argument passed-in couldn't align 
            // with a valid API method
            throw new TFLGenericException(
                "Couldn't find a suitable handler. Invalid API method specified!!", 
                ErrorCodes.InvalidAPIMethod
            );
        }
    }
}
