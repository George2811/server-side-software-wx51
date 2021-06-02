Feature: Hobbyist
	Create, Read, Update an Hobbyist

@mytag
Scenario: Add new Hobbyist with below details
    When hobbyist required attributes provided
	 | FirstName | LastName  |
	 | Josselin  | Izaguirre |
                           


Scenario: Read a Hobbyist with below details
Given I have supplied 7 as hobbyistId
Then hobbyist details should be
  | Id | FirstName | Lastname |
  | 7  | Pablo     | Herrera  |

Scenario: Read All Artist with below details
When No hobbyist supplied All hobbyist list should return
  | Id | FirstName | Lastname |
  | 7  | Pablo     | Herrera  |
  | 8  | Emmanuel  | Ticona   |

