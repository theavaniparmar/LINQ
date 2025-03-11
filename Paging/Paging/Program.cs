using System.Linq;
using System;
using System.Collections.Generic;

namespace LINQDemo
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>
            {
                new Student { Id = 1, Name = "krishna", Marks = 100 },
                new Student { Id = 2, Name = "naitik", Marks = 50 },
                new Student { Id = 3, Name = "jaydev", Marks=70 },
                new Student { Id = 4, Name = "suraj", Marks = 30}
            };

            int PageNo = 1; //starting
            int itemsperPage = 2;

            var pages = list.Skip((PageNo - 1) * itemsperPage).Take(itemsperPage).ToList();

            Console.WriteLine($"Page {PageNo}:");

            foreach ( var page in pages )
            {
                Console.WriteLine($" Id : {page.Id} , Name : {page.Name}, Marks : {page.Marks}");
            }
            Console.ReadKey();
        }
    }
}