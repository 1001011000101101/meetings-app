using meetings_app.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public class MeetingRepository: IRepository<Meeting>
    {
        private List<Meeting> meetings = null;
        public MeetingRepository()
        {
            meetings = new List<Meeting>();
        }
        public IQueryable<Meeting> All()
        {
            return meetings.AsQueryable();
        }
        public Meeting ById(int id)
        {
            return meetings.FirstOrDefault(x => x.Id == id);
        }
        public List<Meeting> ByDate(DateTime date)
        {
            return meetings.Where(x => x.StartTime == date).ToList();
        }
        public bool Add(Meeting meeting)
        {
            bool result = false;
            meeting.Id = GetNextId();

            CheckIntersections(meeting);
            CheckPastTime(meeting);

            meetings.Add(meeting);

            return result;
        }
        public bool Update(Meeting meeting)
        {
            bool result = false;

            var m = meetings.FirstOrDefault(x => x.Id == meeting.Id);
            if (m == null) return result;

            CheckIntersections(meeting);
            CheckPastTime(meeting);

            m.DurationMinutes = meeting.DurationMinutes;
            m.StartTime = meeting.StartTime;

            return result;
        }
        public bool Delete(Meeting meeting)
        {
            var m = meetings.FirstOrDefault(x => x.Id == meeting.Id);
            if (m == null) return false;

            return meetings.Remove(meeting);
        }
        public bool Delete(int id)
        {
            var m = meetings.FirstOrDefault(x => x.Id == id);
            if (m == null) return false;

            return meetings.Remove(m);
        }
        private int GetNextId()
        {
            int id = meetings.Any() ? meetings.Max(x => x.Id) + 1 : 0;

            return id;
        }
        private void CheckIntersections(Meeting meeting)
        {
            bool isIntersection = false;

            //{[}
            if (meetings.Any(x => meeting.StartTime > x.StartTime && meeting.StartTime < x.EndTime))
            {
                isIntersection = true;
            }
            //{]}
            if (meetings.Any(x => meeting.EndTime > x.StartTime && meeting.EndTime < x.EndTime))
            {
                isIntersection = true;
            }
            //[{]
            if (meetings.Any(x => x.StartTime > meeting.StartTime &&  x.StartTime < meeting.EndTime))
            {
                isIntersection = true;
            }
            //[}]
            if (meetings.Any(x => x.EndTime > meeting.StartTime && x.EndTime < meeting.EndTime))
            {
                isIntersection = true;
            }


            if (isIntersection)
            {
                throw new Exception(Constants.IntersectionExceptionMessage);
            }
        }
        private void CheckPastTime(Meeting meeting)
        {
            if (meeting.StartTime < DateTime.Now)
            {
                throw new Exception(Constants.IntersectionExceptionMessage);
            }
        }
    }
}
