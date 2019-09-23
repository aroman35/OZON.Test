using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Application.Models;

namespace OZON.Test.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeePm>
    {
        public void Configure(EntityTypeBuilder<EmployeePm> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.FirstName)
                .HasColumnName("FIRST_NAME")
                .HasColumnType("text")
                .HasMaxLength(32);
            
            builder.Property(x => x.LastName)
                .HasColumnName("LAST_NAME")
                .HasColumnType("text")
                .HasMaxLength(32);
            
            builder.Property(x => x.Salary)
                .HasColumnType("money")
                .HasColumnName("SALARY");

            builder.HasOne(x => x.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(x => x.DepartmentId);

            builder.Property(x => x.DepartmentId)
                .HasColumnName("DEPARTMENT_ID");
                
            builder.Property(x => x.JoiningDate)
                .HasColumnType("timestamp")
                .HasColumnName("JOINING_DATE");

            builder.HasOne(x => x.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(x => x.TeamId);
        }
    }
}