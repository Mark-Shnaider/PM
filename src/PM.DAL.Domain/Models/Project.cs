using PM.DAL.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Domain.Models
{
    public class Project: BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CompanyName { get; set; }
        public int Priority { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Ended { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }

    }
}
