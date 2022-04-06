using MediatR;
using Microsoft.EntityFrameworkCore;
using PM.Application.Exceptions;
using PM.DAL.Domain;
using PM.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.Services.WorkerService.Queries
{
    
    public class WorkerQueryHandlers : 
        IRequestHandler<GetWorkerByIdQuery, Worker>,
        IRequestHandler<GetAllWorkersQuery, List<Worker>>
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
                throw new RestException(HttpStatusCode.NotFound);
            }

            return worker;
        }

        public async Task<List<Worker>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Worker>();

            var workers = repository.GetAll().OrderBy(x => x.Name)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToList();

            return workers;
        }
    }
}
