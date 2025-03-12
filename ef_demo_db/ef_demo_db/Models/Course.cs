using System;
using System.Collections.Generic;

namespace ef_demo_db.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int Courseid { get; set; }
        public string? Coursename { get; set; }
        public int? Teacherid { get; set; }

        public virtual Teacher? Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
