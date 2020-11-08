Feature: HookChromeTestsWithContext
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario:  Add three numbers
	Given the first number is 50
	And the second number is 80
	And the third number is 80
	When the two numbers are added
	Then the result should be 120

