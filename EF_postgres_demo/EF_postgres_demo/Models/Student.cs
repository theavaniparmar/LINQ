using System;
using System.Collections.Generic;

namespace EF_postgres_demo.Models;

public partial class Student
{
    public int Studentid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? Standardid { get; set; }

    public virtual Standard? Standard { get; set; }

    public virtual Studentaddress? Studentaddress { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
