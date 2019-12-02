using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public int NotificationType { get; set; }
        public int ContactId { get; set; }
        public int DeliveryId { get; set; }
        public int VisitId { get; set; }
        public int VisitorId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual Visit Visit { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
