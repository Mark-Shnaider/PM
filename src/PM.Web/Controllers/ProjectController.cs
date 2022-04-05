using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PM.Web.Controllers
{
    public class ProjectController : BaseController
    {
        public ProjectController(IMediator mediator)
            :base(mediator)
        {

        }

        [HttpGet("test")]
        [Authorize]
        public string Test()
        {
            return "Check";
        }
        public async Task<IActionResult> Index()
        {
             throw new NotImplementedException();

        }
    }
}
