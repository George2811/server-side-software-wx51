using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Resources
{
    public class ClaimTicketResource
    {
        public long ClaimId { get; set; }
        public string ClaimSubject { get; set; }
        public string ClaimDescription { get; set; }
        public DateTime IncedentDate { get; set; }
        public PersonResource ReportedPerson { get; set; }

        //una persona realiza multiples reportes
        public long PersonId { get; set; }
        public PersonResource ReportMadeBy { get; set; }
    }
}
