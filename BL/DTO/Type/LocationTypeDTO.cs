using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> LocationType
    /// This should be used to transfer LocationTypes between services.
    /// </summary>
    public class LocationTypeDTO
    {
        public int LocationTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string LocationTypeName{ get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(10)]
        public string LocationTypeDescription { get; set; }

        
    }
}
