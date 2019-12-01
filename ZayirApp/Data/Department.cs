using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayirApp.Data
{
    public partial class Department
    {
        public Department()
        {
            Contact = new HashSet<Contact>();
        }

        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Contact> Contact { get; set; }
    }
}
