using System.ComponentModel.DataAnnotations;

namespace Teste1.Models
{
    public class UF
    {
        public int Id_uf { get; set; }
        [Required(ErrorMessage = "Campo UF é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve ter 2 caracteres.")]
        public string SiglaUF { get; set; }
        [Required(ErrorMessage = "Campo Nome do UF é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome do UF deve ter entre 3 e 255 caracteres.")]
        public string NomeUF { get; set; }

        public UF()
        {
            Id_uf = 0;
            SiglaUF = string.Empty;
            NomeUF = string.Empty;
        }
    }

}
