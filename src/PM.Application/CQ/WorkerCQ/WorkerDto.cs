using MediatR;
using PM.Application.CQ.ProjectCQ;
using PM.Application.CQ.TaskCQ;
using PM.DAL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.CQ.WorkerCQ
{
    public record WorkerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public WorkerType WorkerType { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }

        //public List<TaskDto> Tasks { get; set; }
        ////public User User { get; set; }
        //public ProjectDto Project { get; set; }
    }
}
