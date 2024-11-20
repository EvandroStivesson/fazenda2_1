using fazenda2.Models;
using Microsoft.EntityFrameworkCore;

namespace fazenda2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<ProdutoVenda> ProdutosVendas { get; set; } // Tabela associativa ProdutoVenda

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento Cliente -> Venda
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Vendas) // Cliente tem muitas Vendas
                .WithOne(v => v.Cliente) // Cada Venda pertence a um Cliente
                .HasForeignKey(v => v.ClienteId) // Chave estrangeira em Venda
                .OnDelete(DeleteBehavior.Cascade);  
            
            // Configuração do relacionamento muitos-para-muitos Produto <-> Venda por meio de ProdutoVenda
            modelBuilder.Entity<ProdutoVenda>()
                .HasOne(pv => pv.Produto) // Cada ProdutoVenda tem um Produto
                .WithMany(p => p.ProdutosVenda) // Cada Produto pode estar em várias ProdutoVenda
                .HasForeignKey(pv => pv.ProdutoId) // Chave estrangeira ProdutoId em ProdutoVenda
                .OnDelete(DeleteBehavior.Cascade); //TODO

            modelBuilder.Entity<ProdutoVenda>()
                .HasOne(pv => pv.Venda)            // Cada ProdutoVenda tem uma Venda
                .WithMany(v => v.ProdutosVenda)     // Cada Venda pode ter vários ProdutoVenda
                .HasForeignKey(pv => pv.VendaId)   // Chave estrangeira VendaId em ProdutoVenda
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
