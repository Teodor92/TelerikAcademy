namespace TestProgram
{
    using System;
    using System.Linq;
    using StoreClasses;

    public class OOPStoreMain
    {
        public static void Main()
        {
            Console.WindowWidth = 120;
            IUserInterface keyboard = new KeyboardInterface();
            UIDrawer drawer = new UIDrawer(Console.WindowWidth - 4);
            Store myStore = new Store(keyboard);

            // Show home menu
            keyboard.OnHPressed += (sender, eventInfo) =>
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(drawer.DrawHomeMenu());
            };

            // Show store content of storage
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.White;
                drawer.DrawBoxWithText("Storage content:");
                Console.WriteLine(myStore.Show());
            };

            // Remove menu
            keyboard.OnRPressed += (sender, eventInfo) =>
            {
                Console.ForegroundColor = ConsoleColor.White;

                // name input and validation
                drawer.DrawSingleLine();

                Console.WriteLine("Enter 1 to remove a Movie");
                Console.WriteLine("Enter 2 to remove a Game");

                drawer.DrawSingleLine();

                int productTypeChoice = 0;

                // choise validation
                while (!int.TryParse(Console.ReadLine(), out productTypeChoice) || (productTypeChoice != 1 && productTypeChoice != 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Try again!");
                    drawer.ColorReset();
                }

                if (productTypeChoice == 1)
                {
                    // removeing opertaion
                    try
                    {
                        drawer.DrawSingleLine();

                        Console.WriteLine("Enter 1 to remove 1 movie.");
                        Console.WriteLine("Enter 2 to remove all stock for the current game.");

                        drawer.DrawSingleLine();

                        // TODO: Make validation
                        int methodChoise = 0;
                        while (!int.TryParse(Console.ReadLine(), out methodChoise) || (methodChoise != 1 && methodChoise != 2))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input! Try again!");
                            drawer.ColorReset();
                        }

                        // main logic
                        if (methodChoise == 1)
                        {
                            drawer.DrawBoxWithText("Enter Movie Name");
                            string name = Console.ReadLine();

                            // id input and validation
                            drawer.DrawBoxWithText("Enter Movie ID");
                            int id = 0;
                            while (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorect ID! Try again!");
                                drawer.ColorReset();
                            }

                            myStore.RemoveObject(new Movie(name, id));

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Movie removed");
                            drawer.ColorReset();
                        }
                        else if (methodChoise == 2)
                        {
                            drawer.DrawBoxWithText("Enter Movie Name");
                            string name = Console.ReadLine();

                            // id input and validation
                            drawer.DrawBoxWithText("Enter Movie ID");
                            int id = 0;
                            while (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorect ID! Try again!");
                                drawer.ColorReset();
                            }

                            myStore.RemoveAll(new Movie(name, id));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Movies removed");
                            drawer.ColorReset();
                        }
                        else
                        {
                            Console.WriteLine("Wrong input! Try again!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (productTypeChoice == 2)
                {
                    // removeing opertaion
                    try
                    {
                        drawer.DrawSingleLine();

                        Console.WriteLine("Enter 1 to remove 1 game.");
                        Console.WriteLine("Enter 2 to remove all stock for the current game.");

                        drawer.DrawSingleLine();

                        var choise = int.Parse(Console.ReadLine());

                        if (choise == 1)
                        {
                            drawer.DrawBoxWithText("Enter Game Name");
                            string name = Console.ReadLine();

                            // id input and validation
                            drawer.DrawBoxWithText("Enter Game ID");
                            int id = 0;
                            while (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorect ID! Try again!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            myStore.RemoveObject(new Game(name, id));

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Game removed");
                        }
                        else if (choise == 2)
                        {
                            drawer.DrawBoxWithText("Enter Game Name");
                            string name = Console.ReadLine();

                            // id input and validation
                            drawer.DrawBoxWithText("Enter Game ID");
                            int id = 0;
                            while (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorect ID! Try again!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            myStore.RemoveObject(new Game(name, id));

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Game removed");
                            myStore.RemoveAll(new Game(name, id));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Product removed");
                        }
                        else
                        {
                            Console.WriteLine("Wrong input! Try again!");
                        }
                    }
                    catch (NoProductsException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again!");
                }
            };

            // Add a product menu
            keyboard.OnAPressed += (sender, eventInfo) =>
            {
                drawer.ColorReset();
                drawer.DrawBoxWithText("Enter Product Name");

                string name = Console.ReadLine();
                string choise = string.Empty;

                Console.WriteLine("Enter | 1 | for Game.");
                Console.WriteLine("Press | 2 | for Movie");

                int productTypeChoice = 0;

                // choise validation
                while (!int.TryParse(Console.ReadLine(), out productTypeChoice) || (productTypeChoice != 1 && productTypeChoice != 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Try again!");
                    drawer.ColorReset();
                }

                if (productTypeChoice == 1)
                {
                    try
                    {
                        Console.WriteLine("If you want to Add additional information about this Movie Enter Y:");
                        choise = Console.ReadLine().ToLower();
                        if (choise != "y")
                        {
                            myStore.AddObject(new Game(name));
                        }
                        else if (choise == "y")
                        {
                            int id = 0, year = 0;
                            decimal price = 0;

                            Console.Write("ID: ");

                            // Validation
                            while (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorect ID! Try again!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.Write("Price: ");

                            // Validation
                            while (!decimal.TryParse(Console.ReadLine(), out price))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid price! Try again!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.Write("Creator: ");
                            string creator = Console.ReadLine();

                            Console.Write("Platform: ");
                            string platform = Console.ReadLine();

                            Console.Write("Year: ");

                            // Validation
                            while (!int.TryParse(Console.ReadLine(), out year))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Year! Try again!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            myStore.AddObject(new Game(name, id, price, creator, year, platform));
                        }
                        else
                        {
                            myStore.AddObject(new Game(name));
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Product Added");
                    }
                    catch (ArgumentException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ivalid prdouct argumet! Try again! {0}", e.Message);
                        drawer.ColorReset();
                    }
                }
                else
                {
                    Console.Write("If you want to Add additional information about this Movie enter Y ");
                    choise = Console.ReadLine().ToLower();

                    try
                    {
                        if (choise == "y")
                        {
                            int id = 0, year = 0, movieLength = 0;
                            decimal price = 0;
                            Console.Write("ID: ");

                            // Validation
                            while (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorect ID! Try again!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.Write("Price: ");

                            // Validation
                            while (!decimal.TryParse(Console.ReadLine(), out price))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid price! Try again!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.Write("Movie length: ");
                            while (!int.TryParse(Console.ReadLine(), out movieLength))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid movie length! Try again!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.Write("Actor: ");
                            string actor = Console.ReadLine();

                            Console.Write("Year: ");
                            while (!int.TryParse(Console.ReadLine(), out year))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorect year! Try again!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            myStore.AddObject(new Movie(name));
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Product Added");
                    }
                    catch (ArgumentException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ivalid prdouct argumet! Try again! {0}", e.Message);
                        drawer.ColorReset();
                    }
                }
            };

            // Search
            keyboard.OnSPressed += (sender, eventInfo) =>
            {
                drawer.ColorReset();
                drawer.DrawSingleLine();

                Console.WriteLine("For search by ID press | 1 |");
                Console.WriteLine("For search by Name press | 2 |");

                drawer.DrawSingleLine();

                // validation
                int searchChoice = 0;
                while (!int.TryParse(Console.ReadLine(), out searchChoice) || (searchChoice != 1 && searchChoice != 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Try again!");
                    drawer.ColorReset();
                }

                if (searchChoice == 1)
                {
                    drawer.DrawBoxWithText("Enter a ID");

                    int id = 0;
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorect ID! Try again!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    drawer.DrawBoxWithText("Enter a Name");

                    string name = Console.ReadLine();
                    myStore.SearchByName(name);
                }
            };

            // Show cash register content
            keyboard.OnCPressed += (sender, eventInfo) =>
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;

                drawer.DrawBoxWithText("Cash register content");
                Console.WriteLine(myStore.ShowCashRegister());

                drawer.ColorReset();
            };

            // Add cash form reg
            keyboard.OnPlusPressed += (sender, eventInfo) =>
            {
                drawer.DrawBoxWithText("Adding money to registry.");
                Console.WriteLine("Enter sum");

                decimal sum = decimal.Parse(Console.ReadLine());
                myStore.AddMoneyToCashReg(sum);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Money added!");
                drawer.ColorReset();
            };

            keyboard.OnMinusPressed += (sender, eventInfo) =>
            {
                drawer.DrawBoxWithText("Substarcting money to registry.");

                Console.WriteLine("Enter sum");

                decimal sum = decimal.Parse(Console.ReadLine());
                myStore.RemoveMoneyFromCashReg(sum);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Money substracted!");
                drawer.ColorReset();
            };

            // start the store
            myStore.StartStore();
        }
    }
}
