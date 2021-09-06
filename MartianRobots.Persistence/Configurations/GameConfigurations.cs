using MartianRobots.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MartianRobots.Persistence.Configurations
{
    public class GameConfigurations : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("games");
            builder.Property(x => x.Id).HasColumnName("id").HasDefaultValueSql("NEWID()");

            builder.Property(e => e.CreatedDateTime)
                .HasColumnName("played_at")
                .HasColumnType("datetimeoffset");

            builder.Property(e => e.WonRobots)
                .HasColumnName("winning_robots_count");

            builder.Property(e => e.LostRobots)
                .HasColumnName("lost_robots_count");

            builder.Property(e => e.ExploredSurfaceRate)
                .HasColumnName("explored_surface_rate");
        }
    }
}
