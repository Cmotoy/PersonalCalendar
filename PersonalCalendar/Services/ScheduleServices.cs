using PersonalCalendar.data.Entities;
using PersonalCalendar.Interfaces;
using System;
using System.Threading.Tasks;

namespace PersonalCalendar.Services
{
    public class ScheduleServices : IScheduleServices
    {

        public Task<Schedule[]> GetIncompleteListsAsync()
        {
            var List1 = new Schedule
            {
                Title = "Strive to finish your .Net training",
                DueAt = DateTimeOffset.UtcNow.AddDays(7.0).ToString()
            };

            var List2 = new Schedule
            {
                Title = "Develop Softwares for sale",
                DueAt = DateTimeOffset.UtcNow.AddDays(2.0).ToString()
            };

            return Task.FromResult(new[] { List1, List2 });
        }

    }
}
