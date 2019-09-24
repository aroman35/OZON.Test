using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZON.Test.Application.Models;

namespace OZON.Test.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeDto>
    {
        public void Configure(EntityTypeBuilder<EmployeeDto> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .HasColumnName("ID");
            
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

            builder.Property(x => x.Department)
                .HasConversion<int>()
                .HasColumnName("DEPARTMENT");

            builder.Property(x => x.JoiningDate)
                .HasColumnType("timestamp")
                .HasColumnName("JOINING_DATE");

            builder.HasOne(x => x.ReportTo)
                .WithMany(e => e.ReportedEmployees)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(x => x.ReportToId);

            builder.Property(x => x.ReportToId)
                .HasColumnName("LEAD_ID");
        }
    }
}