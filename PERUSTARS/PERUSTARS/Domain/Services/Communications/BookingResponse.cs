using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services.Communications
{
    public class BookingResponse : BaseResponse<EventAssistance>
    {
        public BookingResponse(EventAssistance resource) : base(resource)
        {
        }

        public BookingResponse(string message) : base(message)
        {
        }
    }
}
