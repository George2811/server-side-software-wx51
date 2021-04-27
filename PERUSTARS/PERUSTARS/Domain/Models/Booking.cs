using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Models
{
    public class Booking
    {
        public Event Event { get; set; }
        public long EventId { get; set; }

        public Hobbyist Hobbyist { get; set; }
        public long HobbyistId { get; set; }

        //**************************************//
        public DateTime AttendanceDay { get; set; }
        public bool Payment { get; set; }

    }
}
