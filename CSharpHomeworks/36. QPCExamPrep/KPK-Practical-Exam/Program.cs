namespace SimpleSotre.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExcutor = new CommandExecutor();

            foreach (ICommand item in Parse())
            {
                commandExcutor.ExecuteCommand(catalog, item, output);
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(output);
        }

        private static List<ICommand> Parse()
        {
            List<ICommand> commands = new List<ICommand>();
            bool isCommandsEnd = false;

            do
            {
                string line = Console.ReadLine();
                isCommandsEnd = (line.Trim() == "End");

                if (!isCommandsEnd)
                {
                    commands.Add(new Command(line));
                }
            }
            while (!isCommandsEnd);

            return commands;
        }
    }
}
