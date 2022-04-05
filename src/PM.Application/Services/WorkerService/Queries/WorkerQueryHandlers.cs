using MediatR;
using PM.DAL.Domain;
using PM.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.Services.WorkerService.Queries
{
    public class WorkerQueryHandlers : IRequestHandler<GetWorkerByIdQuery, Worker>
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkerQueryHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Worker> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Worker>();

            var worker = repository.GetAll().FirstOrDefault(x => x.Id == request.Id);

            if (worker == null)
            {
                throw new Exception();
            }

            return worker;
        }
    }
}
