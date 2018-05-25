using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PerformancePerformer
    {
        //Class only contains table relations
        public int PerformancePerformerId { get; set; }

        public int PerformanceId { get; set; }
        public Performance Performance { get; set; }
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }
    }
}
