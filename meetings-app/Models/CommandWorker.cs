using meetings_app.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace meetings_app.Models
{
    public class CommandWorker
    {
        public void Execute(string value, MeetingManager meetingManager)
        {
            var values = value.Split(" ");
            string commandName = values.First();

            switch (commandName)
            {
                case Constants.AddCommandName:
                    var startTime = $"{values.Skip(1).First()} {values.Skip(2).First()}";
                    var duration = values.Skip(3).First();
                    var notifyBefore = values.Skip(4).FirstOrDefault();

                    AddAction(startTime, duration, meetingManager, notifyBefore);

                    break;

                case Constants.DeleteCommandName:
                    string id = values.Skip(1).First();

                    DeleteAction(meetingManager, id);
                    break;

                case Constants.EditStartTimeCommandName:
                    id = values.Skip(1).First();
                    startTime = values.Skip(2).First();

                    EditStartTimeAction(meetingManager, id, startTime);
                    break;

                case Constants.EditDurationCommandName:
                    id = values.Skip(1).First();
                    duration = values.Skip(2).First();

                    EditDurationAction(meetingManager, id, duration);
                    break;

                case Constants.EditNotificationCommandName:
                    string meetingId = values.Skip(1).First();
                    string notifyBeforeInMinutes = values.Skip(2).First();

                    EditNotificationAction(meetingManager, meetingId, notifyBeforeInMinutes);
                    break;

                case Constants.PrintCommandName:
                    string printDate = values.Skip(1).First();

                    PrintAction(meetingManager, printDate);
                    break;

                case Constants.ExportCommandName:
                    string exportDate = values.Skip(1).First();

                    ExportAction(meetingManager, exportDate);
                    break;

                default:
                    break;
            }
        }

        private void AddAction(string startTime, string duration, MeetingManager meetingManager, string notifyBefore)
        {
            Meeting meeting = new Meeting()
            {
                StartTime = DateTime.Parse(startTime),
                DurationMinutes = int.Parse(duration)
            };

            meetingManager.Repository.Add(meeting);


            if (notifyBefore != string.Empty && notifyBefore != null)
            {
                var notification = new Notification() { NotifyBeforeInMinutes = int.Parse(notifyBefore) };
                meetingManager.Reminder.Repository.Add(notification);
            }
        }

        private void DeleteAction(MeetingManager meetingManager, string id)
        {
            meetingManager.Repository.Delete(int.Parse(id));
            meetingManager.Reminder.Repository.DeleteByMeetingId(int.Parse(id));
        }

        private void EditStartTimeAction(MeetingManager meetingManager, string id, string startTime)
        {
            var meeting = meetingManager.Repository.All().FirstOrDefault(x => x.Id == int.Parse(id));

            if (meeting == null)
                return;

            meeting.StartTime = DateTime.Parse(startTime);
            meetingManager.Repository.Update(meeting);
        }

        private void EditDurationAction(MeetingManager meetingManager, string id, string duration)
        {
            var meeting = meetingManager.Repository.All().FirstOrDefault(x => x.Id == int.Parse(id));

            if (meeting == null)
                return;

            meeting.DurationMinutes = int.Parse(duration);
            meetingManager.Repository.Update(meeting);
        }

        private void EditNotificationAction(MeetingManager meetingManager, string meetingId, string notifyBeforeInMinutes)
        {
            var meeting = meetingManager.Repository.All().FirstOrDefault(x => x.Id == int.Parse(meetingId));

            if (meeting == null)
                return;

            var notification = meetingManager.Reminder.Repository.All().FirstOrDefault(x => x.MeetingId == int.Parse(meetingId));

            if (notification == null)
                return;

            notification.NotifyBeforeInMinutes = int.Parse(notifyBeforeInMinutes);
            meetingManager.Reminder.Repository.Update(notification);
        }

        private void PrintAction(MeetingManager meetingManager, string printDate)
        {
            var meetings = meetingManager.Repository.All().Where(x => x.StartTime.Date == DateTime.Parse(printDate));

            if (meetings == null || meetings.Count() == 0)
            {
                Console.WriteLine(Constants.NotFoundMessage);
                return;
            }

            foreach (var m in meetings)
            {
                Console.WriteLine($"{nameof(m.Id)} {m.Id} {nameof(m.StartTime)} {m.StartTime}");
            }
        }

        private void ExportAction(MeetingManager meetingManager, string exportDate)
        {
            var meetings = meetingManager.Repository.All().Where(x => x.StartTime.Date == DateTime.Parse(exportDate));

            if (meetings == null || meetings.Count() == 0)
            {
                Console.WriteLine(Constants.NotFoundMessage);
                return;
            }

            List<string> lines = new List<string>();

            foreach (var m in meetings)
            {
                lines.Add($"{nameof(m.Id)} {m.Id} {nameof(m.StartTime)} {m.StartTime}");
            }

            System.IO.File.WriteAllText(System.IO.Path.Combine(Constants.ExportPath, exportDate + Constants.ExportFileExtension), String.Join(Environment.NewLine, lines));
        }
    }
}
