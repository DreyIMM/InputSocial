using IPS.Feed.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IPS.Feed.Infra.Mappings
{
    public class CurtidaMapping : IEntityTypeConfiguration<Curtida>
    {
        public void Configure(EntityTypeBuilder<Curtida> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IdUsuario).IsRequired();


            builder.HasOne(p => p.Postagem)
                .WithMany(p => p.Curtidas)
                .HasForeignKey(p => p.IdPostagem)
                .IsRequired();

            builder.ToTable("Curtidas");
        }
    }
}