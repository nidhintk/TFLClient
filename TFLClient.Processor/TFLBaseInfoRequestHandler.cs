using TFLClient.Handlers.Interface;
using static TFLClient.Common.Enums;

namespace TFLClient.Handlers
{
    /// <summary>
    /// This is an abstract base class which holds the common fields required
    /// for the handlers
    /// </summary>
    public abstract class TFLBaseInfoRequestHandler : IHandleTFLBaseInfoRequest
    {
        /// <summary>
        /// The arguments passed from the client are stored in the handler itself
        /// </summary>
        private string[] arguments;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        protected string[] Arguments
        {
            get
            {
                return this.arguments;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TFLBaseInfoRequestHandler"/> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        public TFLBaseInfoRequestHandler(string[] arguments)
        {
            this.arguments = arguments;
        }

        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <returns>The API result</returns>
        public abstract string HandleRequest();

        /// <summary>
        /// Gets the API code.
        /// </summary>
        /// <returns>The API code</returns>
        public abstract ApiCodes GetApiCode();
    }
}
