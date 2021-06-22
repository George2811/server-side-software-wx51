using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PERUSTARS.Domain.Models;
using PERUSTARS.Resources;
using PERUSTARS.Domain.Services.Communications;

namespace PERUSTARS.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile() {
            CreateMap<SaveArtistResource, Artist>();
            CreateMap<SavePersonResource, Person>();
            CreateMap<SaveArtworkResource, Artwork>();
            CreateMap<SaveEventResource, Event>();
            CreateMap<SaveClaimTicketResource, ClaimTicket>();
            CreateMap<SaveEventAssistanceResource, EventAssistance>();
            CreateMap<SaveHobbyistResource, Hobbyist>();
            CreateMap<RegisterRequest, User>();
        }
    }
}
