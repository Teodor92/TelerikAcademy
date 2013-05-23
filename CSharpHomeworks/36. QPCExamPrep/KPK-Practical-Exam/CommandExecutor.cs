namespace SimpleSotre.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case Commands.AddBook:
                    {
                        contentCatalog.Add(new Content(Contents.Book, command.Parameters));
                        output.AppendLine("Book Added");
                    }

                    break;
                case Commands.AddMovie:
                    {
                        contentCatalog.Add(new Content(Contents.Movie, command.Parameters));
                        output.AppendLine("Movie added");
                    }

                    break;
                case Commands.AddSong:
                    {
                        contentCatalog.Add(new Content(Contents.Song, command.Parameters));
                        output.AppendLine("Song added");
                    }

                    break;
                case Commands.AddApplication:
                    {
                        contentCatalog.Add(new Content(Contents.Application, command.Parameters));
                        output.AppendLine("Application added");
                    }

                    break;
                case Commands.Update:
                    {
                        UpdateItem(contentCatalog, command, output);
                    }

                    break;
                case Commands.Find:
                    {
                        FindItem(contentCatalog, command, output);
                    }

                    break;

                default:
                    {
                        throw new ArgumentException("Unknown command!");
                    }
            }
        }

        private void UpdateItem(ICatalog contentCatalog, ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Ivalid number of paramethers!");
            }

            output.AppendLine(string.Format(
                "{0} items updated",
                contentCatalog.UpdateContent(command.Parameters[0], command.Parameters[1])));
        }

        private void FindItem(ICatalog contentCatalog, ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);
            IEnumerable<IContent> foundContent = contentCatalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}