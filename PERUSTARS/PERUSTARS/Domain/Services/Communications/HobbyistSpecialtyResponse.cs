using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services.Communications
{
    public class HobbyistSpecialtyResponse : BaseResponse<Interest>
    {
        public HobbyistSpecialtyResponse(Interest resource) : base(resource)
        {
        }

        public HobbyistSpecialtyResponse(string message) : base(message)
        {
        }
    }
}
