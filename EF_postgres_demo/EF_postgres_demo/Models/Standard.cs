using System;
using System.Collections.Generic;

namespace EF_postgres_demo.Models;

public partial class Standard
{
    public int Standardid { get; set; }

    public string? Standardname { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
