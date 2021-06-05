Feature: Artist
	Create, Read, Update an Artist

#There are some instructions in the file "ArtistSteps.cs"

@mytag
Scenario: 1 Initialize some Artists Intances
	When artists required attributes provided to initialize instances
		| BrandName    | Description               | Phrase              | SpecialtyId | FirstName    | LastName |
		| ElTitoAlfred | Nuevo Artista Musical     | Vivo en el presente | 1           | Alfred	      | Gonzales |
		| SanSon	   | Escultor de hielo		   | Vivo en el futuro   | 2           | Paolo        | Herrera  |
		| Dr.Chocolate | Cantante profesional	   | Vivo en el pasado   | 2           | Anonimo      | Anonimo  |
		| El bicho	   | Mago magistral 		   | Vivo en el olvido   | 3           | Cristiano    | Rolando  |



Scenario: Add new Artist with below details
    When artist required attributes provided
		| BrandName | Description           | Phrase              | SpecialtyId | FirstName | LastName |
		| SebSasaki | Nuevo Artista Musical | Vivo en el presente | 1           | Sebastian | Sasaki   |
                           


Scenario: Read an Artist with below details
	Given I have supplied 5 as artist Id
	Then artist details should be
		| Id | BrandName   | Description           | Phrase              | SpecialtyId | FirstName | Lastname |
		| 5  | SebSasaki   | Nuevo Artista Musical | Vivo en el presente | 1           | Sebastian | Sasaki   |



Scenario: Read All Artist with below details
	When No artist supplied All Artist list should return
		| Id | BrandName    | Description               | Phrase              | SpecialtyId | FirstName    | Lastname |
		| 1  | ElTitoAlfred | Nuevo Artista Musical     | Vivo en el presente | 1           | Alfred	   | Gonzales |
		| 2  | SanSon	    | Escultor de hielo		    | Vivo en el futuro   | 2           | Paolo        | Herrera  |
		| 3  | Dr.Chocolate | Cantante profesional	    | Vivo en el pasado   | 2           | Anonimo      | Anonimo  |
		| 4  | El bicho	    | Mago magistral 		    | Vivo en el olvido   | 3           | Cristiano    | Rolando  |
		| 5  | SebSasaki    | Nuevo Artista Musical		| Vivo en el presente | 1           | Sebastian    | Sasaki   |



Scenario: Update the details of an existing Artist
	When I have supplied 5 as artist Id and update details provided
		| BrandName		| Description           | Phrase              | SpecialtyId | FirstName | LastName |
		| SebSasaki 2.0 | Artista de china 	    | Solo hazlo!		  | 1           | Sebastian | Sasaki   |



Scenario: Delete an Artist
	Given I have supplied 5 as artist Id
	Then remove artist with Id 5 and removed artist details should be
		| Id  | BrandName		| Description           | Phrase              | SpecialtyId | FirstName | LastName |
		| 5   | SebSasaki 2.0	| Artista de china 	    | Solo hazlo!		  | 1           | Sebastian | Sasaki   |
