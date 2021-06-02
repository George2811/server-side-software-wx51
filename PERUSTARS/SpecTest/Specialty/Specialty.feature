Feature: Specialty
	 Read an Specialty

@mytag
Scenario: Read an Specialty with below details
Given I have supplied 1 as specialtyId
Then specialty details should be
| Id | Name       |
| 1  | Specialty1 |

Scenario: Read All Artworks with below details
When No specialty supplied All specialty list should return
| Id | Name       |
| 1  | Specialty1 |
| 2  | Specialty2 |
| 3  | Specialty3 |
| 4  | Specialty4 |