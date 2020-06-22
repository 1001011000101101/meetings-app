using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public class DeleteCommand : Command
    {
        public override void Execute(MeetingManager meetingManager, string[] values)
        {
            string id = values.Skip(1).First();

            meetingManager.Repository.Delete(int.Parse(id));
            meetingManager.Reminder.Repository.DeleteByMeetingId(int.Parse(id));
        }
    }
}
