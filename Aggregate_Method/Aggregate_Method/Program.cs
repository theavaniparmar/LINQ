using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };

            int result = arr.Aggregate((acc, num) => acc * num);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}