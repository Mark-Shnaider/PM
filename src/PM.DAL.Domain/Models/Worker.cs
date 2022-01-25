using PM.DAL.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Domain.Models
{
    public class Worker: BaseEntity
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
    }
}
