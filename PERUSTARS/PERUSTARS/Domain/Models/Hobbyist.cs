using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Models
{
    public class Hobbyist : Person
    {
        public List<ESpecialty> Interest { get; set; }
        public List<FavoriteArtwork> FavoriteArtworks { get; set; }

        public List<Follower> Followers { get; set; }

        public List<Booking> Assistance { get; set; }
    }
}
