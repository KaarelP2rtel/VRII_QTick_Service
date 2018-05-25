using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class LocationTypeDTO
    {
        public int LocationTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string LocationTypeName{ get; set; }
        [Required]
        [MaxLength(1000)]
        public string LocationTypeDescription { get; set; }

        
    }
}
