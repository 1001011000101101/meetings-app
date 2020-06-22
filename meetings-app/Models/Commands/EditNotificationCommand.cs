using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public class EditNotificationCommand: Command
    {
        public override void Execute(MeetingManager meetingManager, string[] values)
        {
            string meetingId = values.Skip(1).First();
            string notifyBeforeInMinutes = values.Skip(2).First();

            var meeting = meetingManager.Repository.All().FirstOrDefault(x => x.Id == int.Parse(meetingId));

            if (meeting == null)
                return;

            var notification = meetingManager.Reminder.Repository.All().FirstOrDefault(x => x.MeetingId == int.Parse(meetingId));

            if (notification == null)
                return;

            notification.NotifyBeforeInMinutes = int.Parse(notifyBeforeInMinutes);
            meetingManager.Reminder.Repository.Update(notification);
        }
    }
}
