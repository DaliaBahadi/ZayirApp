using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Contact
    {
        public Contact()
        {
            DeliveryContact = new HashSet<Delivery>();
            DeliveryRegistrar = new HashSet<Delivery>();
            Notification = new HashSet<Notification>();
            Registration = new HashSet<Registration>();
            VisitContact = new HashSet<Visit>();
            VisitRegistrar = new HashSet<Visit>();
        }

        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int? Language { get; set; }
        public int? Gender { get; set; }
        public bool? AcceptSMSNotification { get; set; }
        public bool? AcceptEmailNotification { get; set; }
        public int DepartmentId { get; set; }
        public int? StudentId { get; set; }
        public int? EmployeeId { get; set; }
        public string PhoneExtention { get; set; }
        public string OfficeNumber { get; set; }
        public int ContactType { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Delivery> DeliveryContact { get; set; }
        public virtual ICollection<Delivery> DeliveryRegistrar { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
        public virtual ICollection<Visit> VisitContact { get; set; }
        public virtual ICollection<Visit> VisitRegistrar { get; set; }
    }

    public enum Gender
    {
        Female = 1,

        Male
    }
}
