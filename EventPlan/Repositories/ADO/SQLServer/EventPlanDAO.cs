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

        //Select todas pessoas
        public List<Pessoa> getAll()
        {
            List<Pessoa> carros = new List<Pessoa>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select idPessoa,nome, cpf, dataNascimento,contato,email,senha from tb_pessoa;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Pessoa pessoa = new Pessoa();

                        pessoa.IdPessoa = (int)dr["idPessoa"];
                        pessoa.Nome = dr["nome"].ToString();
                        pessoa.Cpf = (string)dr["Cpf"];
                        pessoa.DataNascimento = (DateTime)dr["dataNascimento"];
                        pessoa.Email = (string)dr["Email"];
                        pessoa.Contato = (string)dr["Contato"];

                        carros.Add(pessoa);
                    }

                }

            }
            return carros;
        }

        public Pessoa getByIdPessoa(int idPessoa)
        {
            Pessoa pessoa = new Pessoa();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select idPessoa,nome, cpf, dataNascimento,contato,email from tb_pessoa where idPessoa=@idPessoa;";
                    command.Parameters.Add(new SqlParameter("@idPessoa", System.Data.SqlDbType.Int)).Value = idPessoa;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        pessoa.IdPessoa = (int)dr["idPessoa"];
                        pessoa.Nome = dr["nome"].ToString();
                        pessoa.Cpf = (string)dr["Cpf"];
                        pessoa.DataNascimento = (DateTime)dr["dataNascimento"];
                        pessoa.Email = (string)dr["Email"];
                        pessoa.Contato = (string)dr["Contato"];
                    }
                }
            }
            return pessoa;
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

        //Update User
        public void updatePessoa(int idPessoa, Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update carro set nome = @nome, cpf = @cpf, dataNascimento = @dataNascimento, contato = @contato, email = @email where idPessoa=@idPessoa;";
                    command.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = pessoa.Nome;
                    command.Parameters.Add(new SqlParameter("@Cpf", System.Data.SqlDbType.VarChar)).Value = pessoa.Cpf;
                    command.Parameters.Add(new SqlParameter("@DataNascimento", System.Data.SqlDbType.Date)).Value = pessoa.DataNascimento;
                    command.Parameters.Add(new SqlParameter("@Contato", System.Data.SqlDbType.VarChar)).Value = pessoa.Contato;
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
                    command.Parameters.Add(new SqlParameter("@idPessoa", System.Data.SqlDbType.Int)).Value = idPessoa;

                    command.ExecuteNonQuery();
                }
            }
        }

        //public void deleteUser(int idPessoa) 
        //{

        //    using (SqlConnection connection = new SqlConnection(this.connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "delete from tb_pessoa where idPessoa = @idPessoa;";
        //            command.Parameters.Add(new SqlParameter("@idPessoa", System.Data.SqlDbType.Int)).Value = idPessoa;

        //            command.ExecuteNonQuery();
        //        }

        //    }

        //}


        //   public void comparacao(Pessoa pessoa)
        //   {
        //      using (SqlConnection connection = new SqlConnection(this.connectionString))
        //       {
        //           connection.Open();
        //          using (SqlCommand command = new SqlCommand())
        //          {
        //               command.Connection = connection;
        //              command.CommandText = "SELECT email,senha FROM tb_pessoa";
        //             command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
        //             command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = pessoa.Senha;
        //          }

        //    }
        //}

        //Create Evento




        //Eventos

        public void addEvento(Evento evento)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    // Inserindo a pessoa com o ID do endereço obtido
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO tb_evento (nome, categoria) VALUES (@Nome, @Categoria); select convert(int,@@identity) as id";

                    command.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = evento.Nome;
                    command.Parameters.Add(new SqlParameter("@Categoria", System.Data.SqlDbType.VarChar)).Value = evento.Categoria;
                    //command.Parameters.Add(new SqlParameter("@Preco", System.Data.SqlDbType.Int)).Value = evento.preco;
                    command.Parameters.Add(new SqlParameter("@Descricao", System.Data.SqlDbType.VarChar)).Value = evento.Descricao;
                    evento.IdEvento = (int)command.ExecuteScalar();
                }
            }
        }






    }
}