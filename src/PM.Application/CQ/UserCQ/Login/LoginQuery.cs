using MediatR;


namespace PM.Application.CQ.UserCQ.Login
{
    public class LoginQuery: IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
