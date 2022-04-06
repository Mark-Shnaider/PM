using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PM.Application.Services.WorkerService.Queries;
using PM.DAL.Domain.Models;

namespace PM.Web.Controllers
{
    [Authorize]
    public class WorkerController : BaseController
    {
        public WorkerController(IMediator mediator) 
            : base(mediator)
        {

        }


        [HttpGet("index")]
        public async Task<ActionResult<List<Worker>>> Index(GetAllWorkersQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> Details(GetWorkerByIdQuery query)
        {
            return await _mediator.Send(query);
        }

    }
}
