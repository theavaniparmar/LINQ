using System;
using System.Collections.Generic;

namespace EF_postgres_demo.Models;

public partial class Teacher
{
    public int Teacherid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? Standardid { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Standard? Standard { get; set; }
}
