using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public class MeetingManager
    {
        public MeetingRepository Repository = null;
        public Reminder Reminder = null;

        public MeetingManager()
        {
            Repository = new MeetingRepository();
            Reminder = new Reminder(Repository);
        }
    }
}
