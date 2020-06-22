using meetings_app.Code;
using meetings_app.Models;
using System;
using System.Linq;
using System.Reflection.Metadata;

namespace meetings_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.GreetingMessage);

            MeetingManager meetingManager = new MeetingManager();
            meetingManager.Reminder.Notify += Reminder_Notify;
            var commandFactory = new CommandFactory();

            while (true)
            {
                string userInput = Console.ReadLine();
                var values = userInput.Split(" ");
                string commandName = values.First();
                commandFactory.GetCommand(commandName).Execute(meetingManager, values);
            }
        }

        private static void Reminder_Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
