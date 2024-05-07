using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    public class Sales
    {

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public Role UserRole { get; set; }

        public Sales(Product product, int quantity, DateTime saleDate, Role role)
        {
            Product = product;
            Quantity = quantity;
            SaleDate = saleDate;
            UserRole = role;
        }

        private static List<Sales> salesHistory = new List<Sales>();

        public static void AddSale(Product product, int quantity, Role role)
        {
            Sales sale = new Sales(product, quantity, DateTime.Now, role);
            salesHistory.Add(sale);
            Console.WriteLine($"Satış: {quantity} {product.Name} at {sale.SaleDate}");
        }

        public static List<Sales> GetSalesHistory()
        {
            return salesHistory;
        }

        public static List<Sales> GetSalesInDateRange(DateTime startDate, DateTime endDate)
        {
            return salesHistory.Where(sale => sale.SaleDate >= startDate && sale.SaleDate <= endDate).ToList();
        }

        public static void DeleteSale(Sales saleToDelete, Role userRole)
        {
            if (userRole == Role.Admin)
            {
                salesHistory.Remove(saleToDelete);
                Console.WriteLine("Satış uğurla silindi.");
            }
            else
            {
                Console.WriteLine("Satışları silmək icazəniz yoxdur.");
            }
        }
    }
}
