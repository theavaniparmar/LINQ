using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>
            {
                new Employee { Id = 1, Name = "abc"},
                new Employee { Id = 2, Name = "xyz"}
            };
            return list;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
           
            //method syntax
            IEnumerable<Employee> method = Employee.GetEmployees().Select(emp => new Employee() { Name = emp.Name }). ToList();
            foreach (Employee emp in method)
            {
                Console.WriteLine($"Name : {emp.Name}");
            }
            Console.ReadLine();
        }
    }
}