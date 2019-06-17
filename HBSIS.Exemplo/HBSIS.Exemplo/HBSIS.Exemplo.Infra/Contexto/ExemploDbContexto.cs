using HBSIS.Exemplo.Dominio.Entidades;
using HBSIS.Exemplo.Infra.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace HBSIS.Exemplo.Infra.Contexto
{
    public class ExemploDbContexto  : DbContext
    {
        public ExemploDbContexto(DbContextOptions<ExemploDbContexto> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
