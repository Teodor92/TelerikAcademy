namespace StoreClasses
{
    using System;
    using System.Linq;
    using System.Text;

    public class UIDrawer
    {
        // fileds
        private int consoleWidth;

        // construtors
        public UIDrawer(int consoleWidth)
        {
            this.consoleWidth = consoleWidth;
        }

        // properites
        public int ConsoleWidth
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width is too small!");
                }

                this.consoleWidth = value;
            }
        }

        // Methods

        // Draw home menu
        public string DrawHomeMenu()
        {
            StringBuilder homeMenu = new StringBuilder();

            this.DrawBoxWithText("Welcome to OOPstore!");
            this.DrawTextWithVerticalLines("Press A to Add a product.");
            this.DrawTextWithVerticalLines("Press R to Remove a product.");
            this.DrawTextWithVerticalLines("Press Space bar to Show all products on stock.");
            this.DrawTextWithVerticalLines("Press C to show cash register contet.");
            this.DrawTextWithVerticalLines("Press S to search.");
            this.DrawTextWithVerticalLines("Press + to add money to the cash registry");
            this.DrawTextWithVerticalLines("Press - to substract money to the cash registry");
            this.DrawTextWithVerticalLines("Press H for home menu ( you are here ).");
            this.DrawDoubleLine();

            return homeMenu.ToString();
        }

        // Draw a box with text
        public void DrawBoxWithText(string text)
        {
            StringBuilder endtext = new StringBuilder();
            endtext.AppendLine(new string('=', this.consoleWidth));
            endtext.Append('|');
            endtext.Append(new string(' ', (this.consoleWidth / 2) - 1 - (text.Length / 2)));
            endtext.Append(text);
            endtext.Append(new string(' ', (this.consoleWidth / 2) - 1 - (text.Length / 2)));
            endtext.Append('|');
            endtext.AppendLine();
            endtext.Append(new string('=', this.consoleWidth));
            Console.WriteLine(endtext.ToString());
        }

        // Draw a double line
        public void DrawDoubleLine()
        {
            Console.WriteLine(new string('=', this.consoleWidth));
        }

        // Draw text with two verital lines
        public void DrawTextWithVerticalLines(string text)
        {
            StringBuilder endText = new StringBuilder();
            endText.Append('|');
            endText.Append(text);
            endText.Append(new string(' ', this.consoleWidth - text.Length - 2));
            endText.Append('|');

            Console.WriteLine(endText.ToString());
        }

        public void DrawSingleLine()
        {
            Console.WriteLine(new string('-', this.consoleWidth));
        }

        public void ColorReset()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
