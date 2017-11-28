using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TFLClient.Common
{
    /// <summary>
    /// An extension class for System.string
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Formats the text replacing the words within braces with the corresponding value from the
        /// parameters dictionary.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// The formatted string
        /// </returns>
        public static string FormatFromDictionary(this string text, IDictionary<string, string> parameters)
        {
            // Looping through each dynamic parameter
            foreach(var item in parameters)
            {
                text = text.Replace("{" + item.Key + "}", item.Value);
            }

            // Returning the formatted text
            return text;
        }


        /// <summary>
        /// Retrieves the dynamic parameters from the resource text.
        /// It gets all the words enclosed between '{ and '}'
        /// </summary>
        /// <param name="resourceText">The resource text.</param>
        /// <returns>
        /// The list of data required to be parsed from JSON
        /// </returns>
        public static IEnumerable<string> ExtractParametersWithinBraces(this string resourceText)
        {
            int openBracketIndex = 0;
            int closedBracketIndex = 0;
            int currentIndex = 0;
            IList<string> dataToBeParsedFromJson = new List<string>();

            // While open bracket does exist
            while (openBracketIndex != -1)
            {
                // Find the index of the next '{' from the current Index position
                openBracketIndex = resourceText.IndexOf('{', currentIndex);

                // If there definitely exist a next '{' bracket
                if (openBracketIndex != -1)
                {
                    // Find the index of the '}' corresponding to the current '{'
                    closedBracketIndex = resourceText.IndexOf('}', openBracketIndex);

                    // Extracting the word between '{' and '}' and then adding to
                    // the list of dynamic parameters
                    dataToBeParsedFromJson.Add(
                        resourceText.Substring(
                            openBracketIndex + 1,
                            closedBracketIndex - (openBracketIndex + 1)
                        )
                    );

                    // Setting the current Index to the closed bracket index plus one
                    // This will enable to find the next open bracket, when the loop runs again
                    currentIndex = closedBracketIndex + 1;
                }
            }

            // Returning the dynamic parameters list
            return dataToBeParsedFromJson;
        }

        /// <summary>
        /// Parses the string to obtain the values corresponding to the argument keys passed in
        /// These parsed values are then returned back in a dictionary form.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>
        /// The list of values parsed from JSON
        /// </returns>
        public static IDictionary<string, string> ParseToDictionary(this string text, IEnumerable<string> args)
        {
            // Initialising the dictionary
            IDictionary<string, string> parsedDictionary = new Dictionary<string, string>();

            // Parsing the text to a JSON ensuring that any characters
            // before the JSON text and after the JSON text are ignored
            string json = text.ParseToJson();

            // Parsing the JSON string to a JSON object
            JToken token = JObject.Parse(json);

            // Looping through each of the arguments and finding them in the JSON object
            // These key/values are added to a dictionary
            foreach (string arg in args)
            {
                parsedDictionary.Add(arg, (string)token.SelectToken(arg));
            }

            // Returned back the final dictionary containing the key value pairs
            return parsedDictionary;
        }

        /// <summary>
        /// Parses to json.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>The string parsed to JSON data</returns>
        public static string ParseToJson(this string text)
        {
            int firstOpenBracketIndex = text.IndexOf('{');
            int lastClosedBracketIndex = text.LastIndexOf('}');
            
            // Returning the text between the first open bracket and last closed bracket
            return text.Substring(
                firstOpenBracketIndex, 
                (lastClosedBracketIndex - firstOpenBracketIndex) + 1
            );
        }
    }
}
