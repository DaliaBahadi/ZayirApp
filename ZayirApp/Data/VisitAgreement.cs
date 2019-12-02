using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class VisitAgreement
    {
        public int VisitAgreementId { get; set; }
        public bool? Agreed { get; set; }
        public bool? Signed { get; set; }
        public string SignatureFile { get; set; }
        public int AgreementId { get; set; }
        public int VisitId { get; set; }

        public virtual Agreement Agreement { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
