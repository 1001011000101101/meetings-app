using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using meetings_app.Code;

namespace meetings_app.Models
{
    public class Reminder
    {
        public NotificationRepository Repository = null;
        public MeetingRepository meetingRepository = null;

        public Reminder(MeetingRepository meetingRepository)
        {
            Repository = new NotificationRepository();
            this.meetingRepository = meetingRepository;

            timer = new Timer(Constants.NotificationInterval);

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public delegate void ReminderHandler(string message);

        public event ReminderHandler Notify;

        private static Timer timer;

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var notifications = Repository.All().Where(x => meetingRepository.All()
            .Any(y => y.Id == x.MeetingId && x.IsSeen == false && DateTime.Now > y.StartTime.AddMinutes(-x.NotifyBeforeInMinutes)));

            foreach (var n in notifications)
            {
                var m = meetingRepository.All().FirstOrDefault(x => x.Id == n.MeetingId);

                Notify?.Invoke($"Назначена встреча: {m.StartTime} продолжительностью {m.DurationMinutes} [MeetingId = {n.MeetingId}]");

                n.IsSeen = true;
                Repository.Update(n);
            }
        }
    }
}
