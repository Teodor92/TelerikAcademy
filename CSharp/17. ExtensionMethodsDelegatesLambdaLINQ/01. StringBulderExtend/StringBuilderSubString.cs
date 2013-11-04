using System;
using System.Text;

public static class StringBuilderSubString
{
    public static StringBuilder SubString(this StringBuilder input, int index, int length)
    {
        StringBuilder subString = new StringBuilder();

        if (index + length - 1 >= input.Length || index < 0)
        {
            throw new ArgumentOutOfRangeException("Out of range");
        }

        int endIndex = index + length;

        for (int i = index; i < endIndex; i++)
        {
            subString.Append(input[i]);
        }

        return subString;
    }

    public static StringBuilder SubString(this StringBuilder input, int startIndex)
    {
        StringBuilder subString = new StringBuilder();

        if (startIndex < 0 || startIndex >= input.Length)
        {
            throw new ArgumentOutOfRangeException("Out of range");
        }

        for (int i = startIndex; i < input.Length; i++)
        {
            subString.Append(input[i]);
        }

        return subString;
    }
}