using System;
using System.Collections.Generic;
using System.Text;

namespace meetings_app.Code
{
    public class Constants
    {
        #region Main

        public readonly static int NotificationInterval = 5000;

        public readonly static string NotificationMessage = "Назначена встреча";

        public readonly static string GreetingMessage = $"Metting application {Environment.NewLine}. To add metting enter command in format: 'add DD-MM-YY DURATION IN MINUTES [Notification before start meeting]'. " +
            $"Example: 'add 18-06-20 21:30 30 60' this command create meeting at 18-06-20 with duration 30 minutes and with notification 60 minutes before start. It command returns Id just created meeting {Environment.NewLine}" +
            $"To delete meeting enter 'delete Id' {Environment.NewLine}. To Edit meeting enter command 'edit Id DD-MM-YY DURATION IN MINUTES [Notification before start meeting]'";

        public readonly static string IntersectionExceptionMessage = "Найдены пересечения встреч!";

        public readonly static string NotFoundMessage = "Встречи не найдены";

        public const string ExportPath = @"C:\temp";
        public const string ExportFileExtension = @".txt";
        #endregion


        #region Commands

        public const string AddCommandName = "add";

        public const string DeleteCommandName = "delete";

        public const string EditStartTimeCommandName = "edit-st"; 

        public const string EditDurationCommandName = "edit-d";

        public const string EditNotificationCommandName = "edit-n";

        public const string PrintCommandName = "print";

        public const string ExportCommandName = "export";

        public static readonly string CommandsRegex = @"^(add|edit|delete) ([0-9]{2}[-]{1}[0-9]{2}[-]{1}[0-9]{2}) ([0-9]+) ([0-9]+)";

        #endregion
    }
}
