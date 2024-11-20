using System.ComponentModel.DataAnnotations;

namespace fazenda2.Models
{
    public class ProdutoVenda
    {
        [Key]
        public int ProdutoVendaId { get; set; } // Chave primária

        public int ProdutoId { get; set; } // Chave estrangeira para Produto
        public int VendaId { get; set; } // Chave estrangeira para Venda

        public int Quantidade { get; set; } // Quantidade do produto na venda

        // Navegação para Produto
        public virtual Produto? Produto { get; set; }

        // Navegação para Venda
        public virtual Venda? Venda { get; set; }
    }
}
