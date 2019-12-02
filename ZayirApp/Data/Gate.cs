using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Gate
    {
        public Gate()
        {
            Visit = new HashSet<Visit>();
        }

        public int GateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EvacuationDetails { get; set; }
        public string EvacuationPlanFile { get; set; }

        public virtual ICollection<Visit> Visit { get; set; }
    }
}
