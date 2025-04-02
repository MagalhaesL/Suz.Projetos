﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suz.Projetos.Domain.Entities;

namespace Suz.Projetos.Persistence.Configurations
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(2048);

            builder.HasOne(e => e.Autor)
                .WithMany(e => e.Projetos)
                .HasForeignKey(e => e.AutorId);
        }
    }
}
