using IPS.Feed.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IPS.Feed.Infra.Mappings
{
    public class RelacaoSeguindoMapping : IEntityTypeConfiguration<RelacaoSeguindo>
    {
        public void Configure(EntityTypeBuilder<RelacaoSeguindo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IdUsuario).IsRequired();

            builder.Property(p => p.IdSeguidores).IsRequired();

            builder.HasIndex(p => new { p.IdUsuario, p.IdSeguidores }).IsUnique();

            builder.ToTable("Seguidores");
        }

    }
}
