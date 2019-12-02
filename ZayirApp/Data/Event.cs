using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Event
    {
        public Event()
        {
            Visit = new HashSet<Visit>();
        }

        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Visit> Visit { get; set; }
    }
}
