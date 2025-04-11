using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suz.Projetos.Domain.Entities;

namespace Suz.Projetos.Persistence.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.CPF)
              .IsRequired()
              .HasMaxLength(11);

            builder.HasMany(e => e.Projetos)
               .WithOne(e => e.Autor)
               .HasForeignKey(e => e.Id)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
