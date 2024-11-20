using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace fazenda2.Models
{
    public class Fornecedor
    {
        [Key]
        public int FornecedorId { get; set; }


        [DisplayName("CNPJ")]
        [MaxLength(100)]
        public string? Cnpj { get; set; }

        [DisplayName("Nome")]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [DisplayName("Contato")]
        [MaxLength(100)]
        public string? Contato { get; set; }

        [DisplayName("Endereço")]
        [MaxLength(100)]
        public string? Endereco { get; set; }

        [DisplayName("Tipo de produtos Oferecidos")]
        [MaxLength(100)]
        public string? Tipo_produto { get; set; }
    }
}
