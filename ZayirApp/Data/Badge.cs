using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Badge
    {
        public Badge()
        {
            Visit = new HashSet<Visit>();
        }

        public int BadgeId { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Visit> Visit { get; set; }
    }
}
