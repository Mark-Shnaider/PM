using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Configurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.SurName).IsRequired();
            builder.Property(x => x.Patronymic).IsRequired(false);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.WorkerType).IsRequired();
            builder.HasOne(x => x.User).WithOne(x => x.Worker).HasForeignKey<Worker>(x => x.UserId);
            builder.HasOne(x => x.Project).WithMany().HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
