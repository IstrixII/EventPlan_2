using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste1.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório!", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Categoria é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Campo Preço é obrigatório!", AllowEmptyStrings = false)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Preco { get; set; }

        public string Foto { get; set; }
        [Required(ErrorMessage = "Campo Data é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Data do Evento")]
        public DateTime Data_evento { get; set; }
    }
}
