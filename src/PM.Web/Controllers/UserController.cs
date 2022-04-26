using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PM.Application.CQ.UserCQ;
using PM.Application.CQ.UserCQ.Login;
using PM.Application.CQ.UserCQ.Register;

namespace PM.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator)
            : base(mediator)
        {
            
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterAsync(RegistrationCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
