using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public int NotificationType { get; set; }
        public int ContactId { get; set; }
        public int DeliveryId { get; set; }
        public int VisitId { get; set; }
        public int VisitorId { get; set; }

        [ForeignKey(nameof(ContactId))]
        [InverseProperty("Notification")]
        public virtual Contact Contact { get; set; }
        [ForeignKey(nameof(DeliveryId))]
        [InverseProperty("Notification")]
        public virtual Delivery Delivery { get; set; }
        [ForeignKey(nameof(VisitId))]
        [InverseProperty("Notification")]
        public virtual Visit Visit { get; set; }
        [ForeignKey(nameof(VisitorId))]
        [InverseProperty("Notification")]
        public virtual Visitor Visitor { get; set; }
    }
}
