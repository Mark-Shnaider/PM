using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.DAL.Domain.Models.Identity;
using PM.Application.Services.UserService;
using System.Net;
using PM.Application.Exceptions;
using PM.Application.Interfaces;

namespace PM.Application.Services.UserService.Login
{
    public class LoginHandler : IRequestHandler<LoginQuery, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginHandler(UserManager<User> userManager, SignInManager<User> signInManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<UserDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new RestException(HttpStatusCode.Unauthorized);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    DisplayName = user.UserName,
                    Token = _jwtGenerator.GenerateToken(user),
                    UserName = user.UserName,
                    Image = null
                };
            }

            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}
