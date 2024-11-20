using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GestaoFacil.DTOs
{
    public class ServidorDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(5, ErrorMessage = "Obrigatório mínimo de 5 caracteres")]
        public string? nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(14, ErrorMessage = "Campo deve possuir 14 caracteres")]
        public string? cpf { get; set; }

        [Required]
        public int SIAPE { get; set; }
    }
}