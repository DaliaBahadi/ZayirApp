using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class VisitAgreement
    {
        [Key]
        public int VisitAgreementId { get; set; }
        public bool? Agreed { get; set; }
        public bool? Signed { get; set; }
        public string SignatureFile { get; set; }
        public int AgreementId { get; set; }
        public int VisitId { get; set; }

        [ForeignKey(nameof(AgreementId))]
        [InverseProperty("VisitAgreement")]
        public virtual Agreement Agreement { get; set; }
        [ForeignKey(nameof(VisitId))]
        [InverseProperty("VisitAgreement")]
        public virtual Visit Visit { get; set; }
    }
}
