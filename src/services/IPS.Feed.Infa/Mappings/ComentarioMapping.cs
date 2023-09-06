using IPS.Feed.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IPS.Feed.Infra.Mappings
{
    public class ComentarioMapping : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IdUsuario).IsRequired();

            builder.Property(p => p.Mensagem)
                .IsRequired()
                .HasMaxLength(300);
            
            builder.HasOne(p => p.Postagem)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(p => p.IdPostagem)
                .IsRequired();

            builder.ToTable("Comentarios");

        }

    }
}
