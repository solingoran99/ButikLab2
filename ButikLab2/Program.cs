using System.Net.Http.Headers;

namespace ButikLab2
{
	internal class Program
	{
		static void Main(string[] args)
		{   // list of customers
			List<Customer> customers = new List<Customer>
			{
				new Customer("Knatte", "123"),
				new Customer("Fnatte", "321"),
				new Customer("Tjatte", "213")
			};

			

			bool running = true;
			while (running)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Magenta;
			    Console.WriteLine("Welcome to Lush Locks! To see our newest releases, hurry up and join!");
			    Console.ResetColor();

				Console.WriteLine("1.Log in\n2.Become a member\n3.Exit\nEnter the corresponding number:");
				string userInput = Console.ReadLine();
				int userChoice;
				

				if (int.TryParse(userInput, out userChoice))
				{    // handle user choice
					switch (userChoice)
					{
						case 1:
							Console.Clear();
							Console.WriteLine("Please log in:");
							//call login method
							Customer loggedInCustomer = Customer.Login(customers);
							Console.WriteLine("Press enter to go back to the menu");
							Console.ReadKey();
							break;
						case 2:
							Console.Clear();
							//Call registeration method
							Customer.registerCustomer(customers);
							Console.WriteLine("Press enter to go back to the menu");
							Console.ReadKey();
							break;
						case 3:
							Console.WriteLine("Thank you for your visit!");
							//set to false and break the loop
							running = false;
							break;
						default:
							Console.WriteLine("Invalid choice. Choose 1, 2 or 3.");
							break;

					}
				}
				else
				{
					Console.WriteLine("OOPS error! Please enter a number.");
				}

		

			}
			
		}
    } 
}

