using System;
using System.Collections.Generic;

namespace ef_demo_db.Models
{
    public partial class VwStudentCourse
    {
        public int? Studentid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int? Courseid { get; set; }
        public string? Coursename { get; set; }
    }
}
