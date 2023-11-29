using System;
using System.ComponentModel.DataAnnotations;

namespace Teste1.Models
{
    public class Pessoa
    {
        public int Id_pessoa { get; set; }
        [Required(ErrorMessage = "Campo Nome é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo Data de nascimento é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Campo Contato é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(14, MinimumLength = 14)]
        public string Contato { get; set; }

        public string Foto { get; set; }

        public string Descricao { get; set; }


        [Required(ErrorMessage = "Campo Email é obrigatório!", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Mínimo de 8 e máximo de 30 caracteres.")]
        public string Senha { get; set; }

        // Adicionando referência a Endereco
        public Endereco Endereco { get; set; }

        public string ConfirmacaoSenha { get; set; }


        public Pessoa()
        {
            Id_pessoa = 0;
            Nome = string.Empty;
            Cpf = string.Empty;
            DataNascimento = DateTime.Now;
            Email = string.Empty;
            Contato = string.Empty;
            Foto = string.Empty;
            Senha = string.Empty;
            Endereco = new Endereco();
            Descricao = string.Empty;

        }


        //public override bool Equals(object? obj)
        //{
        //    return obj is Pessoa pessoa &&
        //           _email == pessoa._email &&
        //           _senha == pessoa._senha;
        //}

    }
 }
