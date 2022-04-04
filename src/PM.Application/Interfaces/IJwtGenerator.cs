using PM.DAL.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}
