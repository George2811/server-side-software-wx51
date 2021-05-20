using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Resources
{
    public class SaveBookingResource
    {
        [Required]
        public DateTime AttendanceDay { get; set; }
    }
}
