using System;
using System.Collections.Generic;

namespace EF_postgres_demo.Models;

public partial class Studentaddress
{
    public int Studentid { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public virtual Student Student { get; set; } = null!;
}
