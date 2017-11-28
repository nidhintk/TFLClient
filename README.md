# TFLClient

TFLClient is a command line tool created in C#. It helps to invoke a TFL API from the command line.
The current version supports the following API:

	* RoadStatus

## Building the code

The application uses .Net framework 4.5.2 and is developed in Microsoft Visual Studio 2015.
It can be built through Visual Studio.

It relies on the Nuget package manager to download the following supporting libraries:

	* For the application to run:
		- Newtonsoft.Json

	* For the BDD tests to run:
		- Newtonsoft.Json
		- Nunit
		- SpecFlow

All these packages shall be automatically downloaded and installed when the application is built through Visual Studio.

## Running the output

Once the application is built as explained above, the TFLClient.exe shall be created under the bin/Release or bin/Debug folder.

Type in the following in the commandline after navigating to the folder containing the TFLClient.exe file to invoke the current supported APIs:

	* RoadStatus
		Eg: .\TFLClient.exe RoadStatus A2

		The first parameter 'RoadStatus' helps to identify the API method to be invoked.
		The second parameter 'A2' represents the code for the road for which the status is to be known.

		If an invalid API method is specified or invalid parameters are specified, the application throws the relevant error
		message to notify the user.

## Running the tests

The tests are written in a BDD way. Specflow library is used to align with the BDD model.

The tests can again be run through Visual Studio itself. 
Load the solution and then open the 'Test Explorer' from the 'Test' menu.
You have the option to either run all at a time or one at a time selecting a test.

The TFLClientSpecFlow.feature file explains all the scenarios covered with the tests in the Gherkin language. It's a business readable,
domain specific language that lets you describe software behaviour without detailing how that behaviour is implemented.

	Eg: Feature: Invoke a TFL API
		In order to invoke a TFL API
		As a user who wants to know transport information
		I want to be told the transport information

	Scenario: Invoke without passing any parameters
		Given The user doesnot pass in any parameters
		When The TFLClient is run
		Then The correct validation message should be displayed on screen 

## Assumptions

	(i)		Assumed that the software required is not just to cater for the RoadStatus API alone. 
			The whole framework supports extensibility and can be modified very easily to support further APIs.
	(ii)	Assumed that the App.config file should hold the following application settings:
				(a)	TFLApi: The value represents the API host URL with a {0} at the end to represent the API method
				(b)	TFLApiParams: The value represents the params to be passed along with the URL. Currently it's the API key 
					and App Id.
				(c) appId: The AppId issued from TFL for your authorisation with the API instance.
				(d) appKey: The AppKey issued from TFL for your authorisation with the API instance.
				(e) userAgentString: The useragent string to be used internally while invoking the API requests.
				(f) unauthorisedUri: The value represents the URL in the response returned back from TFL API when an unauthorised
					request is made to the API. It seems there's no way to determine the Unauthorised status from the HttpStatusCode
					since the response comes back with a 200 OK status even when the API is tried to be accessed with an invalid 
					AppId or AppKey.
				(g) RoadStatus: The API method for RoadStatus API. In future when the application supports more APIs, those could
					be further added to this section.
	(iii)	Assumed that the application should handle most of the error scenarios such as trying to invoke the software:
				(a) without any parameters
				(b) with an invalid API method
				(c) with a valid API method without any parameters
				(c) with a valid API method but invalid parameters
				(d) with an invalid AppKey or AppId
			Assumed that relevant error message should be shown in all of the above cases.
	(iv)	Assumed that all the generic exceptions should also be captured within the application and that relevant error message 
			should be shown on screen.

## Other relevant facts or catches

	(i)		All the messages to be shown on screen including the valid result and exception messages are stored in a
			resource file - 'TFLClientResources.resx'. This enables easy modification of the texts at any point of time.
	(ii)	The software has it's own Exception framework built around the code logic so that in the future when new APIs are
			introduced, new types of custom Exceptions could be easily brought in.
	(iii)	Lastly most importantly, the software has been designed in such a way that the main parts are split into different
			projects to keep separation of concerns. The project abides to the SOLID principles in th way it is designed.
	(iv)	If at all the command line tool needs to be replaced with a web application,
			it could be achieved very easily by just introducing the new UI project in a plug and play model.
	(v)		The factory design pattern has been followed to construct the required handler class depending on the API method 
			to be invoked.
	(vi)	A RequestProcessor DLL serves as the starting point taking up the processing from the command line tool. The presence
			of the class RequestInitiator in the RequestProcessor DLL helps for easy pluggability of a different UI module
			as well as helps to achieve better code coverage in the BDD test cases.

## Author

**Nidhin Thankamoni Krishnakumar** - *Initial work*