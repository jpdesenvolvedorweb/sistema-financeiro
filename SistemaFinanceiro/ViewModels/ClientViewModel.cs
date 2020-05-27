using System.ComponentModel.DataAnnotations;

namespace SistemaFinanceiro.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        private long idClient { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome!!!")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres!!!")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres!!!")]
        private string name { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cpf!!!")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres!!!")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres!!!")]
        private string cpf { get; set; }

        [Required(ErrorMessage = "Preencha o campo Endereço!!!")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres!!!")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres!!!")]
        private string address { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone!!!")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres!!!")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres!!!")]
        private string telephone { get; set; }

        private int state { get; set; }
    }
}