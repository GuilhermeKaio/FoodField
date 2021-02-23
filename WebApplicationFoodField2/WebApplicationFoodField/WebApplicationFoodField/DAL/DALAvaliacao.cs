using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALAvaliacao
    {
        string connectionString = "";

        public DALAvaliacao()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        public List<Modelo.Avaliacao> SelectId_Cliente(int id)
        {
            Modelo.Avaliacao aAvaliacao;
            // Cria Lista Vazia
            List<Modelo.Avaliacao> aListAvaliacao = new List<Modelo.Avaliacao>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            // define SQL do comando
            SqlCommand cmd = new SqlCommand("Select * from Avaliacao where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aAvaliacao = new Modelo.Avaliacao(
                        int.Parse(dr["id"].ToString()),
                        int.Parse(dr["Nota"].ToString()),
                        int.Parse(dr["id_Pacote"].ToString()),
                        int.Parse(dr["id_Cliente"].ToString())
                        );
                    // Adiciona o livro lido à lista
                    aListAvaliacao.Add(aAvaliacao);
                }
            }
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListAvaliacao;
        }
        public int Media(int id)
        {
            string stmt = "select avg(convert(real,Nota)) from Avaliacao where id_Pacote = @id ";
            int media = 0;
            double a;

            SqlConnection conn = new SqlConnection(connectionString);


            using (SqlCommand cmd = new SqlCommand(stmt, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                try
                {
                    a = Convert.ToDouble(cmd.ExecuteScalar());
                    media = Convert.ToInt32(Math.Round(a));
                }
                catch
                {
                    media = 0;
                }
            }
            conn.Close();
            return media;

        }
        public void Insert(Modelo.Avaliacao obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Avaliacao (Nota, id_Pacote, id_Cliente) VALUES(@Nota, @Pacote, @Cliente)", conn);
            cmd.Parameters.AddWithValue("@Nota", obj.Nota);
            cmd.Parameters.AddWithValue("@Pacote", obj.id_Pacote);
            cmd.Parameters.AddWithValue("@Cliente", obj.id_Cliente);
            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void Delete(Modelo.Avaliacao obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Avaliacao Where id_Pacote = @Pacote AND id_Cliente = @Cliente", conn);
            cmd.Parameters.AddWithValue("@Pacote", obj.id_Pacote);
            cmd.Parameters.AddWithValue("@Cliente", obj.id_Cliente);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteCliente(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Avaliacao Where id_Cliente = @Cliente", conn);
            cmd.Parameters.AddWithValue("@Cliente", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeletePacote(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Avaliacao Where id_Pacote = @Pacote", conn);
            cmd.Parameters.AddWithValue("@Pacote", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int SelectNota(int pacote, int cliente)
        {
            string stmt = "select Nota from Avaliacao where id_Pacote = @pacote AND id_Cliente = @cliente";
            int nota = 0;

            SqlConnection conn = new SqlConnection(connectionString);


            using (SqlCommand cmd = new SqlCommand(stmt, conn))
            {
                cmd.Parameters.AddWithValue("@pacote", pacote);
                cmd.Parameters.AddWithValue("@cliente", cliente);
                conn.Open();
                try
                {
                    nota = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    nota = 0;
                }
            }
            conn.Close();
            return nota;
        }
    }

}
