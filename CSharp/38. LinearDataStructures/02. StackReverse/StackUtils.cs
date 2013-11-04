namespace StackReverse
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class StackUtils
    {
        public static string ReverseNumbers(Stack<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentNullException("Stack must not be empty!");
            }

            StringBuilder output = new StringBuilder();

            int startCount = numbers.Count;

            for (int i = 0; i < startCount; i++)
            {
                output.AppendFormat("{0}, ", numbers.Pop());
            }

            return output.ToString().Trim(' ', ',');
        }
    }
}
