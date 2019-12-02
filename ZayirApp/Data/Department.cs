using System;
using System.Collections.Generic;

namespace ZayirApp.Data
{
    public partial class Department
    {
        public Department()
        {
            Contact = new HashSet<Contact>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }
    }
}
