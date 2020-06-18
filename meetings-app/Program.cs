using meetings_app.Code;
using meetings_app.Models;
using System;
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
            CommandWorker commandWorker = new CommandWorker();

            while (true)
            {
                string command = Console.ReadLine();
                commandWorker.Execute(command, meetingManager);
            }
        }

        private static void Reminder_Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
