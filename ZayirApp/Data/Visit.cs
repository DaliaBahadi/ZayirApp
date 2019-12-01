using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Visit
    {
        public Visit()
        {
            Notification = new HashSet<Notification>();
            VisitAgreement = new HashSet<VisitAgreement>();
        }

        [Key]
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

        [ForeignKey(nameof(BadgeId))]
        [InverseProperty("Visit")]
        public virtual Badge Badge { get; set; }
        
        [ForeignKey(nameof(ContactId))]
        [InverseProperty("VisitContact")]
        public virtual Contact Contact { get; set; }
        
        [ForeignKey(nameof(EventId))]
        [InverseProperty("Visit")]
        public virtual Event Event { get; set; }
        
        [ForeignKey(nameof(GateId))]
        [InverseProperty("Visit")]
        public virtual Gate Gate { get; set; }
        
        [ForeignKey(nameof(RegistrarId))]
        [InverseProperty(nameof(Contact.VisitRegistrar))]
        public virtual Contact Registrar { get; set; }
        
        [ForeignKey(nameof(RegistrationId))]
        [InverseProperty("Visit")]
        public virtual Registration Registration { get; set; }
        
        [ForeignKey(nameof(VisitorId))]
        [InverseProperty("Visit")]
        public virtual Visitor Visitor { get; set; }
        
        [InverseProperty("Visit")]
        public virtual ICollection<Notification> Notification { get; set; }
        
        [InverseProperty("Visit")]
        public virtual ICollection<VisitAgreement> VisitAgreement { get; set; }
    }
}
public enum VisitTypes
{
    Personal = 1, Contractor, Maintenance,Lecturer
}