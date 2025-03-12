using System;
using System.Collections.Generic;

namespace ef_demo_db.Models
{
    public partial class Studentaddress
    {
        public int Studentid { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
