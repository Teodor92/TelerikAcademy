namespace _11.FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class FallingRocks
    {
        private static readonly Random RandomGenerator = new Random();

        // array with different types of rocks
        private static readonly char[] RockChars = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', };

        // array with different types of rock colors
        private static readonly ConsoleColor[] Colors = 
        { 
            ConsoleColor.Blue, ConsoleColor.Cyan,
            ConsoleColor.DarkBlue, ConsoleColor.DarkCyan,
            ConsoleColor.DarkGray, ConsoleColor.DarkGreen,
            ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, 
            ConsoleColor.Gray, ConsoleColor.Green,
            ConsoleColor.Magenta, ConsoleColor.Yellow
        };

        // scoring and leveling system
        private static int score;
        private static decimal speed = 400;

        internal static void Main()
        {
            // dwarf object
            var dwarf = new GameObject
            {
                CoordinateX = (Console.WindowWidth / 2) - 1,
                CoordinateY = Console.WindowHeight - 3,
                Content = "(0)",
                Color = ConsoleColor.White
            };

            // rock area list
            var rocks = new List<GameObject>();
            RemoveScrollBars();

            while (true)
            {
                bool isDead = false;

                // rock object
                var startRock = new GameObject();
                startRock.CoordinateX = RandomGenerator.Next(0, Console.WindowWidth);
                startRock.CoordinateY = 1;
                startRock.ObjectLength = RandomGenerator.Next(1, 5);
                startRock.Content = new string(RockChars[RandomGenerator.Next(1, 10)], startRock.ObjectLength);
                startRock.Color = Colors[RandomGenerator.Next(1, 12)];
                rocks.Add(startRock);

                // Top row scoring system
                WriteScoreSystem();

                // Rock area movement
                // Fixing the lag problem with a second list
                var newList = new List<GameObject>();

                foreach (var oldRock in rocks)
                {
                    GameObject newRock = new GameObject();
                    newRock.CoordinateX = oldRock.CoordinateX;
                    newRock.CoordinateY = oldRock.CoordinateY + 1;
                    newRock.ObjectLength = oldRock.ObjectLength;
                    newRock.Content = oldRock.Content;
                    newRock.Color = oldRock.Color;

                    // collison detect
                    if (newRock.CoordinateY == dwarf.CoordinateY)
                    {
                        for (int j = 0; j < newRock.ObjectLength; j++)
                        {
                            if ((newRock.CoordinateX + j == dwarf.CoordinateX) || (newRock.CoordinateX + j == dwarf.CoordinateX + 1) || (newRock.CoordinateX + j == dwarf.CoordinateX + 2))
                            {
                                isDead = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        // point and level system
                        if (speed > 0)
                        {
                            speed = speed - 0.01M;
                        }

                        score++;
                    }

                    if (newRock.CoordinateY < Console.WindowHeight)
                    {
                        newList.Add(newRock);
                    }
                }

                rocks = newList;

                // Dwarf movement and some other key functions
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();
                    if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarf.CoordinateX > 0)
                        {
                            dwarf.CoordinateX--;
                        }
                    }

                    if (keyPressed.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarf.CoordinateX < Console.WindowWidth - 3)
                        {
                            dwarf.CoordinateX++;
                        }
                    }

                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                }

                // dwarf printer
                if (isDead)
                {
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("Game Over !");
                    Console.WriteLine("Your score is {0} pt", score);
                    Environment.Exit(0);
                }
                else
                {
                    PrintStringOnPosition(dwarf.CoordinateX, dwarf.CoordinateY, dwarf.Content, dwarf.Color);
                }

                // rock printer
                foreach (GameObject rock in rocks)
                {
                    PrintStringOnPosition(rock.CoordinateX, rock.CoordinateY, rock.Content, rock.Color);
                }

                Thread.Sleep((int)speed);

                // Clear the console
                Console.Clear();
            }
        }

        private static void RemoveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        private static void PrintStringOnPosition(int x, int y, string printString, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(printString);
        }

        private static void WriteScoreSystem()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Your points: {0}", score);
            Console.Write("\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Your speed is: {0}", (int)speed);
        }
    }
}