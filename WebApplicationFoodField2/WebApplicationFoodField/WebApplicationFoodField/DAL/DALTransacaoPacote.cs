using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALTransacaoPacote
    {
        string connectionString = "";

        public DALTransacaoPacote()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.TransacaoPacote> Select(int id)
        {
            // Variavel para armazenar um livro
            Modelo.TransacaoPacote aTransacaoPacote;
            // Cria Lista Vazia
            List<Modelo.TransacaoPacote> aListTransacaoPacote = new List<Modelo.TransacaoPacote>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from TransacaoPacote where Cliente_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aTransacaoPacote = new Modelo.TransacaoPacote(
                        int.Parse(dr["id"].ToString()),
                        int.Parse(dr["Pacote_id"].ToString()),
                        int.Parse(dr["Cliente_id"].ToString())
                        );
                    // Adiciona o livro lido à lista
                    aListTransacaoPacote.Add(aTransacaoPacote);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListTransacaoPacote;
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.TransacaoPacote obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO TransacaoPacote (Pacote_id, Cliente_id) VALUES(@Pacote, @Cliente)", conn);
            cmd.Parameters.AddWithValue("@Pacote", obj.Pacote_id);
            cmd.Parameters.AddWithValue("@Cliente", obj.Cliente_id);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }
        public void Delete(int pacote, int cliente)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM TransacaoPacote WHERE Pacote_id = @Pacote AND Cliente_id = @Cliente", conn);
            cmd.Parameters.AddWithValue("@Pacote", pacote);
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }
        public void DeletePacote(int pacote)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM TransacaoPacote WHERE Pacote_id = @Pacote", conn);
            cmd.Parameters.AddWithValue("@Pacote", pacote);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }
        public void DeleteCliente(int pacote)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM TransacaoPacote WHERE Cliente_id = @Cliente", conn);
            cmd.Parameters.AddWithValue("@Cliente", pacote);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }
        public bool VerificarT(int pacote, int cliente)
        {
            string stmt = "SELECT COUNT(*) FROM TransacaoPacote WHERE Cliente_id = @Cliente_id and Pacote_id = @Pacote_id ";
            
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            
            using (SqlCommand cmd = new SqlCommand(stmt, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Cliente_id", cliente);
                cmd.Parameters.AddWithValue("@Pacote_id", pacote );
                count = (int)cmd.ExecuteScalar();
            }
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}