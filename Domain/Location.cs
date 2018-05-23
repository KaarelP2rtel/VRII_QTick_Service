
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Location
    {

        //Entity properties
        public int LocationId { get; set; }
        [MaxLength(100)]
        public string LocationName { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(1000)]
        public string LocationDescription { get; set; }
        [MaxLength(200)]
        public string LocationContact { get; set; }
        //Table relations
        public int LocationTypeId { get; set; }
        public LocationType LocationType { get; set; }

        public List<Performance> Performances { get; set; }
    }
}
