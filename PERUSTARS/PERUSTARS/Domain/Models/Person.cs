using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Models
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public long Id { get; set; }

        public IList<ClaimTicket> ClaimTickets { get; set; } = new List<ClaimTicket>();  //Reportes que la Persona realiza
        public IList<ClaimTicket> ReportsClaimTickets { get; set; } = new List<ClaimTicket>();  //Reportes que le hace a la persona
    }
}
