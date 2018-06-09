using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> Performer
    /// This should be used to transfer Performers between services.
    /// </summary>
    public class PerformerDTO
    {
        //Entity properties
        public int PerformerId { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string PerformerName { get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(10)]
        public string PerformerDescription { get; set; }
        [MaxLength(200)]
        public string PerformerPage { get; set; }

        // This is a foreign key of PerformerType
        [Required]
        public int PerformerTypeId { get; set; }
        public PerformerTypeDTO PerformerType { get; set; }
    }
}
