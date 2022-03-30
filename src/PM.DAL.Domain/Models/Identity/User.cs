using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PM.DAL.Domain.Models.Identity
{
    public class User: IdentityUser<Guid>
    {
        public virtual Worker Worker { get; set; }
    }
}
