using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Registration
    {
        public Registration()
        {
            Visit = new HashSet<Visit>();
        }

        public int RegistrationId { get; set; }
        public int Status { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public DateTime? ExpiryDateTime { get; set; }
        public DateTime VisitDateTime { get; set; }
        public int ContactId { get; set; }
        public int VisitorId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
