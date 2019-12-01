using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Agreement
    {
        public Agreement()
        {
            VisitAgreement = new HashSet<VisitAgreement>();
        }

        [Key]
        public int AgreementId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public string AgreementFile { get; set; }
        public bool? NeedSignature { get; set; }
        public bool? NeedAgreement { get; set; }

        [InverseProperty("Agreement")]
        public virtual ICollection<VisitAgreement> VisitAgreement { get; set; }
    }
}
