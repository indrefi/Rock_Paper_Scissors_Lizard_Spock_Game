using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Configurations
{
    public class ScoreboardConfiguration : IEntityTypeConfiguration<Scoreboard>
    {
        public void Configure(EntityTypeBuilder<Scoreboard> builder)
        {
            builder.ToTable(name: "Scoreboard", schema: "Game")
                .HasKey(cc => new { cc.Id });

            builder.Property(e => e.Id)
                   .HasColumnName("Id")
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(e => e.CreatedAt)
                   .HasColumnName("CreatedAt")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.HasOne(p => p.FirstPlayer)
                   .WithMany(sb => sb.ScoreboardFirstPlayers)
                   .HasForeignKey(sb => sb.FirstPlayerID)
                   .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.SecondPlayer)
                  .WithMany(sb => sb.ScoreboardSecondPlayers)
                  .HasForeignKey(sb => sb.SecondPlayerID)
                  .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.FirstPlayerChoise)
                  .WithMany(sb => sb.ScoreboardFirstPlayerChoises)
                  .HasForeignKey(sb => sb.FirstPlayerChoiseID)
                  .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.SecondPlayerChoise)
                  .WithMany(sb => sb.ScoreboardSecondPlayerChoises)
                  .HasForeignKey(sb => sb.SecondPlayerChoiseID)
                  .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.GameResult)
                  .WithMany(sb => sb.Scoreboards)
                  .HasForeignKey(sb => sb.GameResultID)
                  .HasPrincipalKey(gr => gr.Id);
        }
    }
}
