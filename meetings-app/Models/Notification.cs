using System;
using System.Collections.Generic;
using System.Text;

namespace meetings_app.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public int NotifyBeforeInMinutes { get; set; }
        public bool IsSeen { get; set; }
    }
}
