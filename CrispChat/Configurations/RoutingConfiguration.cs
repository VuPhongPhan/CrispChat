using CrispChat.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrispChat.Configurations
{
    public class RoutingConfiguration : IEntityTypeConfiguration<Routing>
    {
        public void Configure(EntityTypeBuilder<Routing> builder)
        {
            builder.ToTable("Routings");
            builder.HasKey(x => x.Id);
        }
    }
}
