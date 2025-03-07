using System;
using System.Collections.Generic;
using System.Linq;

namespace Products
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price  { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Products>
            {
                 new Products { Id = 1, Name = "Laptop", Category = "Electronics", Price = 80000 },
                 new Products { Id = 2, Name = "Mobile", Category = "Electronics", Price = 30000 },
                 new Products { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 1000 },
                 new Products { Id = 4, Name = "Shoes", Category = "Clothing", Price = 2000 },
                 new Products { Id = 5, Name = "Fridge", Category = "Electronics", Price = 50000 }
            };

            LINQOperations(products);
        }

        
            static void LINQOperations(List<Products> products)
            {
                //Filtering: Get products where price > 10,000
                var expensiveProducts = products.Where(p => p.Price > 10000);
                Console.WriteLine(" Expensive Products:");
                Print(expensiveProducts);

                //Sorting: Order by Price (Ascending)
                var sortedByPrice = products.OrderBy(p => p.Price);
                Console.WriteLine(" Products Sorted by Price:");
                Print(sortedByPrice);

                //Sorting with ThenBy: Order by Category, then by Price
                var sortedByCategoryAndPrice = products.OrderBy(p => p.Category).ThenBy(p => p.Price);
                Console.WriteLine(" Products Sorted by Category & Price:");
                Print(sortedByCategoryAndPrice);

                //Projection: Select only Product Names
                var productNames = products.Select(p => p.Name);
                Console.WriteLine("Product Names:");
                foreach (var name in productNames) Console.WriteLine(name);

                //Grouping: Group products by Category
                var groupedProducts = products.GroupBy(p => p.Category);
                Console.WriteLine(" Products Grouped by Category:");
                foreach (var group in groupedProducts)
                {
                    Console.WriteLine($"Category: {group.Key}");
                    Print(group);
                }

                //Aggregate Functions: Find Max, Min, Sum, Average Price
                Console.WriteLine($" Max Price: {products.Max(p => p.Price)}");
                Console.WriteLine($" Min Price: {products.Min(p => p.Price)}");
                Console.WriteLine($" Total Price of All Products: {products.Sum(p => p.Price)}");
                Console.WriteLine($" Average Price: {products.Average(p => p.Price)}");

                //Element Operators: First & Single
                Console.WriteLine($" First Product: {products.First().Name}");
                Console.WriteLine($" Single Product with Id 3: {products.Single(p => p.Id == 3).Name}");

                //  Set Operations: Distinct Categories
                var distinctCategories = products.Select(p => p.Category).Distinct();
                Console.WriteLine(" Distinct Categories:");
                foreach (var category in distinctCategories) Console.WriteLine(category);

                //Take & Skip: Get first 2 products, skip first 2 products
                var firstTwo = products.Take(2);
                Console.WriteLine("First 2 Products:");
                Print(firstTwo);

                var skipTwo = products.Skip(2);
                Console.WriteLine(" Products after Skipping 2:");
                Print(skipTwo);
            }

            static void Print(IEnumerable<Products> products)
            {
                foreach (var p in products)
                    Console.WriteLine($"Name: {p.Name}, Category: {p.Category}, Price: {p.Price}");
                Console.WriteLine(); // Empty line for readability
            }
        }
    }
    
