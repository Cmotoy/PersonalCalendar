using Microsoft.AspNetCore.Mvc;
using PersonalCalendar.Interfaces;
using PersonalCalendar.Models;
using PersonalCalendar.Services;
using System.Threading.Tasks;

namespace PersonalCalendar.Controllers
{
    public class ScheduleController : Controller
    {

        private readonly IScheduleServices _ScheduleServices;
        public ScheduleController(IScheduleServices ScheduleService)
        {
            _ScheduleServices = ScheduleService;
        }

        [HttpGet]
        public IActionResult Calendar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calendar(CalendarViewModel model)
        {
            var Lists = await _ScheduleServices.GetIncompleteListsAsync();

            var models = new CalenderViewModel()
            {
                Lists = Lists
            };

            return View(models);

        }
    }
}
