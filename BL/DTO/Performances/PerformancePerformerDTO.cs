using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class PerformancePerformerDTO
    {
        [Required]
        public int PerformanceId { get; set; }
        [Required]
        public int PerformerId { get; set; }

    }
}
