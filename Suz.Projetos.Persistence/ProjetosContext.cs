using System.Reflection;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Suz.Projetos.Domain.Entities;

namespace Suz.Projetos.Persistence
{
    public class ProjetosContext : DbContext
    {
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        public ProjetosContext(DbContextOptions<ProjetosContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuração do relacionamento entre Pessoa e Projeto
            builder.Entity<Pessoa>()
                .HasMany(p => p.Projetos)
                .WithOne(p => p.Autor)
                .HasForeignKey(p => p.AutorId);
        }
    }
}
