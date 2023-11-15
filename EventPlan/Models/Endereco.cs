using System.ComponentModel.DataAnnotations;

namespace Teste1.Models
{
    public class Endereco
    {
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "Campo CEP é obrigatório.")]
        [StringLength(10, ErrorMessage = "O CEP deve ter no máximo {1} caracteres.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo UF é obrigatório.")]
        [StringLength(2, ErrorMessage = "A UF deve ter no máximo {1} caracteres.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Campo Cidade é obrigatório.")]
        [StringLength(50, ErrorMessage = "A Cidade deve ter no máximo {1} caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Número é obrigatório.")]
        [StringLength(20, ErrorMessage = "O Número deve ter no máximo {1} caracteres.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo Bairro é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Bairro deve ter no máximo {1} caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Rua é obrigatório.")]
        [StringLength(100, ErrorMessage = "A Rua deve ter no máximo {1} caracteres.")]
        public string Rua { get; set; }

        // Construtor vazio
        public Endereco()
        {
            CEP = string.Empty;
            UF = string.Empty;
            Cidade = string.Empty;
            Numero = string.Empty;
            Bairro = string.Empty;
            Rua = string.Empty;
        }

        // Construtor com parâmetros
        public Endereco(string cep, string uf, string cidade, string numero, string bairro, string rua)
        {
            CEP = cep;
            UF = uf;
            Cidade = cidade;
            Numero = numero;
            Bairro = bairro;
            Rua = rua;
        }
    }
}
