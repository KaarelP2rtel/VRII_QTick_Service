
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Performer
    {
        //Entity properties
        public int PerformerId { get; set; }
        [MaxLength(100)]
        public string PerformerName { get; set; }
        [MaxLength(1000)]
        public string PerformerDescription { get; set; }
        [MaxLength(200)]
        public string PerformerPage { get; set; }

        //Table relations
        public int PerformerTypeId { get; set; }
        public PerformerType PerformerType { get; set; }

    }
}
