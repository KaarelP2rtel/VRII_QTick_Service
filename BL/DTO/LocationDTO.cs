using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class LocationDTO
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string LocationDescription { get; set; }
        public string LocationContact { get; set; }

        public int LocationTypeId { get; set; }
        public LocationTypeDTO LocationType { get; set; }
    }
}
