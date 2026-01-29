using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTaskManager.Models
{
    public class TaskItem
    {
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public DateTime Deadline { get; set; } = DateTime.Today.AddDays(7);
        public bool IsOverdue => !IsCompleted && Deadline.Date < DateTime.Today;
    }
}
