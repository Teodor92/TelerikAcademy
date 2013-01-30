using System;
using System.Collections.Generic;

static class Mesuires
{
    static List<Tuple<string, decimal>> converterToCups = new List<Tuple<string, decimal>>();
    static Mesuires()
    {
        converterToCups.Add(new Tuple<string, decimal>("tablespoons", 1.0M / 16.0M));
        converterToCups.Add(new Tuple<string, decimal>("tbsps", 1.0M / 16.0M));
        converterToCups.Add(new Tuple<string, decimal>("teaspoons", 1.0M / 48.0M));
        converterToCups.Add(new Tuple<string, decimal>("tsps", 1.0M / 48.0M));
        converterToCups.Add(new Tuple<string, decimal>("milliliters", 1.0M / 240.0M));
        converterToCups.Add(new Tuple<string, decimal>("mls", 1.0M / 240.0M));
        converterToCups.Add(new Tuple<string, decimal>("liters", 25.0M / 6.0M));
        converterToCups.Add(new Tuple<string, decimal>("ls", 25.0M / 6.0M));
        converterToCups.Add(new Tuple<string, decimal>("fluid ounces", 1.0M / 8.0M));
        converterToCups.Add(new Tuple<string, decimal>("fl ozs", 1.0M / 8.0M));
        converterToCups.Add(new Tuple<string, decimal>("pints", 2.0M));
        converterToCups.Add(new Tuple<string, decimal>("pts", 2.0M));
        converterToCups.Add(new Tuple<string, decimal>("quarts", 4.0M));
        converterToCups.Add(new Tuple<string, decimal>("qts", 4.0M));
        converterToCups.Add(new Tuple<string, decimal>("gallons", 16.0M));
        converterToCups.Add(new Tuple<string, decimal>("gals", 16.0M));
        converterToCups.Add(new Tuple<string, decimal>("cups", 1.0M));
    }
}

class Cooking
{
    
    static void Main()
    {
        
    }
}
