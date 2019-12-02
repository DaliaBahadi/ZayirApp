using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Delivery
    {
        public Delivery()
        {
            Notification = new HashSet<Notification>();
        }

        public int DeliveryId { get; set; }
        public DateTime ReciptionDateTime { get; set; }
        public DateTime PickupDateTime { get; set; }
        public string Description { get; set; }
        public int ContactId { get; set; }
        public int VisitorId { get; set; }
        public int RegistrarId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Contact Registrar { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
    }
}
