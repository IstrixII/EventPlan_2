using Microsoft.CodeAnalysis.Scripting;
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
            List<Pessoa> pessoas = new List<Pessoa>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id_pessoa,nome, cpf, data_nascimento,contato,email,senha from tb_pessoa;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Pessoa pessoa = new Pessoa();

                        pessoa.Id_pessoa = (int)dr["id_pessoa"];
                        pessoa.Nome = dr["nome"].ToString();
                        pessoa.Cpf = (string)dr["Cpf"];
                        pessoa.DataNascimento = (DateTime)dr["data_nascimento"];
                        pessoa.Email = (string)dr["Email"];
                        pessoa.Contato = (string)dr["Contato"];

                        pessoas.Add(pessoa);
                    }

                }

            }
            return pessoas;
        }

        public Pessoa getByIdPessoa(int id_pessoa)
        {
            Pessoa pessoa = new Pessoa();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_pessoa, nome, cpf, data_nascimento, contato, email FROM tb_pessoa WHERE id_pessoa = @id_pessoa;";
                    command.Parameters.Add(new SqlParameter("@id_pessoa", System.Data.SqlDbType.Int)).Value = id_pessoa;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        pessoa.Id_pessoa = (int)dr["id_pessoa"];
                        pessoa.Nome = dr["nome"].ToString();
                        pessoa.Cpf = dr["cpf"].ToString(); 
                        pessoa.DataNascimento = (DateTime)dr["data_nascimento"];
                        pessoa.Contato = dr["contato"].ToString(); 
                        pessoa.Email = dr["email"].ToString(); 
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
            command.CommandText = "INSERT INTO tb_pessoa (nome, cpf, data_nascimento,contato,email,senha,id_nivel) VALUES (@Nome, @Cpf, @DataNascimento,@Contato,@Email,@Senha,1); select convert(int,@@identity) as id";

            command.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = pessoa.Nome;
            command.Parameters.Add(new SqlParameter("@Cpf", System.Data.SqlDbType.VarChar)).Value = pessoa.Cpf;
            command.Parameters.Add(new SqlParameter("@DataNascimento", System.Data.SqlDbType.Date)).Value = pessoa.DataNascimento;
            command.Parameters.Add(new SqlParameter("@Contato", System.Data.SqlDbType.VarChar)).Value = pessoa.Contato;
            command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pessoa.Senha);
            command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = hashedPassword;


            pessoa.Id_pessoa = (int)command.ExecuteScalar();
        }
    }
}

        //Update User
        public void updatePessoa(int id_pessoa, Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE tb_pessoa SET nome = @Nome, cpf = @Cpf, dataNascimento = @DataNascimento, contato = @Contato, email = @Email WHERE id_pessoa = @IdPessoa;";

                    command.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = pessoa.Nome;
                    command.Parameters.Add(new SqlParameter("@Cpf", System.Data.SqlDbType.VarChar)).Value = pessoa.Cpf;
                    command.Parameters.Add(new SqlParameter("@DataNascimento", System.Data.SqlDbType.Date)).Value = pessoa.DataNascimento;
                    command.Parameters.Add(new SqlParameter("@Contato", System.Data.SqlDbType.VarChar)).Value = pessoa.Contato;
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
                    command.Parameters.Add(new SqlParameter("@IdPessoa", System.Data.SqlDbType.Int)).Value = id_pessoa;

                    command.ExecuteNonQuery();
                }
            }
        }


        public void deleteUser(int id_pessoa) 
        {

            using (SqlConnection connection = new SqlConnection(this.connectionString))
           {
              connection.Open();

               using (SqlCommand command = new SqlCommand())
               {
                   command.Connection = connection;
                   command.CommandText = "update tb_pessoa set ativo = 0 where id_pessoa = @id_pessoa;";
                  command.Parameters.Add(new SqlParameter("@id_pessoa", System.Data.SqlDbType.Int)).Value = id_pessoa;

                   command.ExecuteNonQuery();
              }

           }

        }


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