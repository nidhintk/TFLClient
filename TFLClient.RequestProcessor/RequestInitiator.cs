using System;
using TFLClient.Exceptions;
using TFLClient.Handlers.Factory;
using TFLClient.Handlers.Interface;
using TFLClient.ResourceManager;

namespace TFLClient.RequestProcessor
{
    /// <summary>
    /// This class serves as the first point to initiate the API request
    /// Having a separate class for the initiation helps to aid for a proper unit testing as well
    /// </summary>
    public class RequestInitiator
    {
        #region Public Methods

        /// <summary>
        /// The entry point for the command line TFL request tool
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void InitiateRequest(string[] args, out string outputText, out int exitCode)
        {
            outputText = string.Empty;
            exitCode = 0;

            try
            {
                // Invoking the handler factory to create the required handler
                IHandleTFLBaseInfoRequest requestHandler = 
                    TFLRequestHandlerFactory.CreateTFLRequestHandler(args);

                // Invoking the request method of the handler
                // This method in-turn invokes the API call and returns the result
                string apiResult = requestHandler.HandleRequest();

                // The returned result is passed to the ResourceManager who constructs
                // the result text
                outputText = ResourceBuilder.GetResultText(
                        requestHandler.GetApiCode(),
                        apiResult
                    );

                // Exiting the program with success
                exitCode = 0;
            }
            catch (TFLApiRequestException ex)
            {
                // This block handles the errors related to the TFL API 
                // requests thrown from the API
                // For eg: Trying to query the API for a road status passing 
                // in an invalid RoadCode
                outputText = ResourceBuilder.GetApiRequestExceptionText(ex, args);

                // Exiting the program with failure
                exitCode = 1;
            }
            catch (TFLApiUnauthorisedAccessException ex)
            {
                // This block handles any access issues with the TFL API
                // For eg: An unauthorised exception when trying to access the API
                // A generic exception text is then displayed based on the TFL Error Code
                outputText = ResourceBuilder.GetGenericExceptionText(ex, args);

                // Exiting the program with failure
                exitCode = 1;
            }
            catch (TFLGenericException ex)
            {
                // This block handles any generic issues with the TFL Client.
                // For eg: A user trying to input an invalid API method as the parameter
                // A generic exception text is then displayed based on the TFL Error Code
                outputText = ResourceBuilder.GetGenericExceptionText(ex, args);

                // Exiting the program with failure
                exitCode = 1;
            }
            catch (Exception ex)
            {
                // Setting the Exception message to the output
                outputText = "Generic Error: " + ex.Message;

                // Exiting the program with failure
                exitCode = 1;
            }
        }

        #endregion
    }
}
