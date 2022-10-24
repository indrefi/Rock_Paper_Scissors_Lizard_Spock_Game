using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable(name: "Player", schema: "Game")
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
