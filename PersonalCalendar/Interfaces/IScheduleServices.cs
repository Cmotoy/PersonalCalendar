using PersonalCalendar.data.Entities;
using System.Threading.Tasks;

namespace PersonalCalendar.Interfaces
{
    public interface IScheduleServices
    {
        Task<Schedule[]> GetIncompleteListsAsync();
    }
}
