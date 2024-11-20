using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace fazenda2.Models
{
    public class Cliente
    {
        [Key]
        [DisplayName("Código")]
        public int ClienteId { get; set; } // Chave primária do Cliente

        [DisplayName("Nome")]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [DisplayName("Email")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [DisplayName("Senha")]
        [MaxLength(40)]
        public string? Senha { get; set; }

        // Navegação para Vendas
        public virtual ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    }
}
