using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Product> PurchasedProducts { get; set; }

        public Customer(string name, string email, string address)
        {
            Name = name;
            Email = email;
            Address = address;
            PurchasedProducts = new List<Product>();
        }

        public void PurchaseProduct(Product product)
        {
            PurchasedProducts.Add(product);
        }
    }
}
