using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Teste1.Models;

namespace Teste1.Repositories.ADO.SQLServer
{
    public class EventPlanDAO
    {
        private readonly string connectionString;

        public EventPlanDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void add(Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    // Inserindo a pessoa com o ID do endereço obtido
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO tb_pessoa (nome, cpf, dataNascimento,contato,email,senha) VALUES (@Nome, @Cpf, @DataNascimento,@Contato,@Email,@Senha); select convert(int,@@identity) as id";

                    command.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = pessoa.Nome;
                    command.Parameters.Add(new SqlParameter("@Cpf", System.Data.SqlDbType.VarChar)).Value = pessoa.Cpf;
                    command.Parameters.Add(new SqlParameter("@DataNascimento", System.Data.SqlDbType.Date)).Value = pessoa.DataNascimento;
                    //commandPessoa.Parameters.Add(new SqlParameter("@IdEndereco", System.Data.SqlDbType.Int)).Value = idEndereco;
                    //commandPessoa.Parameters.Add(new SqlParameter("@Foto", System.Data.SqlDbType.VarChar)).Value = pessoa.Foto;
                    command.Parameters.Add(new SqlParameter("@Contato", System.Data.SqlDbType.VarChar)).Value = pessoa.Contato;
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
                    command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = pessoa.Senha;
                    pessoa.IdPessoa = (int)command.ExecuteScalar();
                }
            }
        }
        public void updateSenha(Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
   
                    command.Connection = connection;
                    command.CommandText = "UPDATE tb_pessoa SET senha = @Senha WHERE email = @Email";
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
                    command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = pessoa.Senha;

                    command.ExecuteNonQuery();
                }
            }
        }


        //public void comparacao(Pessoa pessoa)
        //{
        //    using (SqlConnection connection = new SqlConnection(this.connectionString))
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "SELECT email,senha FROM tb_pessoa";
        //            command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
        //            command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = pessoa.Senha;
        //        }

        //    }
        //}

    }
}