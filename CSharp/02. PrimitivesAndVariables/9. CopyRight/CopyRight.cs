// Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
//Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly.

using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        int copyRignt = 169;
        byte spaceing = 2;
        for (int rows = 0; rows < 3; rows++)
        {
            for (int spaceCounter = 0; spaceCounter < spaceing; spaceCounter++) 
            {
                Console.Write(" ");
            }
            for (int cols = 0; cols <= rows; cols++)
            {
                Console.Write((char)copyRignt);
            }
            for (int cols = 0; cols <= rows - 1; cols++)
            {
                Console.Write((char)copyRignt);
            }
            spaceing--;
            Console.WriteLine();
        }
    }
}

