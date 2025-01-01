using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CatReloaded_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("storage.txt"))
            {
                File.Create("sotrage.txt");
            }

            while (true)
            {
                Console.WriteLine("\nHi CATians, What do you want to do?");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                char choice = Convert.ToChar(Console.ReadLine());
                switch (choice)
                {

                    case '1':
                        Register();
                        break;
                    case '2':
                        Login();
                        break;
                    case '3':
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option, Try again.");
                        break;

                }


            }

        }
        static void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (File.Exists("storage.txt"))
            {
                string[] users = File.ReadAllLines("storage.txt");
                foreach (string user in users)
                {
                    string[] strings = user.Split('|');
                    if (strings[1] == email)
                    {
                        Console.WriteLine("The email is already registered!");
                        return;
                    }
                }
            }
            string newUser = $"{username}|{email}|{password}\n"; //If you only knew how much this trivial point drives me crazy because I forgot to put the "\n" at the end!
            File.AppendAllText("storage.txt", newUser);
            Console.WriteLine($"You have successfully registered, Welcome {username}");
        }
        static void Login()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (File.Exists("storage.txt"))
            {
                string[] users = File.ReadAllLines("storage.txt");
                foreach (string user in users)
                {
                    string[] strings = user.Split('|');
                    if (strings[1] == email && strings[2] == password)
                    {
                        Console.WriteLine($"You have successfully logged in, Welcome Back {strings[0]}!");
                        return;
                    }

                }
            }
            Console.WriteLine("Invalid email or password.");
        }
    }
   
}
