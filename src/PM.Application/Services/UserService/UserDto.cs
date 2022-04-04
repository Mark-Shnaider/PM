using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Application.Services.UserService
{
    public class UserDto
    {
        public string DisplayName { get; set; }

        public string Token { get; set; }

        public string UserName { get; set; }

        public string Image { get; set; }
    }
}
