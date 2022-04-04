using MediatR;


namespace PM.Application.Services.UserService.Login
{
    public class LoginQuery: IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
