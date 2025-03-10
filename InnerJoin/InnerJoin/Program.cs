using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Depid { get; set; }
    }

    public class Department
    {
        public int ID { get; set; }
        public int Depid { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emp = new List<Employee>
            {
                new Employee {ID = 1, Name ="a", Depid = 1},
                new Employee{ID = 2, Name = "b", Depid = 2},
                new Employee {ID = 3 , Name = "c", Depid = 3}
            };

            List<Department> dep = new List<Department>
            {
                new Department { ID = 1, Depid = 1 },
                new Department { ID = 2, Depid = 3 }
            };

            //method syntax
            var result = emp.Join(dep, emp => emp.Depid, dep => dep.Depid, (emp, dep) => new { emp.Name, dep.ID });

            Console.WriteLine("Inner Join:");

            foreach (var res in result)
            {
                Console.WriteLine($"{res.Name} = > {res.ID}");
            }


            //left join using method syntax

            Console.WriteLine("\nLeft Join : ");

            var leftjoin = emp.GroupJoin(dep,
                emp => emp.Depid,
                dep => dep.Depid,
                (emp, empName) => new { emp, empName })
                .SelectMany(e => e.empName.DefaultIfEmpty(),
                (emp, dep) => new { EmployeeName = emp.emp.Name, Depid = dep ?.Depid ?? 0 });
            foreach (var l in leftjoin)
            {
                Console.WriteLine($"{l.EmployeeName} = {l.Depid}");
            }

            //right join using method 
            Console.WriteLine("\nRight join:");

            var rightjoin = dep.GroupJoin(emp, 
                dep => dep.Depid,
                emp => emp.Depid,
                (dep, depID) => new {dep, depID})
                .SelectMany(d => d.depID.DefaultIfEmpty(),
                (dep, emp) => new {EmployeeName = emp?.Name ?? "no dept id assigned", Depid = dep.dep.Depid});

            foreach(var l in rightjoin)
            {
                Console.WriteLine($"{l.Depid} : {l.EmployeeName}");
            }

            //full outer join
            Console.WriteLine("\nfull outer join:");

            var full = leftjoin.Union(rightjoin);

            foreach (var l in full)
            {
                Console.WriteLine($"{l.EmployeeName} : {l.Depid}");
            }
            Console.ReadLine();
        }
    }
}