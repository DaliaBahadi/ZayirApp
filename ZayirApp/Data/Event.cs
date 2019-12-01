using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Event
    {
        public Event()
        {
            Visit = new HashSet<Visit>();
        }

        [Key]
        public int EventId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }

        [InverseProperty("Event")]
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
