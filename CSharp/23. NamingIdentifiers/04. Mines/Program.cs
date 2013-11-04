namespace JustMines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Mine
    {
        public static void Main()
        {
            string gameCommand = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] bombsField = SetBombs();
            int pointCounter = 0;
            bool isDead = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool isNewGame = true;
            const int MaxScore = 35;
            bool hasWon = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Lets play mines! Try finding all the fields without mines." +
                    " Enter 'top' for scoreboard, 'restart' for new game and 'exit' to exit ( shocker!) !");
                    ShowField(gameField);
                    isNewGame = false;
                }

                Console.Write("Enter row and column: ");
                gameCommand = Console.ReadLine().Trim();

                if (gameCommand.Length >= 3)
                {
                    if (int.TryParse(gameCommand[0].ToString(), out row) &&
                        int.TryParse(gameCommand[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        gameCommand = "turn";
                    }
                }

                switch (gameCommand)
                {
                    case "top":
                        ShowLeaderBoard(champions);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        bombsField = SetBombs();
                        ShowField(gameField);
                        isDead = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombsField[row, column] != '*')
                        {
                            if (bombsField[row, column] == '-')
                            {
                                MakeMove(gameField, bombsField, row, column);
                                pointCounter++;
                            }

                            if (MaxScore == pointCounter)
                            {
                                hasWon = true;
                            }
                            else
                            {
                                ShowField(gameField);
                            }
                        }
                        else
                        {
                            isDead = true;
                        }

                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Error! Inavild Command!");
                        Console.WriteLine();
                        break;
                }

                if (isDead)
                {
                    ShowField(bombsField);
                    Console.WriteLine("Hrrrrrr! You died with {0} points! Enter your nickname: ", pointCounter);
                    string playerNickName = Console.ReadLine();
                    Player champion = new Player(playerNickName, pointCounter);
                    if (champions.Count < 5)
                    {
                        champions.Add(champion);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].PlayerPoints < champion.PlayerPoints)
                            {
                                champions.Insert(i, champion);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Player firstChampion, Player secondChampion) => secondChampion.Name.CompareTo(firstChampion.Name));
                    champions.Sort((Player firstChampion, Player secondChampion) => secondChampion.PlayerPoints.CompareTo(firstChampion.PlayerPoints));
                    ShowLeaderBoard(champions);

                    gameField = CreateGameField();
                    bombsField = SetBombs();
                    pointCounter = 0;
                    isDead = false;
                    isNewGame = true;
                }

                if (hasWon)
                {
                    Console.WriteLine();
                    Console.WriteLine("Uhooooo! You opened 35 cells without dying!");

                    ShowField(bombsField);

                    Console.WriteLine("Enter your nickanem: ");
                    string playerNickName = Console.ReadLine();

                    Player champion = new Player(playerNickName, pointCounter);
                    champions.Add(champion);
                    ShowLeaderBoard(champions);
                    gameField = CreateGameField();
                    bombsField = SetBombs();
                    pointCounter = 0;
                    hasWon = false;
                    isNewGame = true;
                }
            }
            while (gameCommand != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.Read();
        }

        private static void ShowLeaderBoard(List<Player> champions)
        {
            Console.WriteLine(Environment.NewLine + "Points:");

            if (champions.Count > 0)
            {
                for (int i = 0; i < champions.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} cells",
                        i + 1,
                        champions[i].Name,
                        champions[i].PlayerPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Leaderboard is empty!" + Environment.NewLine); 
            }
        }

        private static void MakeMove(
            char[,] field,
            char[,] bombsfield, 
            int row, 
            int column)
        {
            char bombsCount = GetSurroundingBombsCount(bombsfield, row, column);
            bombsfield[row, column] = bombsCount;
            field[row, column] = bombsCount;
        }

        private static void ShowField(char[,] field)
        {
            int fieldRows = field.GetLength(0);
            int fieldColumns = field.GetLength(1);

            Console.WriteLine(Environment.NewLine + "    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < fieldRows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < fieldColumns; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------" + Environment.NewLine);
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] SetBombs()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] gameField = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> bombList = new List<int>();
            while (bombList.Count < 15)
            {
                Random randomGnerator = new Random();
                int randomMine = randomGnerator.Next(50);
                if (!bombList.Contains(randomMine))
                {
                    bombList.Add(randomMine);
                }
            }

            foreach (int bomb in bombList)
            {
                int column = bomb / boardColumns;
                int row = bomb % boardColumns;
                if (row == 0 && bomb != 0)
                {
                    column--;
                    row = boardColumns;
                }
                else
                {
                    row++;
                }

                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        private static char GetSurroundingBombsCount(char[,] field, int rows, int columns)
        {
            int objectCounter = 0;
            int fieldRows = field.GetLength(0);
            int fieldColums = field.GetLength(1);

            if (rows - 1 >= 0)
            {
                if (field[rows - 1, columns] == '*')
                {
                    objectCounter++;
                }
            }

            if (rows + 1 < fieldRows)
            {
                if (field[rows + 1, columns] == '*')
                {
                    objectCounter++;
                }
            }

            if (columns - 1 >= 0)
            {
                if (field[rows, columns - 1] == '*')
                {
                    objectCounter++;
                }
            }

            if (columns + 1 < fieldColums)
            {
                if (field[rows, columns + 1] == '*')
                {
                    objectCounter++;
                }
            }

            if ((rows - 1 >= 0) && (columns - 1 >= 0))
            {
                if (field[rows - 1, columns - 1] == '*')
                {
                    objectCounter++;
                }
            }

            if ((rows - 1 >= 0) && (columns + 1 < fieldColums))
            {
                if (field[rows - 1, columns + 1] == '*')
                {
                    objectCounter++;
                }
            }

            if ((rows + 1 < fieldRows) && (columns - 1 >= 0))
            {
                if (field[rows + 1, columns - 1] == '*')
                {
                    objectCounter++;
                }
            }

            if ((rows + 1 < fieldRows) && (columns + 1 < fieldColums))
            {
                if (field[rows + 1, columns + 1] == '*')
                {
                    objectCounter++;
                }
            }

            return char.Parse(objectCounter.ToString());
        }
    }
}
