using meetings_app.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public class PrintCommand: Command
    {
        public override void Execute(MeetingManager meetingManager, string[] values)
        {
            string printDate = values.Skip(1).First();

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
    }
}
