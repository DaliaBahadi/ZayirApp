using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Delivery
    {
        public Delivery()
        {
            Notification = new HashSet<Notification>();
        }

        [Key]
        public int DeliveryId { get; set; }
        public DateTime ReciptionDateTime { get; set; }
        public DateTime PickupDateTime { get; set; }
        public string Description { get; set; }
        public int ContactId { get; set; }
        public int VisitorId { get; set; }
        public int RegistrarId { get; set; }

        [ForeignKey(nameof(ContactId))]
        [InverseProperty("DeliveryContact")]
        public virtual Contact Contact { get; set; }
        [ForeignKey(nameof(RegistrarId))]
        [InverseProperty(nameof(Contact.DeliveryRegistrar))]
        public virtual Contact Registrar { get; set; }
        [ForeignKey(nameof(VisitorId))]
        [InverseProperty("Delivery")]
        public virtual Visitor Visitor { get; set; }
        [InverseProperty("Delivery")]
        public virtual ICollection<Notification> Notification { get; set; }
    }
}
