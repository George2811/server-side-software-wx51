using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Models
{
    public class Hobbyist : Person
    {
        List<ESpecialty> Interest { get; set; }
        List<FavoriteArtwork> FavoriteArtworks { get; set; }

        List<Follower> Followers { get; set; }

        List<Booking> Assistance { get; set; }
    }
}
