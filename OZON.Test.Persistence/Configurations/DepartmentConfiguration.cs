using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZON.Test.Application.Models;

namespace OZON.Test.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<DepartmentPm>
    {
        public void Configure(EntityTypeBuilder<DepartmentPm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DepartmentName)
                .HasMaxLength(32)
                .HasColumnType("text")
                .HasColumnName("NAME");
        }
    }
}