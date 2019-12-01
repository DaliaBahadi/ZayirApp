using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        public int ContactId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        public Languages? Language { get; set; }
        public Genders? Gender { get; set; }
        public bool? AcceptSMSNotification { get; set; }
        public bool? AcceptEmailNotification { get; set; }
        public int DepartmentId { get; set; }
        public int? StudentId { get; set; }
        public int? EmployeeId { get; set; }
        public string PhoneExtention { get; set; }
        public string OfficeNumber { get; set; }
        public ContactTypes ContactType { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Contact")]
        public virtual Department Department { get; set; }
        [InverseProperty(nameof(Delivery.Contact))]
        public virtual ICollection<Delivery> DeliveryContact { get; set; }
        [InverseProperty(nameof(Delivery.Registrar))]
        public virtual ICollection<Delivery> DeliveryRegistrar { get; set; }
        [InverseProperty("Contact")]
        public virtual ICollection<Notification> Notification { get; set; }
        [InverseProperty("Contact")]
        public virtual ICollection<Registration> Registration { get; set; }
        [InverseProperty(nameof(Visit.Contact))]
        public virtual ICollection<Visit> VisitContact { get; set; }
        [InverseProperty(nameof(Visit.Registrar))]
        public virtual ICollection<Visit> VisitRegistrar { get; set; }
    }
}

public enum Genders1
{
    Female = 1, Male
}

public enum Languages1
{
    Arabic = 1, English
}

public enum ContactTypes
{
    Staff = 1, Faculty, Student
}