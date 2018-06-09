using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> PerformerType
    /// This should be used to transfer PerformerTypes between services.
    /// </summary>
    public class PerformerTypeDTO
    {
        public int PerformerTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string PerformerTypeName { get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(10)]
        public string PerformerTypeDescription { get; set; }
       
    }
}
