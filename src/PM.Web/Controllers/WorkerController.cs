using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PM.Application.CQ.WorkerCQ.Commands;
using PM.Application.CQ.WorkerCQ.Queries;
using PM.DAL.Domain.Models;

namespace PM.Web.Controllers
{
    //[Authorize]
    public class WorkerController : BaseController
    {
        public WorkerController(IMediator mediator) 
            : base(mediator)
        {

        }

        [HttpGet("check")]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Check()
        {
            return 5;
        }

        [HttpGet("index")]
        public async Task<ActionResult<List<Worker>>> Index(GetAllWorkersQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("details")]
        public async Task<ActionResult<Worker>> Details(GetWorkerByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateWorker(CreateWorkerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("update")]
        public async Task<ActionResult<Guid>> UpdateWorker(UpdateWorkerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("delete")]
        public async Task<ActionResult<Unit>> DeleteWorker(DeleteWorkerCommand command)
        {
            return await _mediator.Send(command);
        }


    }
}
