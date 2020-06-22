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

            commands.Add(Constants.AddCommandName, new AddCommand());
            commands.Add(Constants.DeleteCommandName, new DeleteCommand());
            commands.Add(Constants.EditDurationCommandName, new EditDurationCommand());
            commands.Add(Constants.EditNotificationCommandName, new EditNotificationCommand());
            commands.Add(Constants.EditStartTimeCommandName, new EditStartTimeCommand());
            commands.Add(Constants.ExportCommandName, new ExportCommand());
            commands.Add(Constants.PrintCommandName, new PrintCommand());
        }

        public Command GetCommand(string name)
        {
            Command command = null;
            commands.TryGetValue(name, out command);
            return command;
        }
    }
}
