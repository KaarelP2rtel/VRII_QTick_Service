using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class PerformerDTO
    {
        //Entity properties
        public int PerformerId { get; set; }
        public string PerformerName { get; set; }
        public string PerformerDescription { get; set; }
        public string PerformerPage { get; set; }

        public int PerformerTypeId { get; set; }
        public PerformerTypeDTO PerformerType { get; set; }
    }
}
