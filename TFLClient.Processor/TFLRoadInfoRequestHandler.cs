using System;
using System.Net;
using TFLClient.Common;
using TFLClient.Exceptions;
using TFLClient.Handlers.Interface;
using TFLClient.RequestEngine;
using static TFLClient.Common.Enums;

namespace TFLClient.Handlers
{
    /// <summary>
    /// The class responsible for processing the requests to the TFL API
    /// for retrieving different sets of information on the Roads
    /// </summary>
    public class TFLRoadInfoRequestHandler: TFLBaseInfoRequestHandler, IHandleTFLRoadInfoRequest
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TFLRoadInfoRequestHandler"/> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        public TFLRoadInfoRequestHandler(string[] arguments)
            : base(arguments)
        {
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the road status.
        /// </summary>
        /// <param name="roadCode">The road code.</param>
        /// <returns>The road status information</returns>
        private string GetRoadStatus(string roadCode)
        {
            try
            {
                string[] urlParams = new string[1];
                urlParams[0] = roadCode;

                return APIRequestCreator.InvokeGetRequest(UrlManager.ConstructAPIUrl(Enums.ApiCodes.RoadStatus, urlParams));
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new TFLApiUnauthorisedAccessException(ex);
            }
            catch (WebException ex)
            {
                throw new TFLApiRequestException("GetRoadStatus", Enums.ApiCodes.RoadStatus, ex);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <returns>
        /// The API result
        /// </returns>
        /// <exception cref="TFLClient.Exceptions.TFLGenericException">Couldn't find a suitable handler method. Method missing for the specified API code</exception>
        public override string HandleRequest()
        {
            switch (this.GetApiCode()) {
                case Enums.ApiCodes.RoadStatus:

                    // If the argument is invalid, throw a generic exception
                    if (this.Arguments.Length <= 1)
                    {
                        throw new TFLGenericException("Parameter cannot be null or empty", ErrorCodes.InvalidAPIParameters);
                    }

                    return this.GetRoadStatus(this.Arguments[1]);
            }

            throw new TFLGenericException("Couldn't find a suitable handler method. Method missing for the specified API code", ErrorCodes.InvalidAPIMethod);
        }

        /// <summary>
        /// Gets the API code.
        /// </summary>
        /// <returns>
        /// The API code
        /// </returns>
        public override ApiCodes GetApiCode()
        {
            ApiCodes apiCode = ApiCodes.None;
            Enum.TryParse<Enums.ApiCodes>(this.Arguments[0], out apiCode);
            return apiCode;
        }

        #endregion
    }
}
