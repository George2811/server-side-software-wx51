
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Resources
{
    public class ArtistResource : PersonResource
    {
        public string BrandingName{ get; set; }

        public string Description { get; set; }

        public string Phrase { get; set; }

        public string SpecialtyArt { get; set; }
    }
}
