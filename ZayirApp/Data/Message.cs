using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int? Language { get; set; }
        public string Content { get; set; }
    }
}
