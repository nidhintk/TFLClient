using System;
using TFLClient.Exceptions.Interface;
using static TFLClient.Common.Enums;

namespace TFLClient.Exceptions
{
    /// <summary>
    /// The class representing any generic TFL Client exceptions
    /// </summary>
    /// <seealso cref="System.Exception" />
    /// <seealso cref="TFLClient.Exceptions.Interface.ITFLBaseException" />
    public class TFLGenericException : Exception, ITFLBaseException
    {
        #region Private Members

        /// <summary>
        /// The error code
        /// </summary>
        private ErrorCodes errorCode;

        /// <summary>
        /// The API code
        /// </summary>
        private ApiCodes apiCode;

        #endregion Private Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TFLGenericException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public TFLGenericException(string message, ErrorCodes errorCode) : 
            base(message)
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <returns>The TFL generic error code</returns>
        public ErrorCodes GetErrorCode()
        {
            return this.errorCode;
        }

        #endregion
    }
}
