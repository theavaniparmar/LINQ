using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_queries
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            //LINQ Query using Mixed Syntax
            var MethodSyntax = (from obj in integerList
                                where obj > 5
                                select obj).Sum();

            //Execution
            Console.Write("Sum Is : " + MethodSyntax);

            Console.ReadKey();
        }
    }
}