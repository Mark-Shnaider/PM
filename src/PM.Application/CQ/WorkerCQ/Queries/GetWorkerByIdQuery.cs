using MediatR;
using PM.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.CQ.WorkerCQ.Queries
{
    public class GetWorkerByIdQuery : IRequest<Worker>
    {
        public Guid Id { get; set; }
    }
}
