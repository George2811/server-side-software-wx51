Feature: Event
	Create, Read, Update an Event

@mytag
Scenario: Add new Event with below details
    When event required attributes provided
	 | EventTitle  | DateStart              | DateEnd                | EventDescription                  | EventAditionalInfo                    | ArtistId |
	 | El rey Lear | 12/06/2021 12:00:00 AM | 20/06/2021 12:00:00 AM | Nueva Interpretacion del rey lear | 50 % de descuento los 2 primeros dias | 1        |
                           


Scenario: Read an artwork with below details
Given I have supplied 1 as eventId
Then events details should be
  | EventId | EventTitle | DateStart              | DateEnd                | EventDescription              | EventAditionalInfo                              | ArtistId |
  | 1       | Hilda      | 16/06/2021 12:00:00 AM | 30/06/2021 12:00:00 AM | Nueva Interpretacion de Hilda | Con tu carnet de universitario 20% de descuento | 2        |
  

Scenario: Read All Artworks with below details
When No event supplied All events list should return
  | EventId | EventTitle      | DateStart              | DateEnd                | EventDescription                        | EventAditionalInfo                              | ArtistId |
  | 1       | Hilda           | 16/06/2021 12:00:00 AM | 30/06/2021 12:00:00 AM | Nueva Interpretacion de Hilda           | Con tu carnet de universitario 20% de descuento | 2        |
  | 2       | Romeo y Julieta | 1/07/2021 12:00:00 AM  | 10/07/2021 12:00:00 AM | Nueva Interpretacion de Romeo y Julieta | Con tu carnet de universitario 20% de descuento | 2        |
