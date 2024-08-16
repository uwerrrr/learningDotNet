using System.Collections.Generic; // Importing generic collections.
using System.Linq; // Importing LINQ for querying collections.

namespace InventoryLibrary
{
    public class InventoryManager
    {
        // Private field to store the list of products.
        private List<Product> _products = new List<Product>();

        // Constructor initializes the products list.
        public InventoryManager()
        {
            _products = new List<Product>();
        }

        // Method to add a product to the inventory.
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Method to remove a product from the inventory by ID.
        public void RemoveProduct(int id)
        {
            // Find the product with the specified ID.
            var productToRemove = _products.SingleOrDefault(p => p.Id == id);
            
            // If found, remove it from the list.
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
            }
        }

        // Method to return a list of all products in the inventory.
        public List<Product> GetAllProducts()
        {
            return _products;
        }
    }
}