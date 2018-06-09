using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> Location
    /// This should be used to transfer Locations between services.
    /// </summary>
    public class LocationDTO
    {
        public int LocationId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string LocationName { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string Address { get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(10)]
        public string LocationDescription { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(10)]
        public string LocationContact { get; set; }

        // This is a foreign key of Location Type
        [Required]
        public int LocationTypeId { get; set; }
        public LocationTypeDTO LocationType { get; set; }
    }
}
