using meetings_app.Code;
using System;
using System.Collections.Generic;
using System.Text;

namespace meetings_app.Models
{
    public class CommandFactory
    {
        Dictionary<string, Command> commands = null;

        public CommandFactory()
        {
            commands = new Dictionary<string, Command>();
        }

        public CommandFactory AddCommand(string name, Command command)
        {
            commands.Add(name, command);
            return this;
        }

        public Command GetCommand(string name)
        {
            Command command = null;
            commands.TryGetValue(name, out command);
            return command;
        }
    }
}
