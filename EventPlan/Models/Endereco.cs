using System.ComponentModel.DataAnnotations;
using Teste1.Models;

public class Endereco
{
    public int Id_endereco { get; set; }
    [Required(ErrorMessage = "Campo CEP é obrigatório!", AllowEmptyStrings = false)]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter 8 caracteres.")]
    public string Cep { get; set; }
    [Required(ErrorMessage = "Campo Bairro é obrigatório!", AllowEmptyStrings = false)]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O bairro deve ter entre 3 e 50 caracteres.")]
    public string Bairro { get; set; }
    [Required(ErrorMessage = "Campo Rua é obrigatório!", AllowEmptyStrings = false)]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "A rua deve ter entre 3 e 80 caracteres.")]
    public string Rua { get; set; }
    [Required(ErrorMessage = "Campo Número é obrigatório!", AllowEmptyStrings = false)]
    public string Numero { get; set; }
    [StringLength(100, ErrorMessage = "O complemento deve ter no máximo 100 caracteres.")]
    public string Complemento { get; set; }
    [Required(ErrorMessage = "Campo Cidade é obrigatório!", AllowEmptyStrings = false)]
    public Cidade Cidade { get; set; }

    public Endereco()
    {
        Id_endereco = 0;
        Cep = string.Empty;
        Bairro = string.Empty;
        Rua = string.Empty;
        Numero = string.Empty;
        Complemento = string.Empty;
        Cidade = new Cidade();
    }
   
}
