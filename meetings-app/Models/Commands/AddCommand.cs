using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    class AddCommand : Command
    {
        public override void Execute(MeetingManager meetingManager, string[] values)
        {
            var startTime = $"{values.Skip(1).First()} {values.Skip(2).First()}";
            var duration = values.Skip(3).First();
            var notifyBefore = values.Skip(4).FirstOrDefault();

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
    }
}
