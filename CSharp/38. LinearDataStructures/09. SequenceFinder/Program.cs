namespace SequenceFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            int n = 2; 
            Queue<int> queue = new Queue<int>();
            StringBuilder output = new StringBuilder();
            queue.Enqueue(n);

            for (int i = 0; i < 13; i++)
            {
                int current = queue.Dequeue();

                output.AppendFormat("{0}, {1}, {2}, ", current + 1, (2 * current) + 1, current + 2);

                queue.Enqueue(current + 1);
                queue.Enqueue((2 * current) + 1);
                queue.Enqueue(current + 2);
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(output.ToString().Trim(' ', ','));

            Console.ResetColor();
        }
    }
}
