using System;
using System.Collections.Generic;

namespace ef_demo_db.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        public int Teacherid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int? Standardid { get; set; }

        public virtual Standard? Standard { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
