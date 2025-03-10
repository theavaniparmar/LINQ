using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectMany_operator
{
    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }
            
        public string Email { get; set; }
        public List<string> Programming { get; set; }

        public static List<Class1> Get()
        { return new List<Class1>()
            {
                new Class1 (){Id = 1, Name = "James", Email = "James@j.com", Programming = new List<string>() { "C#", "Jave", "C++"} },
                new Class1 (){Id = 2, Name = "Sam", Email = "Sara@j.com", Programming = new List<string>() { "WCF", "SQL Server", "C#" }},
                new Class1(){Id = 3, Name = "Patrik", Email = "Patrik@j.com", Programming = new List<string>() { "MVC", "Jave", "LINQ"} },
                new Class1(){Id = 4, Name = "Sara", Email = "Sara@j.com", Programming = new List<string>() { "ADO.NET", "C#", "LINQ" } }
            }; 
        }
    }
}
