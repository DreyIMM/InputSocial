using IPS.Feed.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPS.Feed.API.Mappings
{
    public class PostagemMapping : IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IdUsuario).IsRequired();

            builder.Property(p => p.Mensagem)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasMany(p => p.Comentarios)
                .WithOne(p => p.Postagem)
                .HasForeignKey(p => p.IdPostagem)
                .IsRequired();

            builder.HasMany(p => p.Curtidas)
                .WithOne(p => p.Postagem)
                .HasForeignKey(p => p.IdPostagem)
                .IsRequired();

            builder.ToTable("Postagens");
        }

    }
}

