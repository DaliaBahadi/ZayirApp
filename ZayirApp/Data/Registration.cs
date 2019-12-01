using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Registration
    {
        public Registration()
        {
            Visit = new HashSet<Visit>();
        }

        [Key]
        public int RegistrationId { get; set; }
        public int Status { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public DateTime? ExpiryDateTime { get; set; }
        public DateTime VisitDateTime { get; set; }
        public int ContactId { get; set; }
        public int VisitorId { get; set; }

        [ForeignKey(nameof(ContactId))]
        [InverseProperty("Registration")]
        public virtual Contact Contact { get; set; }
        [ForeignKey(nameof(VisitorId))]
        [InverseProperty("Registration")]
        public virtual Visitor Visitor { get; set; }
        [InverseProperty("Registration")]
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
