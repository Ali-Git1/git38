using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<SaleRecord> salesHistory = new List<SaleRecord>();
        static List<Product> products = new List<Product>();

        static void Register()
        {
            Console.Write("Istifadeci adi daxil edin: ");
            string username = Console.ReadLine();
            Console.Write("Sifre daxil edin: ");
            string password = Console.ReadLine();
            users.Add(new User(username, password, Role.Admin));
            Console.WriteLine("Istifadeci ugurla qeydiyyatdan kecdi");
        }

        static User Login()
        {
            Console.Write("Istifadeci adi daxil edin: ");
            string username = Console.ReadLine();
            Console.Write("Sifre daxil edin: ");
            string password = Console.ReadLine();
            User user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Console.WriteLine("ugurlu giris.");
                return user;
            }
            else
            {
                Console.WriteLine("Istifadeci adi ve ya sifre yanlisdir.");
                return null;
            }
        }

        static void AddProduct()
        {
            Console.Write("Mehsul adini daxil edin: ");
            string productName = Console.ReadLine();
            Console.Write("Stok miqdarini daxil edin: ");
            if (int.TryParse(Console.ReadLine(), out int stock) && stock >= 0)
            {
                Console.Write("Qiymet daxil edin: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
                {
                    products.Add(new Product(productName, stock, price));
                    Console.WriteLine($"{productName} ugurla elave edildi.");
                }
                else
                {
                    Console.WriteLine("qiymet dogru deyil.");
                }
            }
            else
            {
                Console.WriteLine("stock miqdari dogru deyil.");
            }
        }

        static void SellProduct(User user)
        {
            Console.WriteLine("Movcud mehsullar:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - Stock: {products[i].Stock}, Price: {products[i].Price}");
            }

            if (products.Count == 0)
            {
                Console.WriteLine("satila bilecek mehsul yoxdur.");
                return;
            }

            Console.Write("Satilacaq mehsulun nomresini daxil edin: ");
            if (int.TryParse(Console.ReadLine(), out int productIndex) && productIndex >= 1 && productIndex <= products.Count)
            {
                var selectedProduct = products[productIndex - 1];
                Console.Write("Miqdar daxil edin: ");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0 && quantity <= selectedProduct.Stock)
                {
                    Console.WriteLine("Miqdar basi qiymet: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
                    {
                        salesHistory.Add(new SaleRecord(selectedProduct.Name, quantity, price));
                        selectedProduct.Stock -= quantity;
                        Console.WriteLine($"{quantity} {selectedProduct.Name} ugurla satildi.");
                    }
                    else
                    {
                        Console.WriteLine("Qiymet dogru deyil.");
                    }
                }
                else
                {
                    Console.WriteLine("Miqdar yanlisdir ve ya kifayet qeder stock yoxdur.");
                }
            }
            else
            {
                Console.WriteLine("Mehsul nomresi yanlisdir.");
            }
        }

        static void ShowUsers()
        {
            Console.WriteLine("İstifadəçilər:");
            foreach (var user in users)
            {
                Console.WriteLine($"İstifadəçi adı: {user.Username}");
            }
        }

        static void ShowSalesHistory()
        {
            Console.WriteLine("Satış Tarixi:");
            foreach (var sale in salesHistory)
            {
                Console.WriteLine($"Mehsul: {sale.ProductName}, Miqdar: {sale.Quantity}, Qiymet: {sale.Price}, Tarix: {sale.DateTime}");
            }
        }

        static void ShowSalesBetweenDates()
        {
            Console.Write("Başlama tarixini daxil edin (YYYY-MM-DD HH:mm:ss): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                Console.Write("Bitme tarixini daxil edin (YYYY-MM-DD HH:mm:ss): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                {
                    Console.WriteLine($"Verilen vaxt arasinda olan satislar {startDate} and {endDate}:");
                    foreach (var sale in salesHistory.Where(s => s.DateTime >= startDate && s.DateTime <= endDate))
                    {
                        Console.WriteLine($"Mehsul: {sale.ProductName}, Miqdar: {sale.Quantity}, Qiymet: {sale.Price:C}, Tarix: {sale.DateTime}");
                    }
                }
                else
                {
                    Console.WriteLine("Bitme tarixi formati yanlisdir.");
                }
            }
            else
            {
                Console.WriteLine("Baslama tarixi formati yanlisdir.");
            }
        }





        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Qeydiyyatdan keçin");
                Console.WriteLine("2. Daxil ol");
                Console.WriteLine("3. Məhsul əlavə edin");
                Console.WriteLine("4. Məhsul Sat");
                Console.WriteLine("5. İstifadəçiləri göstərin");
                Console.WriteLine("6. Satış tarixini göstərin");
                Console.WriteLine("7. Tarixlər Arasında Satışları Göstərin");
                Console.WriteLine("8. Cixis");

                int choice;
                Console.Write("Seçiminizi daxil edin: ");
                string choiceInput = Console.ReadLine();

                if (int.TryParse(choiceInput, out choice))
                {
                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                Register();
                                break;
                            case 2:
                                Login();
                                break;
                            case 3:
                                AddProduct();
                                break;
                            case 4:
                                SellProduct(null);
                                break;
                            case 5:
                                ShowUsers();
                                break;
                            case 6:
                                ShowSalesHistory();
                                break;
                            case 7:
                                ShowSalesBetweenDates();
                                break;
                            case 8:
                                Console.WriteLine("Çıxılır...");
                                return;
                            default:
                                Console.WriteLine("Yanlış seçim. Dogru nomre daxil edin.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Xəta baş verdi: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Yanlış seçim. Dogru nomre daxil edin.");
                }
            }
        }
    }
}
