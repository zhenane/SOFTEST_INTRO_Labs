@Factorial
Feature: UsingCalculatorFactorial
In order to count the ways of arranging items
As a calculator user
I want to be told the factorial of a whole number

Scenario: Calculate a normal factorial
Given I have a calculator
When I have entered 5 into the calculator and press factorial
Then the factorial result should be 120

Scenario: The factorial of zero is one
Given I have a calculator
When I have entered 0 into the calculator and press factorial
Then the factorial result should be 1

Scenario: Reject the factorial of a negative number
Given I have a calculator
When I have entered -1 into the calculator and press factorial
Then factorial should be rejected
