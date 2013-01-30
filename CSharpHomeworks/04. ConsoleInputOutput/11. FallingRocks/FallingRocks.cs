using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class FallingRocks
{
    static Random randomGenerator = new Random();
    // scoring and leveling system
    static int score = 0;
    static int currentLevel = 0;
    static int levelReached = 1;
    static decimal speed = 400;
    // array with different types of rocks
    static char[] rockChars = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';',};
    // array with different types of rock colors
    static ConsoleColor[] color = 
    { 
        ConsoleColor.Blue, ConsoleColor.Cyan,
        ConsoleColor.DarkBlue, ConsoleColor.DarkCyan,
        ConsoleColor.DarkGray, ConsoleColor.DarkGreen,
        ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, 
        ConsoleColor.Gray, ConsoleColor.Green,
        ConsoleColor.Magenta, ConsoleColor.Yellow
    };
    struct Object
    {
        public int x;
        public int y;
        public int objLen;
        public string c;
        public ConsoleColor color;
    }
    static void RemoveScrollBars()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }
    static void StringPrinter(int x, int y, string PrintString, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(PrintString);
    }
    static void ScoringSystem()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Your points: {0}", score);
        Console.Write("\t");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" Your speed is: {0}", (int)speed);
    }
    static void ColisoionDetect()
    { }
    static void Main()
    {
        // dwarf object
        Object dwarf = new Object();
        dwarf.x = Console.WindowWidth / 2 - 1;
        dwarf.y = Console.WindowHeight - 3;
        dwarf.c = "(0)";
        dwarf.color = ConsoleColor.White;
        //rock area list
        List<Object> rocks = new List<Object>();
        RemoveScrollBars();
        while (true)
        {
            bool isDead = false;
            //rock object
            Object startRock = new Object();
            startRock.x = randomGenerator.Next(0, Console.WindowWidth);
            startRock.y = 1;
            startRock.objLen = randomGenerator.Next(1,5);
            startRock.c = new string(rockChars[randomGenerator.Next(1, 10)], startRock.objLen);
            startRock.color = color[randomGenerator.Next(1, 12)];
            rocks.Add(startRock);
            // Top row scoring system
            ScoringSystem();
            // Rock area movement
                // Fixing the lag problem with a second list
            List<Object> newList = new List<Object>();
            for (int i = 0; i < rocks.Count; i++)
            {
                Object oldRock = rocks[i];
                Object newRock = new Object();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.objLen = oldRock.objLen;
                newRock.c = oldRock.c;
                newRock.color = oldRock.color;
                //collison detect
                if (newRock.y == dwarf.y)
                {
                    for (int j = 0; j < newRock.objLen; j++)
                    {
                        if ((newRock.x + j == dwarf.x) || (newRock.x + j == dwarf.x + 1) || (newRock.x + j == dwarf.x + 2))
                        {
                            isDead = true;
                            break;
                        }
                    }
                }
                else
                {
                    //point and level system
                    if (speed > 0)
                    {
                        speed = speed - 0.01M;   
                    }
                    score++;
                }
                if (newRock.y < Console.WindowHeight)
                {
                    newList.Add(newRock);
                } 
            }
            rocks = newList;
            //Dwarf movement and some other key functions
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x > 0)
                    {
                        dwarf.x--;   
                    }
                }
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x < Console.WindowWidth - 3)
                    {
                        dwarf.x++;                        
                    }
                }
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
            //dwarf printer
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
                StringPrinter(dwarf.x, dwarf.y, dwarf.c, dwarf.color);
            }
            //rock printer
            foreach (Object rock in rocks)
            {
                StringPrinter(rock.x, rock.y, rock.c, rock.color);
            }
            Thread.Sleep((int)speed);
            //Clear the console
            Console.Clear();
        }
    }
}