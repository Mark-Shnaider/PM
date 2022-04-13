using PM.Application.CQ.WorkerCQ;
using PM.DAL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = PM.DAL.Domain.Enums.TaskStatus;

namespace PM.Application.CQ.TaskCQ
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public string Commentary { get; set; }
        public Guid WorkerId { get; set; }

        public WorkerDto Worker { get; set; }
    }
}
