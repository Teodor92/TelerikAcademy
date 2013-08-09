namespace MED
{
    /*
     * Task02
     *
     * Write a program to calculate the "Minimum Edit Distance" (MED) between two words.
     * MED(x, y) is the minimal sum of costs of edit operations used to transform x to y. Sample costs are given below:
     * cost (replace a letter) = 1
     * cost (delete a letter) = 0.9
     * cost (insert a letter) = 0.8
     *
     * Example:
     * x = "developer", y = "enveloped" -> cost = 2.7
     * delete ‘d’:  "developer" -> "eveloper", cost = 0.9
     * insert ‘n’:  "eveloper" -> "enveloper", cost = 0.8
     * replace ‘r’ -> ‘d’:  "enveloper" -> "enveloped", cost = 1
     */

    using System;
    using System.Text;

    public class MEDMain
    {
        private const double ReplaceCost = 1;
        private const double DeleteCost = 0.9;
        private const double InsertCost = 0.8;

        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the initial word:");
            string initialWord = Console.ReadLine();
            Console.WriteLine("Please enter the target word:");
            string targetWord = Console.ReadLine();

            int[,] matrixOfLCS = BuildMatrixOfLongestCommonSet(targetWord, initialWord);

            PrintLCSMatrix(matrixOfLCS, targetWord, initialWord);

            double transformCost = CalcTransformCost(matrixOfLCS, targetWord, initialWord);

            Console.WriteLine("The transformation cost is: {0}", transformCost);
        }

        private static void PrintLCSMatrix(int[,] matrixOfLCS, string targetWord, string initialWord)
        {
            StringBuilder matrixToPrint = new StringBuilder();

            matrixToPrint.Append("      ");

            for (int i = 0; i < initialWord.Length; i++)
            {
                matrixToPrint.Append(initialWord[i] + ", ");
            }

            matrixToPrint.Length -= 2;
            matrixToPrint.AppendLine();

            for (int i = 0; i < matrixOfLCS.GetLength(0); i++)
            {
                if (i > 0)
                {
                    matrixToPrint.Append(targetWord[i - 1] + ": ");
                }
                else
                {
                    matrixToPrint.Append("   ");
                }

                for (int j = 0; j < matrixOfLCS.GetLength(1); j++)
                {
                    matrixToPrint.Append(matrixOfLCS[i, j] + ", ");
                }

                matrixToPrint.Length -= 2;
                matrixToPrint.AppendLine();
            }

            Console.WriteLine(matrixToPrint.ToString());
        }

        private static double CalcTransformCost(int[,] matrixOfLCS, string targetWord, string initialWord)
        {
            double transformCost = 0;

            int currentX = matrixOfLCS.GetLength(0) - 1;
            int currentY = matrixOfLCS.GetLength(1) - 1;

            while (currentX != 0 && currentY != 0)
            {
                if (targetWord[currentX - 1] == initialWord[currentY - 1])
                {
                    currentX--;
                    currentY--;
                }
                else if (matrixOfLCS[currentX - 1, currentY] == matrixOfLCS[currentX, currentY - 1])
                {
                    transformCost += ReplaceCost;
                    currentX--;
                    currentY--;
                }
                else if (matrixOfLCS[currentX - 1, currentY] > matrixOfLCS[currentX, currentY - 1])
                {
                    transformCost += InsertCost;
                    currentX--;
                }
                else
                {
                    transformCost += DeleteCost;
                    currentY--;
                }
            }

            if (currentX > 0)
            {
                transformCost += currentX * InsertCost;
            }

            if (currentY > 0)
            {
                transformCost += currentY * DeleteCost;
            }

            return transformCost;
        }

        private static int[,] BuildMatrixOfLongestCommonSet(string targetWord, string initialWord)
        {
            int[,] matrixOfLCS = new int[targetWord.Length + 1, initialWord.Length + 1];

            for (int i = 1; i <= targetWord.Length; i++)
            {
                bool letterMatched = false;
                for (int j = 1; j <= initialWord.Length; j++)
                {
                    if ((!letterMatched) && (targetWord[i - 1] == initialWord[j - 1]))
                    {
                        matrixOfLCS[i, j] = matrixOfLCS[i, j - 1] + 1;
                        letterMatched = true;
                    }
                    else
                    {
                        matrixOfLCS[i, j] = Math.Max(matrixOfLCS[i - 1, j], matrixOfLCS[i, j - 1]);
                    }
                }
            }

            return matrixOfLCS;
        }
    }
}