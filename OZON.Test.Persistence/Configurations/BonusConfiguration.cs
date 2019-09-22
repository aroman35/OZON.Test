using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZON.Test.Application.Infrastructure.Models;

namespace OZON.Test.Persistence.Configurations
{
    public class BonusConfiguration : IEntityTypeConfiguration<IBonusPm>
    {
        public void Configure(EntityTypeBuilder<IBonusPm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Employee)
                .WithMany(b => b.Bonuses)
                .HasForeignKey(x => x.Id);

            builder.Property(x => x.EmployeeId)
                .HasColumnName("WORKER_ID");

            builder.Property(x => x.BonusDate)
                .HasColumnType("timestamp")
                .HasColumnName("BONUS_DATE");

            builder.Property(x => x.BonusAmount)
                .HasColumnType("money")
                .HasColumnName("BONUS_AMOUNT");
        }
    }
}