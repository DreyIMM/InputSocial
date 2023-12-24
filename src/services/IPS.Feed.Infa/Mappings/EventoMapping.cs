using IPS.Feed.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace IPS.Feed.Infa.Mappings
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IdUsuario).IsRequired();
            
            builder.Property(e => e.TituloEvento).IsRequired().HasColumnType("varchar(150)");

            builder.Property(e => e.DescricaoEvento).IsRequired().HasColumnType("varchar(300)");

            builder.Property(e => e.StatusEvento).HasConversion<string>();

            builder.OwnsOne(e => e.Endereco, e =>
            {
                e.Property(end => end.Bairro);
                e.Property(end => end.Cidade);
                e.Property(end => end.Numero);
                e.Property(end => end.Cep);
                e.Property(end => end.Latitude);
                e.Property(end => end.Longitude);
            });


            builder.ToTable("Eventos");
        }

    }
}
