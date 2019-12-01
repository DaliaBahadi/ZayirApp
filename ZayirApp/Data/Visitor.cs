using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Visitor
    {
        public Visitor()
        {
            Delivery = new HashSet<Delivery>();
            Document = new HashSet<Document>();
            Notification = new HashSet<Notification>();
            Registration = new HashSet<Registration>();
            Visit = new HashSet<Visit>();
        }

        [Key]
        public int VisitorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandfatherName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Required]
        public string Mobile { get; set; }
        public Genders? Gender { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string ImageFile { get; set; }
        public string CarLicencePlate { get; set; }
        public bool? IsBlacklisted { get; set; }
        public Languages? Language { get; set; }
        public bool? AcceptSMSNotification { get; set; }
        public bool? AcceptEmailNotification { get; set; }
        public int? ClearanceLevel { get; set; }
        public string Note { get; set; }

        [InverseProperty("Visitor")]
        public virtual ICollection<Delivery> Delivery { get; set; }
        [InverseProperty("Visitor")]
        public virtual ICollection<Document> Document { get; set; }
        [InverseProperty("Visitor")]
        public virtual ICollection<Notification> Notification { get; set; }
        [InverseProperty("Visitor")]
        public virtual ICollection<Registration> Registration { get; set; }
        [InverseProperty("Visitor")]
        public virtual ICollection<Visit> Visit { get; set; }
    }
}

public enum Genders
{
    Female = 1, Male
}

public enum Languages
{
    Arabic = 1, English
}

public enum ClearanceLevel
{
    High = 1, Medium, Low
}