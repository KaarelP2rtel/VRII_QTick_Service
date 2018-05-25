using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class PerformerTypeDTO
    {
        public int PerformerTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string PerformerTypeName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string PerformerTypeDescription { get; set; }
       
    }
}
