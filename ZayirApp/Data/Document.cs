using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Document
    {
        [Key]
        public int DocumentId { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpiryDate { get; set; }
        public string DocumentFile { get; set; }
        public int? DocumentType { get; set; }
        public int VisitorId { get; set; }

        [ForeignKey(nameof(VisitorId))]
        [InverseProperty("Document")]
        public virtual Visitor Visitor { get; set; }
    }
}
