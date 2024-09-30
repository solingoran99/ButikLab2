using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikLab2
{
	public class Customer
	{
		private string _name;
		private string _Password;

		public Customer(string name, string password)
		{
			Name = name;
			Password = password;
		}

		public string Name { get => _name; set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new InvalidOperationException("Customer name cannot be empty.");
				}
				_name = value;
			}
		}
		public string Password { get => _Password; set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new InvalidOperationException("Password cannot be empty");
				}
				_Password = value;
			}
		}

		// Customer login method
		public static Customer Login(List<Customer> customers)
		{
            Console.WriteLine("Enter your username:");
			string userName = Console.ReadLine();

            Console.WriteLine("Enter your password:");
			string userPassword = Console.ReadLine();

			Customer loggedInCustomer = customers.Find(c => c.Name == userName && c.Password == userPassword);

			if (loggedInCustomer != null)
			{
                Console.WriteLine($"Welcome back, {loggedInCustomer.Name}");
				return loggedInCustomer;
            }
			else
			{
                Console.WriteLine("Invalid username or password. Please try again.");
				return null;
            }
        }

		public static void registerCustomer(List<Customer> customers)
		{
			Console.WriteLine("To become a member create an account.\nEnter your username:");
			string userName = Console.ReadLine();

            Console.WriteLine("Enter your password:");
			string userPassword = Console.ReadLine();

			customers.Add(new Customer(userName, userPassword));
            Console.WriteLine("Successfully registered!");
        }
		
	  
		
	}
}
