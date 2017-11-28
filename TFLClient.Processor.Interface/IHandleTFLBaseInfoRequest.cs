using static TFLClient.Common.Enums;

namespace TFLClient.Handlers.Interface
{
    /// <summary>
    /// The base interface for a handler
    /// </summary>
    public interface IHandleTFLBaseInfoRequest
    {
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <returns>The result from the API call</returns>
        string HandleRequest();

        /// <summary>
        /// Gets the API code.
        /// </summary>
        /// <returns>The API code</returns>
        ApiCodes GetApiCode();
    }
}
