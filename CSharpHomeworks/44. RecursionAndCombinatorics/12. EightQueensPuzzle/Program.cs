namespace EightQueenPuzzle
{
    using System;

    public class EightQueenPuzzle
    {
        public static void Main()
        {
            int queensCount = 8;
            int solutionsCount = 0;
            int[] position = new int[queensCount];
            Solve(0, queensCount, position, ref solutionsCount);
        }

        public static void Solve(int currentQueen, int queensCount, int[] positions, ref int solutionCount)
        {
            if (currentQueen == queensCount)
            {
                PrintField(positions, ref solutionCount);
            }
            else
            {
                for (int pos = 0; pos < queensCount; pos++)
                {
                    if (IsValid(currentQueen, pos, positions))
                    {
                        positions[currentQueen] = pos;
                        Solve(currentQueen + 1, queensCount, positions, ref solutionCount);
                    }
                }
            }
        }

        public static bool IsValid(int currentQueen, int position, int[] positions)
        {
            for (int i = 1; i <= currentQueen; i++)
            {
                int other = positions[currentQueen - i];
                if (other == position || other == position - i || other == position + i)
                {
                    return false;
                }
            }

            return true;
        }

        public static void PrintField(int[] inputField, ref int solutionCount)
        {
            char[,] field = new char[inputField.Length, inputField.Length];

            for (int i = 0; i < inputField.Length; i++)
            {
                field[inputField[i], i] = 'Q';
            }

            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            Console.WriteLine("Solution: {0}", ++solutionCount);
            Console.WriteLine("--------------");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (field[i, j] == 'Q')
                    {
                        Console.Write("{0, 3}", "Q");
                    }
                    else
                    {
                        Console.Write("{0, 3}", "*");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}