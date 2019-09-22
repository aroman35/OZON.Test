using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZON.Test.Application.Infrastructure.Models;

namespace OZON.Test.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<IDepartmentPm>
    {
        public void Configure(EntityTypeBuilder<IDepartmentPm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DepartmentName)
                .HasMaxLength(32)
                .HasColumnType("text")
                .HasColumnName("NAME");
        }
    }
}