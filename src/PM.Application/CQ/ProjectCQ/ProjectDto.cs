using PM.Application.CQ.WorkerCQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.CQ.ProjectCQ
{
    public record ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public int Priority { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Ended { get; set; }

        public List<WorkerDto> Workers { get; set; }
    }
}
