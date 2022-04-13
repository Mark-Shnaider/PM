using MediatR;
using PM.Application.Exceptions;
using PM.DAL.Domain;
using PM.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.CQ.WorkerCQ.Commands
{
    public class WorkerCommandHandlers :
        IRequestHandler<CreateWorkerCommand, Guid>,
        IRequestHandler<UpdateWorkerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkerCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            request.Worker.Id = Guid.NewGuid();

            var worker = new Worker
            {
                Id = Guid.NewGuid(),
                Email = request.Worker.Email,
                Name = request.Worker.Name,
                SurName = request.Worker.SurName,
                Patronymic = request.Worker.Patronymic,
                WorkerType = request.Worker.WorkerType,
                ProjectId = request.Worker.ProjectId,
                UserId = request.Worker.UserId,
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now,
            };

            var workerRepository = _unitOfWork.GetRepository<Worker>();
            
            workerRepository.Add(worker);
            await _unitOfWork.CommitAsync();

            return worker.Id;
        }

        public async Task<Guid> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            var workerRepository = _unitOfWork.GetRepository<Worker>();

            var worker = workerRepository.GetById(request.Worker.Id);
            if (worker == null)
            {
                throw new RestException(HttpStatusCode.NotFound);
            }

            worker.Email = request.Worker.Email;
            worker.Name = request.Worker.Name;
            worker.SurName = request.Worker.SurName;
            worker.Patronymic = request.Worker.Patronymic;
            worker.WorkerType = request.Worker.WorkerType;
            worker.ProjectId = request.Worker.ProjectId;
            worker.UserId = request.Worker.UserId;
            worker.LastModifiedAt = DateTime.Now;

            workerRepository.Update(worker);
            await _unitOfWork.CommitAsync();

            return request.Worker.Id;
        }
    }
}
