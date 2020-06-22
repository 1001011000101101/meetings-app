using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public class EditDurationCommand: Command
    {
        public override void Execute(MeetingManager meetingManager, string[] values)
        {
            string id = values.Skip(1).First();
            string duration = values.Skip(2).First();


            var meeting = meetingManager.Repository.All().FirstOrDefault(x => x.Id == int.Parse(id));

            if (meeting == null)
                return;

            meeting.DurationMinutes = int.Parse(duration);
            meetingManager.Repository.Update(meeting);
        }
    }
}
