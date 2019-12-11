using System;
using System.Collections.Generic;

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

        public int VisitorId { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandfatherName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Mobile { get; set; }
        public VisitorGender? Gender { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string ImageFile { get; set; }
        public string CarLicencePlate { get; set; }
        public bool? IsBlacklisted { get; set; }
        public VisitorLanguage? Language { get; set; }
        public bool? AcceptSMSNotification { get; set; }
        public bool? AcceptEmailNotification { get; set; }
        public ClearanceLevel? ClearanceLevel { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Delivery> Delivery { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}

public enum VisitorGender
{
    Female = 1, Male
}

public enum VisitorLanguage
{
    Arabic = 1, English
}
public enum ClearanceLevel
{
    Low = 1, Medium, High
}