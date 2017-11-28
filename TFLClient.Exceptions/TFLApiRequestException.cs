using System.Net;
using TFLClient.Common;
using TFLClient.Exceptions.Interface;
using static TFLClient.Common.Enums;

namespace TFLClient.Exceptions
{
    /// <summary>
    /// The class representing any TFL API internal exception
    /// </summary>
    /// <seealso cref="System.Net.WebException" />
    /// <seealso cref="TFLClient.Exceptions.Interface.ITFLApiRequestException" />
    public class TFLApiRequestException: WebException, ITFLApiRequestException
    {
        #region Private Members

        /// <summary>
        /// The method name
        /// </summary>
        private string methodName;

        /// <summary>
        /// The API code
        /// </summary>
        private ApiCodes apiCode;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TFLApiRequestException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public TFLApiRequestException(string methodName, ApiCodes apiCode, WebException ex) : 
            base(ex.Message, ex.InnerException, ex.Status, ex.Response)
        {
            this.methodName = methodName;
            this.apiCode = apiCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <returns>The Error code corresponding to the HTTPStatuscode</returns>
        public ErrorCodes GetErrorCode()
        {
            switch ((this.Response as HttpWebResponse).StatusCode)
            {
                case HttpStatusCode.NotFound:
                    switch (this.apiCode)
                    {
                        case ApiCodes.RoadStatus:
                            return ErrorCodes.RoadNotFound;
                        default:
                            methodName = "Generic";
                            return ErrorCodes.InvalidAPIMethod;
                    }
                case HttpStatusCode.InternalServerError:
                default:
                    methodName = "Generic";
                    return ErrorCodes.ApiInternalError;
            }
        }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        /// <returns>
        /// The method name which caused the exception
        /// </returns>
        public string GetMethodName()
        {
            return this.methodName;
        }

        #endregion
    }
}
