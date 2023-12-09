using System.ComponentModel.DataAnnotations;
using Teste1.Models;

public class Evento
{
    public int Id_evento { get; set; }
    [Required(ErrorMessage = "Campo Nome do Evento é obrigatório!", AllowEmptyStrings = false)]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 80 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo Descrição do Evento é obrigatório!", AllowEmptyStrings = false)]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Campo Data e Hora do Evento é obrigatório!", AllowEmptyStrings = false)]
    public DateTime DataHora { get; set; }

    [Required(ErrorMessage = "Campo Data Final do Evento é obrigatório!", AllowEmptyStrings = false)]
    public DateTime DataFinal { get; set; }

    [Required(ErrorMessage = "Campo Aprovação do Evento é obrigatório!", AllowEmptyStrings = false)]
    public bool Aprovado { get; set; }

    [Required(ErrorMessage = "Campo Preço do Evento é obrigatório!", AllowEmptyStrings = false)]
    [Range(0.01, 1000000.00, ErrorMessage = "O preço do evento deve estar entre R$0,01 e R$1.000.000,00.")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "Campo Taxa de Serviço do Evento é obrigatório!", AllowEmptyStrings = false)]
    [Range(0, 100, ErrorMessage = "A taxa de serviço deve estar entre 0% e 100%.")]
    public int TaxaServico { get; set; }

    public Categoria Categoria { get; set; }

    public Endereco Endereco { get; set; }

    public Pessoa Organizador { get; set; }

    public Evento()
    {
        Id_evento = 0;
        Nome = string.Empty;
        Descricao = string.Empty;
        DataHora = DateTime.Now;
        DataFinal = DateTime.Now;
        Aprovado = false;
        Preco = 0.00M;
        TaxaServico = 0;
        Categoria = new Categoria();
        Endereco = new Endereco();
        Organizador = new Pessoa();
    }
}
