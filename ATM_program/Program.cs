using System;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATM_program
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            int a = 0;
            int b = 0;
            int c = 0;

            char action = 'y';
            while (action == 'y')
            {
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Sign in");
                Console.WriteLine("3. Keep");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Welcome! Please create an account.");

                        Console.Write("Enter your login: ");
                        string login = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();

                        users.Add(login, password);

                        Console.WriteLine("Account created successfully!");
                        break;

                    case 2:
                        Console.Write("Enter your login: ");
                        string inputLogin = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string inputPassword = Console.ReadLine();

                        if (users.ContainsKey(inputLogin) && users[inputLogin] == inputPassword)
                        {
                            Console.WriteLine("1.To replenish");
                            Console.WriteLine("2. Withdraw");
                            Console.WriteLine("3. View balance");

                            int aa;
                            if (!int.TryParse(Console.ReadLine(), out aa))
                            {
                                Console.WriteLine("Invalid input. Try again.");
                                continue;
                            }

                            switch (aa)
                            {
                                case 1:
                                    Console.WriteLine("Enter the amount to top up:");
                                    int depositAmount;
                                    if (!int.TryParse(Console.ReadLine(), out depositAmount))
                                    {
                                        Console.WriteLine("Invalid input. Try again.");
                                        continue;
                                    }
                                    c += depositAmount;
                                    Console.WriteLine($"The balance was replenished by: {depositAmount}");
                                    break;
                                    break;

                                case 2:
                                    Console.WriteLine("Enter the amount to withdraw:");
                                    int withdrawAmount;
                                    if (!int.TryParse(Console.ReadLine(), out withdrawAmount))
                                    {
                                        Console.WriteLine("Invalid input. Try again.");
                                        continue;
                                    }
                                    b += withdrawAmount;
                                    c = c - withdrawAmount;
                                    if(c< withdrawAmount)
                                    {
                                        Console.WriteLine("insufficient funds ");
                                    }
                                    
                                    break;

                                case 3:
                                    Console.WriteLine($"Your Balance: {c}");
                                    break;

                                default:
                                    Console.WriteLine("Wrong choice. Try again.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid login or password.");
                        }
                        break;

                    case 3:
                        action = 'n';
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Wrong choice. Try again.");
                        break;
                }
            }
        }
    }
}