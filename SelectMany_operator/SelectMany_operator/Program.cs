using SelectMany_operator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            // using method syntax
            var method = Class1.Get().SelectMany(c => c.Programming, (student, program) => new
            {
                StudentName = student.Name,
                ProgrammingSkills = program
            }).ToList();

            foreach(var s in method)
            {
                Console.WriteLine(s.StudentName + "=>" + s.ProgrammingSkills);
            }
            Console.ReadKey();
        }    
    }
}
 