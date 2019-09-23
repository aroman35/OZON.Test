using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZON.Test.Application.Models;

namespace OZON.Test.Persistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<DreamTeamPm>
    {
        public void Configure(EntityTypeBuilder<DreamTeamPm> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}