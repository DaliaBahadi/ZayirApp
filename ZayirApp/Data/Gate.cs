using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Gate
    {
        public Gate()
        {
            Visit = new HashSet<Visit>();
        }

        [Key]
        public int GateId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string EvacuationDetails { get; set; }
        public string EvacuationPlanFile { get; set; }

        [InverseProperty("Gate")]
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
