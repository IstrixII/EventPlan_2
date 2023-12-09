using System.ComponentModel.DataAnnotations;

namespace Teste1.Models
{
    public class Cidade
    {
        public int Id_cidade { get; set; }
        [Required(ErrorMessage = "Campo Cidade é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome da cidade deve ter entre 3 e 50 caracteres.")]
        public string NomeCidade { get; set; }
        [Required(ErrorMessage = "Campo UF é obrigatório!", AllowEmptyStrings = false)]
        public UF UF { get; set; }

        public Cidade()
        {
            Id_cidade = 0;
            NomeCidade = string.Empty;
            UF = new UF();
        }
    }

}
