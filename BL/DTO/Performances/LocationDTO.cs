using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class LocationDTO
    {
        public int LocationId { get; set; }
        [Required]
        [MaxLength(100)]
        public string LocationName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        [Required]
        [MaxLength(1000)]
        public string LocationDescription { get; set; }
        [Required]
        [MaxLength(200)]
        public string LocationContact { get; set; }

        public int LocationTypeId { get; set; }
        public LocationTypeDTO LocationType { get; set; }
    }
}
