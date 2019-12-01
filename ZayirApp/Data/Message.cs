using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Message
    {
        [Key]
        public int MessageId { get; set; }
        public int? Language { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
