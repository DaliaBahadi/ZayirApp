using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Badge
    {
        public Badge()
        {
            Visit = new HashSet<Visit>();
        }

        [Key]
        public int BadgeId { get; set; }
        public string Note { get; set; }

        [InverseProperty("Badge")]
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
