using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PM.Application.Services.UserService;
using PM.Application.Services.UserService.Login;

namespace PM.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator)
        {
            
        }

        [HttpGet("index")]
        public async Task<ActionResult<int>> Index()
        {
            return 5; ;
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginQuery query)
        {
            return await Mediator.Send(query);
        }


    }
}
