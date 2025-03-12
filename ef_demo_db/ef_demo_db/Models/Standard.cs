using System;
using System.Collections.Generic;

namespace ef_demo_db.Models
{
    public partial class Standard
    {
        public Standard()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Standardid { get; set; }
        public string? Standardname { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
