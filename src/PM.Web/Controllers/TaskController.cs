using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PM.Web.Controllers
{
    [Authorize]
    public class TaskController: BaseController
    {
        public TaskController(IMediator mediator)
            : base(mediator)
        {
                
        }
    }
}
