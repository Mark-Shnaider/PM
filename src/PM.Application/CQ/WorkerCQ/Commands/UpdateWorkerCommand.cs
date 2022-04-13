using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.CQ.WorkerCQ.Commands
{
    public class UpdateWorkerCommand : IRequest<Guid>
    {
        public WorkerDto Worker { get; set; }
    }
}
