# Api Endpoints

## ArtistClaimTickets

#### Get All Claim Tickets By Artist Id
```
/api/artists/{artistId}/claimtickets
```

#### Save Claim Ticket Of Artist
```
/api/artists/{artistId}/claimtickets
```

#### Get Claim Ticket Of Artist By Id
```
/api/artists/{artistId}/claimtickets/{claimTicketId}
```

#### Update Claim Ticket Of Artist
```
/api/artists/{artistId}/claimtickets/{claimTicketId}
```

#### Delete Claim Ticket Of Artist
```
/api/artists/{artistId}/claimtickets/{claimTicketId}
```


## ArtistReports

#### Get All Reports By Artist Id
```
/api/artists/{artistId}/reports
```


## Artists

#### List all Artists
```
/api/artists
```

#### Save Artist
```
/api/artists
```

#### Get Artist by Id
```
/api/artists/{artistId}
```

#### Update Artist
```
/api/artists/{artistId}
```

#### Delete Artist
```
/api/artists/{artistId}
```


## Artworks

#### List Artworks By Artist Id
```
/api/artists/{artistId}/artworks
```

#### Save Artwork
```
/api/artists/{artistId}/artworks
```

#### Get Artwork by Id
```
/api/artists/{artistId}/artworks/{artworkId}
```

#### Update Artwork
```
/api/artists/{artistId}/artworks/{artworkId}
```

#### Delete Artwork
```
/api/artists/{artistId}/artworks/{artworkId}
```


## EventAssistances

#### Get All Events By Hobbyist Id
```
/api/hobbyists/{hobbyistId}/events
```

#### Assign Event Assistance
```
/api/hobbyists/{hobbyistId}/events/{eventId}
```

#### Unassign Event Assistance
```
/api/hobbyists/{hobbyistId}/events/{eventId}
```


## Events

#### List Events By Artist Id
```
/api/artists/{artistId}/events
```

#### Save Event
```
/api/artists/{artistId}/events
```

#### Get Event By Id
```
/api/artists/{artistId}/events/{eventId}
```

#### Update Event
```
/api/artists/{artistId}/events/{eventId}
```

#### Delete Event
```
/api/artists/{artistId}/events/{eventId}
```


## FavoriteArtworks

#### Get All Favorite Artworks By Hobbyist Id
```
/api/hobbyists/{hobbyistId}/artworks
```

#### Assign Favorite Artwork
```
/api/hobbyists/{hobbyistId}/artworks/{artworkId}
```

#### Unassign Favorite Artwork
```
/api/hobbyists/{hobbyistId}/artworks/{artworkId}
```


## Followers

#### Assign Follower
```
/api/artists/{artistId}/followers/{hobbyistId}
```

#### Unassign Follower
```
/api/artists/{artistId}/followers/{hobbyistId}
```

#### Get All Hobbyist By Artist Id
```
/api/artists/{artistId}/followers
```

#### Count Artists' Followers
```
/api/artists/{artistId}/followers/count
```


## Follows

#### Get All Artists By Hobbyist Id
```
/api/hobbyists/{hobbyistId}/follows
```


## HobbyistClaimTickets

#### Get All Claim Tickets By Hobbyist Id
```
/api/hobbyists/{hobbyistId}/claimtickets
```

#### Save Claim Ticket Of Hobbyist
```
/api/hobbyists/{hobbyistId}/claimtickets
```

#### Get Claim Ticket Of Hobbyist By Id
```
/api/hobbyists/{hobbyistId}/claimtickets/{claimTicketId}
```

#### Update Claim Ticket Of Hobbyist
```
/api/hobbyists/{hobbyistId}/claimtickets/{claimTicketId}
```

#### Delete Claim Ticket Of Hobbyist
```
/api/hobbyists/{hobbyistId}/claimtickets/{claimTicketId}
```


## HobbyistReports

#### Get All Reports By Hobbyist Id
```
/api/hobbyists/{hobbyistId}/reports
```


## Hobbyists

#### List all Hobbyists
```
/api/hobbyists
```

#### Save Hobbyist
```
/api/hobbyists
```

#### Get Hobbyist by Id
```
/api/hobbyists/{hobbyistId}
```

#### Update Hobbyist
```
/api/hobbyists/{hobbyistId}
```

#### Delete Hobbyist
```
/api/hobbyists/{hobbyistId}
```


## Interests

#### List all Specialties
```
/api/hobbyists/{hobbyistId}/specialties
```

#### Assign Interest
```
/api/hobbyists/{hobbyistId}/specialties/{specialtyId}
```

#### Unassign Interest
```
/api/hobbyists/{hobbyistId}/specialties/{specialtyId}
```


## Specialties

#### List all Specialties
```
/api/specialties
```

#### Get Specialty by Id
```
/api/specialties/{specialtyId}
```


## Users

#### List all Users
```
/api/users
```

#### Register User
```
/api/users
```

#### Authenticate User
```
/api/users/authenticate
```