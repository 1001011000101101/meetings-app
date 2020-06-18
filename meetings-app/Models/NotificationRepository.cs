using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public class NotificationRepository : IRepository<Notification>
    {
        private List<Notification> notifications = null;
        public NotificationRepository()
        {
            notifications = new List<Notification>();
        }
        public IQueryable<Notification> All()
        {
            return notifications.AsQueryable();
        }
        public Notification ById(int id)
        {
            return notifications.FirstOrDefault(x => x.Id == id);
        }
        public bool Add(Notification notification)
        {
            bool result = false;
            notifications.Add(notification);

            return result;
        }
        public bool Update(Notification notification)
        {
            bool result = false;

            var n = notifications.FirstOrDefault(x => x.Id == notification.Id);
            if (n == null) return result;

            n.IsSeen = notification.IsSeen;
            n.NotifyBeforeInMinutes = notification.NotifyBeforeInMinutes;

            return result;
        }
        public bool Delete(Notification notification)
        {
            var m = notifications.FirstOrDefault(x => x.Id == notification.Id);
            if (m == null) return false;

            return notifications.Remove(notification);
        }

        public bool DeleteById(int id)
        {
            var n = notifications.FirstOrDefault(x => x.Id == id);
            if (n == null) return false;

            return notifications.Remove(n);
        }

        public bool DeleteByMeetingId(int id)
        {
            var n = notifications.FirstOrDefault(x => x.MeetingId == id);
            if (n == null) return false;

            return notifications.Remove(n);
        }
    }
}
