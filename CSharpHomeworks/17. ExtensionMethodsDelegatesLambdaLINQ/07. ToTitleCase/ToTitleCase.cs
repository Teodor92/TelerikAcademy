using System;
using System.Globalization;

public static class ToTitleCaseClass
{
    public static string ToTitleCase(this string input)
    {
        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        input = myTI.ToTitleCase(input);
        return input;
    }
}
