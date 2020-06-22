using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public class EditStartTimeCommand : Command
    {
        public override void Execute(MeetingManager meetingManager, string[] values)
        {
            string id = values.Skip(1).First();
            string startTime = values.Skip(2).First();


            var meeting = meetingManager.Repository.All().FirstOrDefault(x => x.Id == int.Parse(id));

            if (meeting == null)
                return;

            meeting.StartTime = DateTime.Parse(startTime);
            meetingManager.Repository.Update(meeting);
        }
    }
}
