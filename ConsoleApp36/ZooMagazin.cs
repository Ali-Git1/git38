using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    public class Zoomagazin
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Dictionary<Product, int> Stock { get; set; }

        public Zoomagazin(string name, string location)
        {
            Name = name;
            Location = location;
            Stock = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int quantity)
        {
            if (Stock.ContainsKey(product))
            {
                Stock[product] += quantity;
            }
            else
            {
                Stock.Add(product, quantity);
            }
        }

        public void SellProduct(Product product, int quantity)
        {
            if (Stock.ContainsKey(product))
            {
                if (Stock[product] >= quantity)
                {
                    Stock[product] -= quantity;
                    Console.WriteLine($"{quantity} {product.Name} satıldı.");
                }
                else
                {
                    Console.WriteLine($"Kifayət deyil {product.Name} anbarda.");
                }
            }
            else
            {
                Console.WriteLine($"{product.Name} stokda yoxdur.");
            }
        }
    }

}

