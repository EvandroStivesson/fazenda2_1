using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace fazenda2.Models
{
    public class Produto
    {
        [Key]
        [DisplayName("Código")]
        public int ProdutoId { get; set; }

        [DisplayName("Nome")]
        [MaxLength(100)]
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [DisplayName("Preço")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [DisplayName("Quantidade")]
        public float? Quantidade { get; set; }

        // Relacionamento muitos-para-muitos com Venda por meio de ProdutoVenda
        public virtual ICollection<ProdutoVenda> ProdutosVenda { get; set; } = new List<ProdutoVenda>();
    }
}
