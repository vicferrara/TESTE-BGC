using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Cliente
    {

        private string StringConnection = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;

        SqlConnection sql = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public int idCliente { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cep { get; set; }

        public List<Cliente> GetAll()
        {

            List<Cliente> clientes = new List<Cliente>();

            clientes.Add(new Cliente()
            {
                nome = "aaa",
                dataNascimento = DateTime.Now,
                cep = "123456789"
            });

            clientes.Add(new Cliente()
            {
                nome = "aaa",
                dataNascimento = DateTime.Now,
                cep = "123456789"
            });

            clientes.Add(new Cliente()
            {
                nome = "aaa",
                dataNascimento = DateTime.Now,
                cep = "123456789"
            });

            return clientes;
        }

        public void Inserir (Cliente cliente)
        {
            AbrirConexao();

            try
            {
                cmd.Connection = sql;

                cmd.CommandText = "INSERT INTO dbo.Cliente(nome, dataNascimento, cep) VALUES(@nome, @dataNascimento, @cep)";

                cmd.Parameters.AddWithValue("nome", cliente.nome);
                cmd.Parameters.AddWithValue("dataNascimento", cliente.dataNascimento);
                cmd.Parameters.AddWithValue("cep", cliente.cep);

                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                FecharConexao();
            }
            finally
            {
                FecharConexao();
            }

        }

        private void AbrirConexao()
        {
            sql.ConnectionString = StringConnection;

            sql.Open();

            cmd.CommandType = System.Data.CommandType.Text;

        }

        private void FecharConexao()
        {
            sql.Close();
        }

    }
}