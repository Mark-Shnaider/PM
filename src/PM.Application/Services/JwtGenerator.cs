﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PM.Application.Interfaces;
using PM.DAL.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.Services
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly SymmetricSecurityKey _key;

        public JwtGenerator(IConfiguration config)
        {
           //_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super secret key"));
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.NameId, user.UserName) };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
