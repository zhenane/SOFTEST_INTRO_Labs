@BasicMusa
Feature: UsingCalculatorBasicReliability
In order to calculate the Basic Musa model's failures and intensities
As a Software Quality Metric enthusiast
I want to use my calculator to do this
Execution time is measured in CPU hours and failure intensity in failures per CPU hour.

Scenario Outline: Current failure intensity
Given I have a calculator
And the initial failure intensity is <lambda0> failures per CPU hour
And the expected total failures are <nu0>
And the execution time is <tau> CPU hours
When I calculate the current failure intensity
Then the result should be <intensity>
Examples:
| lambda0 | nu0 | tau | intensity |
| 10 | 100 | 0 | 10 |
| 10 | 100 | 10 | 3.6787944117 |

Scenario Outline: Expected cumulative failures
Given I have a calculator
And the initial failure intensity is <lambda0> failures per CPU hour
And the expected total failures are <nu0>
And the execution time is <tau> CPU hours
When I calculate the expected cumulative failures
Then the result should be <failures>
Examples:
| lambda0 | nu0 | tau | failures |
| 10 | 100 | 0 | 0 |
| 10 | 100 | 10 | 63.2120558829 |

Scenario Outline: Reject invalid Basic Musa parameters
Given I have a calculator
And the initial failure intensity is <lambda0> failures per CPU hour
And the expected total failures are <nu0>
And the execution time is <tau> CPU hours
When I calculate the <measure>
Then the calculation should be rejected
Examples:
| lambda0 | nu0 | tau | measure |
| 0 | 100 | 5 | current failure intensity |
| 10 | 0 | 5 | expected cumulative failures |
| 10 | 100 | -1 | current failure intensity |
| 10 | 100 | -1 | expected cumulative failures |
