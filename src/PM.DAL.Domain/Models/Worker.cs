using PM.DAL.Domain.Models.Base;
using PM.DAL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.DAL.Domain.Models.Identity;

namespace PM.DAL.Domain.Models
{
    public class Worker: BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public WorkerType WorkerType { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }

        public virtual ICollection<TaskModel> Tasks { get; set; }
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}
