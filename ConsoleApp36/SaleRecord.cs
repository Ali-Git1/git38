using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    class SaleRecord
    {
        public string ProductName { get; }
        public int Quantity { get; }
        public DateTime DateTime { get; }
        public decimal Price { get; set; }
        public SaleRecord(string productName, int quantity, decimal price)
        {
            ProductName = productName;
            Quantity = quantity;
            DateTime = DateTime.Now;
            Price = price;
        }
    }
}
