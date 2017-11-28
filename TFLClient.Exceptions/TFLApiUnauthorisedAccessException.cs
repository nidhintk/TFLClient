using System;
using TFLClient.Exceptions.Interface;
using static TFLClient.Common.Enums;

namespace TFLClient.Exceptions
{
    /// <summary>
    /// The class representing the TFL unauthorised access exception
    /// </summary>
    /// <seealso cref="System.UnauthorizedAccessException" />
    /// <seealso cref="TFLClient.Exceptions.Interface.ITFLBaseException" />
    public class TFLApiUnauthorisedAccessException : UnauthorizedAccessException, ITFLBaseException
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TFLApiUnauthorisedAccessException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public TFLApiUnauthorisedAccessException(UnauthorizedAccessException ex) : 
            base(ex.Message, ex.InnerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TFLApiUnauthorisedAccessException"/> class.
        /// </summary>
        public TFLApiUnauthorisedAccessException()
        {
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <returns>The TFL error code for Unauthorised Exception</returns>
        public ErrorCodes GetErrorCode()
        {
            return ErrorCodes.ApiCredentialsError;
        }

        #endregion
    }
}
