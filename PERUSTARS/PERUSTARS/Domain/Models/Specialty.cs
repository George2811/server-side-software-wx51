using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Models
{
    public class Specialty
    {
        public long SpecialtyId { get; set; }
        public string SpecialtyName { get; set; }
        public List<HobbyistSpecialty> HobbyistSpecialty { get; set; }

    }
}
