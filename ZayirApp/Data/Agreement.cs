using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Agreement
    {
        public Agreement()
        {
            VisitAgreement = new HashSet<VisitAgreement>();
        }

        public int AgreementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AgreementFile { get; set; }
        public bool? NeedSignature { get; set; }
        public bool? NeedAgreement { get; set; }

        public virtual ICollection<VisitAgreement> VisitAgreement { get; set; }
    }
}
