using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Models
{
    public class Event
    {
        public long EventId { get; set; }
        public string EventTitle { get; set; }
        public ETypeOfEvent EventType { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string EventDescription { get; set; }
        public string EventAditionalInfo { get; set; }
        public Artist Artist { get; set; }

        public List<Booking>Assistance { get; set; }
    }
}
