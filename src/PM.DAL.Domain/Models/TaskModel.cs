using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.DAL.Domain.Models.Base;
using PM.DAL.Domain.Enums;
using TaskStatus = PM.DAL.Domain.Enums.TaskStatus;

namespace PM.DAL.Domain.Models
{
    public class TaskModel : BaseEntity
    {
        public string? Name { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public string? Commentary { get; set; }

    }
}
