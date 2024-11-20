
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFacil.Models
{   
    [Table("servidor")]
    public class Servidor {
        [Column("id_servidor")]
        public int Id {get; set;}

        [Column("nomeServidor")]
        public string? Nome {get; set;}

        [Column("cpf")]
        public string? Cpf {get; set;}

        [Column("siapeServidor")]
        public int SIAPE {get; set;}
    }
}