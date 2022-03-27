using PM.DAL.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x =>x.Description).IsRequired();
            builder.Property(x =>x.CompanyName).IsRequired(false);
            builder.Property(x =>x.Priority).IsRequired();
            builder.Property(x =>x.Started).IsRequired();
            builder.Property(x =>x.Ended).IsRequired(false);
        }
    }
}
