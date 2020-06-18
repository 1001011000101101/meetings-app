using System;
using System.Collections.Generic;
using System.Text;

namespace meetings_app.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; }

        public DateTime EndTime { 
            get 
            {
                return StartTime.AddMinutes(DurationMinutes); 
            } 
        }
    }
}
