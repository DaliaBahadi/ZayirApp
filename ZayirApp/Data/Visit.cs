using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Visit
    {
        public Visit()
        {
            Notification = new HashSet<Notification>();
            VisitAgreement = new HashSet<VisitAgreement>();
        }

        public int VisitId { get; set; }
        public DateTime SignInDateTime { get; set; }
        public DateTime? SignOutDateTime { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int VisitType { get; set; }
        public int? ValidityInDays { get; set; }
        public int GateId { get; set; }
        public int? EventId { get; set; }
        public int? BadgeId { get; set; }
        public int VisitorId { get; set; }
        public int ContactId { get; set; }
        public int? RegistrationId { get; set; }
        public int RegistrarId { get; set; }

        public virtual Badge Badge { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Event Event { get; set; }
        public virtual Gate Gate { get; set; }
        public virtual Contact Registrar { get; set; }
        public virtual Registration Registration { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<VisitAgreement> VisitAgreement { get; set; }
    }
}
