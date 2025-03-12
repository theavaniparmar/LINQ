using System;
using System.Collections.Generic;

namespace ef_demo_db.Models
{
    public partial class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public int Studentid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int? Standardid { get; set; }

        public virtual Standard? Standard { get; set; }
        public virtual Studentaddress Studentaddress { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
