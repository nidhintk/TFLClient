Feature: Invoke a TFL API
	In order to invoke a TFL API
	As a user who wants to know transport information
	I want to be told the transport information

Scenario: Invoke without passing any parameters
	Given The user doesnot pass in any parameters
	When The TFLClient is run
	Then The correct validation message should be displayed on screen

Scenario: Invoke specifying an invalid API method
	Given The user passes in an invalid API Method
	When The TFLClient is run
	Then The correct validation message should be displayed on screen

Scenario: Invoke specifying a valid API method without any parameters
	Given The user passes in a valid API Method without any parameters
	When The TFLClient is run
	Then The correct validation message should be displayed on screen
	
Scenario: Invoke specifying a valid API method with an invalid parameter
	Given The user passes in a valid API Method with an invalid parameter
	When The TFLClient is run
	Then The correct validation message should be displayed on screen
	
Scenario: Invoke specifying a valid API method with an invalid parameter that breaks the API
	Given The user passes in a valid API Method with an invalid parameter that breaks the API
	When The TFLClient is run
	Then The generic error message should be displayed on screen

Scenario: Invoke the RoadStatus API with an invalid AppId
	Given The User Is Unauthorised
	When The TFLClient is run
	Then The correct validation message should be displayed on screen

Scenario: Invoke the RoadStatus API with A2 as the road code
	Given The user invokes the RoadStatus API with A2 as the road code
	When The TFLClient is run
	Then The road status information for A2 road should be displayed on screen
