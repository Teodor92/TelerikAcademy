using System;
using System.Linq;
using System.Text;

namespace SimpleSotre.Common
{
    public interface ICommand
    {
        Commands Type { get; set; }

        string OriginalForm { get; set; }

        string Name { get; set; }

        string[] Parameters { get; set; }

        Commands ParseCommandType(string commandName);

        string ParseName();

        string[] ParseParameters();
    }
}
