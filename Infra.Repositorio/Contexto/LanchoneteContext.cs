using System.Threading;
using System.Threading.Tasks;
using Dominio.Modelos;
using Infra.Repositorio.Contexto.Config;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.Contexto
{
    public class LanchoneteContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }


        public LanchoneteContext(DbContextOptions<LanchoneteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento de tabelas
            modelBuilder
                .AddDefaultProperties()
                .Entity<Cliente>(entity =>
                {
                    entity
                    .ToTable("Cliente")
                    .AddIsDeletedFilter();
                })
                .Entity<Lanche>(entity =>
                {
                    entity
                    .ToTable("Lanche")
                    .AddIsDeletedFilter();
                })
                .Entity<Pedido>(entity =>
                {
                    entity
                    .ToTable("Pedido")
                    .AddIsDeletedFilter();
                })
                .Entity<PedidoItem>(entity =>
                {
                    entity
                    .ToTable("PedidoItem")
                    .HasKey(x => new { x.PedidoId, x.LancheId, x.IngredienteId });
                })
                .Entity<Ingrediente>(entity =>
                {
                    entity
                    .ToTable("Ingrediente")
                    .AddIsDeletedFilter();
                })
                .Entity<Cardapio>(entity =>
                {
                    entity
                    .ToTable("Cardapio")
                    .HasKey(x => new { x.LancheId, x.IngredienteId });
                });

        }

        public override int SaveChanges()
        {
            // Adiciono as propriedades padrão para serem tratadas na hora de salvar.
            DefaultPropertiesConfig.SaveDefaultPropertiesChanges(ChangeTracker);
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            DefaultPropertiesConfig.SaveDefaultPropertiesChanges(ChangeTracker);
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


    }
}
