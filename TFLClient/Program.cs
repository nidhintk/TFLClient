using System;
using TFLClient.RequestProcessor;

namespace TFLClient
{
    /// <summary>
    /// The command line program for communicating to the TFL API
    /// </summary>
    public class Program
    {
        #region Start point

        /// <summary>
        /// The entry point for the command line TFL request tool
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            string outputText = string.Empty;
            int exitCode = 0;

            // Initiating request
            RequestInitiator.InitiateRequest(args, out outputText, out exitCode);

            // Writing the output text to the console
            Console.WriteLine(outputText);

            // Setting the exit code
            Environment.Exit(exitCode);
        }

        #endregion
    }
}
