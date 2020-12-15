using System;

namespace PersonalCalendar.data.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}