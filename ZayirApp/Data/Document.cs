using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string DocumentFile { get; set; }
        public int? DocumentType { get; set; }
        public int VisitorId { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}
