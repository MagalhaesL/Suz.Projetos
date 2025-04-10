using System.Reflection;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Suz.Projetos.Domain.Entities;

namespace Suz.Projetos.Persistence
{
    public class ProjetosContext : DbContext
    {
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public ProjetosContext(DbContextOptions<ProjetosContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            builder.Entity<Categoria>()
                .HasMany(c => c.Subcategorias)
                .WithOne(s => s.Categoria)
                .HasForeignKey(s => s.CategoriaId);

            builder.Entity<Projeto>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId);

            builder.Entity<Projeto>()
                .HasOne(p => p.Subcategoria)
                .WithMany()
                .HasForeignKey(p => p.SubcategoriaId);
        }
    }
}
