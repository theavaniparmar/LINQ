using System;
using System.Collections.Generic;

namespace EF_postgres_demo.Models;

public partial class Course
{
    public int Courseid { get; set; }

    public string? Coursename { get; set; }

    public int? Teacherid { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
