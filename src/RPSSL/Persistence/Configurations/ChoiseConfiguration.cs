using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class ChoiseConfiguration : IEntityTypeConfiguration<Choise>
    {
        public void Configure(EntityTypeBuilder<Choise> builder)
        {
            builder.ToTable(name: "Choise", schema: "Game")
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
