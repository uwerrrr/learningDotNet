using System;
using InventoryLibrary;

namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager inventory = new InventoryManager();

            // Add products
            inventory.AddProduct(new Product(1, "Apple", 0.5, 100));
            inventory.AddProduct(new Product(2, "Banana", 0.3, 150));
            inventory.AddProduct(new Product(3, "Orange", 0.7, 200));

            // List all products
            Console.WriteLine("All Products:");
            foreach (var product in inventory.GetAllProducts())
            {
                Console.WriteLine(product);
            }

            // Remove a product
            inventory.RemoveProduct(2);

            // List all products after removal
            Console.WriteLine("\nProducts after removal:");
            foreach (var product in inventory.GetAllProducts())
            {
                Console.WriteLine(product);
            }
        }
    }
}