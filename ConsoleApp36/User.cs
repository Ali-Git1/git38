using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
        public List<string> ShoppingHistory { get; set; }

        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            UserRole = role;
            ShoppingHistory = new List<string>();
        }

        public void AddToShoppingHistory(string item)
        {
            ShoppingHistory.Add(item);
        }

        public void ViewShoppingHistory()
        {
            Console.WriteLine($"Alis-Veris Tarixcesi {Username}:");
            foreach (var item in ShoppingHistory)
            {
                Console.WriteLine(item);
            }
        }
    }

    public enum Role
    {
        Admin,
        Moderator,
        User
    }


}
