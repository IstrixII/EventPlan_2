using System.ComponentModel.DataAnnotations;

namespace Teste1.Models
{
    public class Categoria
    {
        public int Id_categoria { get; set; }
        [Required(ErrorMessage = "Campo Categoria é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 80 caracteres.")]
        public string NomeCategoria { get; set; }
        [Required(ErrorMessage = "Campo Descrição da Categoria é obrigatório!", AllowEmptyStrings = false)]
        public string DescricaoCategoria { get; set; }

        public Categoria()
        {
            Id_categoria = 0;
            NomeCategoria = string.Empty;
            DescricaoCategoria = string.Empty;
        }
    }

}
