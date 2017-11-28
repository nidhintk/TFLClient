namespace TFLClient.Exceptions.Interface
{
    /// <summary>
    /// The common interface for TFL API Request exceptions
    /// </summary>
    public interface ITFLApiRequestException : ITFLBaseException
    {
        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        /// <returns>The method name which caused the exception</returns>
        string GetMethodName();
    }
}
