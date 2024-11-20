using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace fazenda2.Models
{
    public class Venda
    {
        [Key]
        [DisplayName("Código")]
        public int VendaId { get; set; } // Chave primária da Venda

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "Escolha um Cliente já cadastrado.")]
        public int ClienteId { get; set; } // FK referenciando Cliente

        [Display(Name = "Data da Venda")]
        [DataType(DataType.Date)]
        public DateTime DataVenda { get; set; } // Data da venda

        [DisplayName("Valor Total")]
        public decimal Total { get; set; } // Valor total da venda

        // Navegação para Cliente
        public virtual Cliente? Cliente { get; set; }

        // Relacionamento muitos-para-muitos com Produto por meio de ProdutoVenda
        public virtual ICollection<ProdutoVenda> ProdutosVenda { get; set; } = new List<ProdutoVenda>();
    }
}
