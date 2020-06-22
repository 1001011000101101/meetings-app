using meetings_app.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public class ExportCommand: Command
    {
        public override void Execute(MeetingManager meetingManager, string[] values)
        {
            string exportDate = values.Skip(1).First();

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
