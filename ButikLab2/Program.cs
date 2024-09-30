﻿using System.Net.Http.Headers;

namespace ButikLab2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//List of products

			List<Product> products = new List<Product>
			{
				new Product("Lush Shampoo","Repairs and adds volume for soft, bouncy hair.", 119.00 ),
				new Product("Lush Conditioner", "Nourishes and hydrates for smooth, manageable hair.", 112.00),
				new Product("Lush Hair Mask", "Overnight hair treatment for frizz control and shine", 219.20),
				new Product("Lush Scalp Serum", "Repair hair serum", 99.00),
				new Product("Lush Hair Oil", "Strengthensand adds shine for quick growth", 269.00)
			};
			// list of customers
			List<Customer> customers = new List<Customer>
			{
				new Customer("Knatte", "123"),
				new Customer("Fnatte", "321"),
				new Customer("Tjatte", "213")
			};

			

			bool running = true;
			Customer loggedInCustomer = null;
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
							//call login method
						    loggedInCustomer = Customer.Login(customers);
							if(loggedInCustomer != null)
							{
								ShoppingMenu(loggedInCustomer, products);
							}
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

		static void ShoppingMenu(Customer customer, List<Product> products)
		{
			bool shopping = true;

			//Shopping menu

			while (shopping)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Lush Locks");
				Console.ResetColor();
                Console.WriteLine("1.Shop\n2.View Cart\n3.Check Out\n4.Log Out");
				string shoppingInput = Console.ReadLine();
				int shoppingChoice;

				if(int.TryParse(shoppingInput, out shoppingChoice))
				{
					switch (shoppingChoice)
					{
						case 1:
						    bool continueShopping = true;
							while (continueShopping)
							{
								Product.DisplayProducts(products);
                                Console.WriteLine("\nEnter the name of the product to add to your cart:\nType 'exit' to stop shopping.");
						        string productInput = Console.ReadLine();

								if (productInput.Trim().ToLower().Equals("exit", StringComparison.OrdinalIgnoreCase))
								{
									continueShopping = false;
									break;
								}

								Product selectedProduct = products.Find(p => p.Name.Equals(productInput.ToLower().Trim(), StringComparison.OrdinalIgnoreCase));
								if (selectedProduct != null)
								{
									customer.Cart.Add(selectedProduct);
									Console.WriteLine($"{selectedProduct.Name} has been added to your cart.");
								}
								else
								{
									Console.WriteLine("Product wasn't found");
								}

                                Console.WriteLine("Press ebter to continue shopping");
								Console.ReadKey();

                            }
							break;

						case 2:
						customer.ViewCart();
						break;

                        case 3:
                        Console.WriteLine("checkout");
						break ;

						case 4:
						shopping = false;
						break;

						default:
                        Console.WriteLine("Invalid choice");
						break;

                    }
				}

				else
				{
                    Console.WriteLine("Invalid, enter a ");
                }
            }
		}
    } 
}

