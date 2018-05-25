using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class PerformerDTO
    {
        //Entity properties
        public int PerformerId { get; set; }
        [MaxLength(100)]
        public string PerformerName { get; set; }
        [MaxLength(1000)]
        public string PerformerDescription { get; set; }
        [MaxLength(200)]
        public string PerformerPage { get; set; }
        [Required]
        public int PerformerTypeId { get; set; }
        public PerformerTypeDTO PerformerType { get; set; }
    }
}
