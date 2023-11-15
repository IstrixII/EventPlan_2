using System.ComponentModel.DataAnnotations;

namespace Teste1.Models
{
    public class Pessoa_Juridica : Pessoa
    {
        private int Id_Pessoa { get; set; }
        [Required(ErrorMessage = "Campo CNPJ é obrigatório!", AllowEmptyStrings = false)]
        private string? CNPJ {  get; set; }

        public Pessoa_Juridica()
        {
            Id_Pessoa = 0;
            CNPJ = string.Empty;
        }
    }
}
