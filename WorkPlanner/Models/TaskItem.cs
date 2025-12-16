using System;

namespace WorkPlanner.Models
{
    /// <summary>
    /// Task model representing a single planned work item.
    /// </summary>
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Today;
        public TimeSpan StartTime { get; set; } = TimeSpan.Zero;
        public TimeSpan EndTime { get; set; } = TimeSpan.Zero;
        public PriorityEnum Priority { get; set; } = PriorityEnum.Medium;
        public StatusEnum Status { get; set; } = StatusEnum.Planned;
    }
}