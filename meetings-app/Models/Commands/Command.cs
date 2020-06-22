using System;
using System.Collections.Generic;
using System.Text;

namespace meetings_app.Models
{
    public class Command
    {
        public virtual void Execute(MeetingManager meetingManager, string[] values)
        {
        }
    }
}
