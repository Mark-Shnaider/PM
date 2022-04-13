using MediatR;
using PM.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.CQ.WorkerCQ.Queries
{
    public class GetAllWorkersQuery : IRequest<List<Worker>>
    {
        public int Skip{ get; set; }
        public int Take{ get; set; }
    }
}
