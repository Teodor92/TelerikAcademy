using System;
using System.Collections.Generic;

public static class IEnumerableExtends
{
    public static dynamic Sum(this IList<> input)
    {
        dynamic sum = 0;

        foreach (var item in input)
        {
            sum += item;
        }

        return sum;
    }
}
