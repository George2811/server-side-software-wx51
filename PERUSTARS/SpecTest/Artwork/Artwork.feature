Feature: Artwork
	Create, Read, Update an Artwork

@mytag
Scenario: Add new Artwork with below details
    When artwork required attributes provided
	 | ArtTitle  | ArtDescription                      | ArtCost | LinkInfo        | ArtistId |
	 | Monalisa2 | Nueva Representacion de la monalisa | 45      | http//monalisa2 | 1        | 
                           


Scenario: Read a artwork with below details
Given I have supplied 1 as artworkId
Then artwork details should be
  | ArtworkId | ArtTitle              | ArtDescription                              | ArtCost | LinkInfo               | ArtistId |
  | 1         | La noche estrellada 2 | Nueva Representacion de la noche estrellada | 90      | http//noche.estrellada | 2        | 

Scenario: Read All Artworks with below details
When No artwork supplied All artworks list should return
    | ArtworkId | ArtTitle              | ArtDescription                              | ArtCost | LinkInfo               | ArtistId |
    | 1         | La noche estrellada 2 | Nueva Representacion de la noche estrellada | 90      | http//noche.estrellada | 2        |
    | 2         | El Beso 2             | Nueva Representacion de la obra de klimt    | 70      | http//elbeso           | 2        |
