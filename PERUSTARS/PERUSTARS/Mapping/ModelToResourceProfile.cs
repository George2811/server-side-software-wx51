using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PERUSTARS.Domain.Models;
using PERUSTARS.Resources;

namespace PERUSTARS.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile() {
            CreateMap<Artist, ArtistResource>();
            CreateMap<Hobbyist, Hobbyist>();
            CreateMap<Person, PersonResource>();
            CreateMap<Event, EventResource>();
            CreateMap<ClaimTicket, ClaimTicketResource>();
            CreateMap<Booking, BookingResource>();



        }

    }
}
