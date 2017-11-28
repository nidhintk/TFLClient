using static TFLClient.Common.Enums;

namespace TFLClient.Exceptions.Interface
{
    /// <summary>
    /// The common interface for TFL base exceptions
    /// </summary>
    public interface ITFLBaseException
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <returns>The TFL errorcode</returns>
        ErrorCodes GetErrorCode();
    }
}
