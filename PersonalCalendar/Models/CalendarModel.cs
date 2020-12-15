using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalCalendar.Models
{
    public class CalendarViewModel
    {
        public Guid Id { get; set; }
        public bool Completed { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTimeOffset? DueAt { get; set; }

    }
}
