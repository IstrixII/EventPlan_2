using System.ComponentModel.DataAnnotations;

namespace Teste1.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório!", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Categoria é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        public string Categoria { get; set; }


        public string Foto { get; set; }
        [Required(ErrorMessage = "Campo Data é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Data do Evento")]
        public DateTime Data_evento { get; set; }
    }
}
