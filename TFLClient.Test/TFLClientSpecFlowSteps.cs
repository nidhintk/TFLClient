using NUnit.Framework;
using TechTalk.SpecFlow;
using TFLClient.RequestProcessor;
using TFLClient.ResourceManager;

namespace TFLClient.SpecFlow.Test
{
    /// <summary>
    /// The test class for testing different scenarios
    /// </summary>
    [Binding]
    public class TFLClientSpecFlowSteps
    {
        /// <summary>
        /// The arguments for test
        /// </summary>
        string[] args;

        /// <summary>
        /// The output text
        /// </summary>
        string outputText;

        /// <summary>
        /// The expected output text
        /// </summary>
        string expectedOutputText;

        /// <summary>
        /// Given the user doesnot pass in any parameters.
        /// </summary>
        [Given(@"The user doesnot pass in any parameters")]
        public void GivenTheUserDoesnotPassInAnyParameters()
        {
            args = new string[0];
            expectedOutputText = 
                ResourceBuilder.GetResourceText("TflApiRequestErrorCodeException_EmptyParameters");
        }

        /// <summary>
        /// Given the user passes in an invalid API method.
        /// </summary>
        [Given(@"The user passes in an invalid API Method")]
        public void GivenTheUserPassesInAnInvalidAPIMethod()
        {
            args = new string[1];
            args[0] = "RoadStatu";
            expectedOutputText =
                ResourceBuilder.GetResourceText(
                    "TflApiRequestErrorCodeException_InvalidAPIMethod"
                ).Replace("{apiMethod}", args[0]);
        }

        /// <summary>
        /// Given the user passes in a valid API method without any parameters.
        /// </summary>
        [Given(@"The user passes in a valid API Method without any parameters")]
        public void GivenTheUserPassesInAValidAPIMethodWithoutAnyParameters()
        {
            args = new string[1];
            args[0] = "RoadStatus";
            expectedOutputText =
                ResourceBuilder.GetResourceText(
                    "TflApiRequestErrorCodeException_InvalidAPIParameters"
                ).Replace("{apiMethod}", args[0]);
        }

        /// <summary>
        /// Given the user passes in a valid API method with an invalid parameter.
        /// </summary>
        [Given(@"The user passes in a valid API Method with an invalid parameter")]
        public void GivenTheUserPassesInAValidAPIMethodWithAnInvalidParameter()
        {
            args = new string[2];
            args[0] = "RoadStatus";
            args[1] = "M4";
            expectedOutputText =
                string.Format(
                    ResourceBuilder.GetResourceText(
                        "TflApiRequestErrorCodeException_GetRoadStatus_RoadNotFound"
                    ), args[1]
                );
        }

        /// <summary>
        /// Given the user passes in a valid API method with an invalid parameter that breaks the API.
        /// </summary>
        [Given(@"The user passes in a valid API Method with an invalid parameter that breaks the API")]
        public void GivenTheUserPassesInAValidAPIMethodWithAnInvalidParameterThatBreaksTheApi()
        {
            args = new string[2];
            args[0] = "RoadStatus";
            args[1] = ".";
            expectedOutputText = "Generic Error: ";
        }

        /// <summary>
        /// Given the user invokes the road status API with a2 as the road code.
        /// </summary>
        [Given(@"The user invokes the RoadStatus API with A2 as the road code")]
        public void GivenTheUserInvokesTheRoadStatusApiWithA2AsTheRoadCode()
        {
            args = new string[2];
            args[0] = "RoadStatus";
            args[1] = "A2";
            expectedOutputText = "The status of the A2 is as follows";
        }

        /// <summary>
        /// Given the user is unauthorised.
        /// </summary>
        [Given(@"The User Is Unauthorised")]
        public void GivenTheUserIsUnauthorised()
        {
            System.Configuration.ConfigurationManager.AppSettings["appId"] = "randomId";

            args = new string[2];
            args[0] = "RoadStatus";
            args[1] = "A2";
            expectedOutputText =
                ResourceBuilder.GetResourceText(
                    "TflApiRequestErrorCodeException_ApiCredentialsError"
                );
        }

        /// <summary>
        /// When the TFL client is run.
        /// </summary>
        [When(@"The TFLClient is run")]
        public void WhenTheTFLClientIsRun()
        {
            int exitCode = 0;

            // Initiating the request passing in the arguments
            RequestInitiator.InitiateRequest(args, out outputText, out exitCode);
        }

        /// <summary>
        /// Then the correct validation message should be displayed on screen.
        /// </summary>
        [Then(@"The correct validation message should be displayed on screen")]
        public void ThenTheCorrectValidationMessageShouldBeDisplayedOnScreen()
        {
            Assert.AreEqual(outputText, expectedOutputText);
        }

        /// <summary>
        /// Then the road status information for A2 road should be displayed on screen.
        /// </summary>
        [Then(@"The generic error message should be displayed on screen")]
        public void ThenTheGenericErrorMessageShouldBeDisplayedOnScreen()
        {
            Assert.IsTrue(outputText.Contains(expectedOutputText));
        }

        /// <summary>
        /// Then the road status information for A2 road should be displayed on screen.
        /// </summary>
        [Then(@"The road status information for A2 road should be displayed on screen")]
        public void ThenTheRoadStatusInformationForA2RoadShouldBeDisplayedOnScreen()
        {
            Assert.IsTrue(outputText.Contains(expectedOutputText));
        }
    }
}
