using MartianRobots.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MartianRobots.Persistence.Configurations
{
    class GameResultConfigurations : IEntityTypeConfiguration<GameResult>
    {
        public void Configure(EntityTypeBuilder<GameResult> builder)
        {
            builder.ToTable("game_results");
            builder.Property(x => x.Id).HasColumnName("id").HasDefaultValueSql("NEWID()");

            builder.Property(e => e.Instructions)
                .HasColumnName("instructions")
                .HasMaxLength(100)
                .IsFixedLength(false)
                .IsUnicode(false);

            builder.Property(e => e.GameId)
                .HasColumnName("game_id");

            builder.Property(e => e.HasFallen)
                .HasColumnName("lost");

            builder.Property(e => e.InitialOrientation)
                .HasColumnName("init_orientation");

            builder.Property(e => e.EndOrientation)
                .HasColumnName("end_orientation");

            builder.Property(e => e.InitialCoordinate)
                .HasColumnName("initial_coordinate")
                .UseStringConvension();

            builder.Property(e => e.EndCoordinate)
                .HasColumnName("end_coordinate")
                .UseStringConvension();

            builder.HasOne(p => p.Game)
                .WithMany(g => g.GameResults)
                .HasForeignKey(g => g.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.CreatedDateTime)
                .HasColumnName("calculated_at")
                .HasColumnType("datetimeoffset");
        }
    }
}
