Feature: Artist
	Create, Read, Update an Artist

@mytag
Scenario: Add new Artist with below details
    When artist required attributes provided
	| BrandName | Description           | Phrase              | SpecialtyId | FirstName | LastName |
	| SebSasaki | Nuevo Artista Musical | Vivo en el presente | 1           | Sebastian | Sasaki   |
                           


Scenario: Read a Artist with below details
Given I have supplied 1 as artist Id
Then artist details should be
  | Id | BrandName | Description                | Phrase              | SpecialtyId | FirstName | Lastname |
  | 1  | SebasGx   | Artista Nuevo en PeruStars | Solo se que nada se | 1           | Sebastian | Gonzales |

Scenario: Read All Artist with below details
When No artist supplied All Artist list should return
| Id | BrandName    | Description                 | Phrase                                | SpecialtyId | FirstName    | Lastname  |
| 1  | SebasGx      | Artista Nuevo en PeruStars  | Solo se que nada se                   | 1           | Sebastian    | Gonzales  |
| 2  | Dr.Chocolate | Escultor Nuevo en PeruStars | Ojos que no ven corazon que no siente | 4           | Diego Alonso | Chocolate |
