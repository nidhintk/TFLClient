namespace TFLClient.Common
{
    /// <summary>
    /// The common Enums class
    /// </summary>
    public class Enums
    {
        #region Enums

        /// <summary>
        /// Enums for the error codes thrown from the TFL API
        /// </summary>
        public enum ErrorCodes
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,

            /// <summary>
            /// The road not found
            /// </summary>
            RoadNotFound = 1,

            /// <summary>
            /// The empty parameters
            /// </summary>
            EmptyParameters = 1000,

            /// <summary>
            /// The invalid API Method
            /// </summary>
            InvalidAPIMethod = 1001,

            /// <summary>
            /// The invalid API Parameters
            /// </summary>
            InvalidAPIParameters = 1002,

            /// <summary>
            /// The API internal error
            /// </summary>
            ApiInternalError = 1003,

            /// <summary>
            /// The API credentials error
            /// </summary>
            ApiCredentialsError = 1004
        }

        /// <summary>
        /// Enums for representing the API calls
        /// </summary>
        public enum ApiCodes
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,

            /// <summary>
            /// The road status
            /// </summary>
            RoadStatus = 1
        }

        #endregion
    }
}
