using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class GameResultConfiguration : IEntityTypeConfiguration<GameResult>
    {
        public void Configure(EntityTypeBuilder<GameResult> builder)
        {
            builder.ToTable(name: "GameResult", schema: "Game")
                .HasKey(cc => new { cc.Id });

            builder.Property(e => e.Id)
                   .HasColumnName("Id")
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(e => e.Name)
                   .HasColumnName("Name")
                   .HasColumnType("nvarchar")
                   .HasMaxLength(12)
                   .IsRequired();
        }
    }
}
