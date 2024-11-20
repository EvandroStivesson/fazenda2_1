using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace fazenda2.Models
{
    public class Funcionario
    {
        [Key]
        [DisplayName("Código")]

        public int id_funcionario {  get; set; }

        [Required]
        [DisplayName("Nome")]
        [MaxLength(100)]
        public string? nome { get; set; }

        [DisplayName("CPF")]
        [MaxLength(100)]
        public string? cpf { get; set; }

        [DisplayName("Email")]
        [MaxLength(100)]
        public string? email { get; set; }

        [DisplayName("Senha")]
        [MaxLength(40)]
        public string? senha { get; set; }

        [DisplayName("Salário")]
        public float salario { get; set; }


    }
}
