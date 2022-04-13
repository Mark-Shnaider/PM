using MediatR;
using Microsoft.AspNetCore.Identity;
using PM.Application.Exceptions;
using PM.Application.Interfaces;
using PM.DAL.Domain;
using PM.DAL.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.CQ.UserCQ.Register
{
    public class RegistrationHandler : IRequestHandler<RegistrationCommand, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtGenerator _jwtGenerator;

        public RegistrationHandler(UserManager<User> userManager, IUnitOfWork unitOfWork, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
			_unitOfWork = unitOfWork;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<UserDto> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
			var users = _unitOfWork.GetRepository<User>();
			if (users.GetAll().Where(x => x.Email == request.Email).Any())
			{
				throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exist" });
			}

			if (users.GetAll().Where(x => x.UserName == request.UserName).Any())
			{
				throw new RestException(HttpStatusCode.BadRequest, new { UserName = "UserName already exist" });
			}

			var user = new User
			{
				//DisplayName = request.DisplayName,
				Email = request.Email,
				UserName = request.UserName
			};

			var result = await _userManager.CreateAsync(user, request.Password);

			if (result.Succeeded)
			{
				return new UserDto
				{
                    //DisplayName = user.DisplayName,
                    Token = _jwtGenerator.GenerateToken(user),
					UserName = user.UserName,
					Image = null
				};
			}

			throw new Exception("Client creation failed");
		}
    }
}
