using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALPacote_Refeicao
    {
        string connectionString = "";

        public DALPacote_Refeicao()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Pacote_Refeicao> Select(int id)
        {
            // Variavel para armazenar um livro
            Modelo.Pacote_Refeicao aPacote_Refeicao;
            // Cria Lista Vazia
            List<Modelo.Pacote_Refeicao> aListPacote_Refeicao = new List<Modelo.Pacote_Refeicao>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Pacote_Refeicao where id_Pacote = @id";
            cmd.Parameters.AddWithValue("@id", id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aPacote_Refeicao = new Modelo.Pacote_Refeicao(
                        int.Parse(dr["id"].ToString()),
                        int.Parse(dr["id_Pacote"].ToString()),
                        int.Parse(dr["id_Refeicao"].ToString())
                        );
                    // Adiciona o livro lido à lista
                    aListPacote_Refeicao.Add(aPacote_Refeicao);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListPacote_Refeicao;
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
            SqlCommand cmd = new SqlCommand("DELETE FROM Pacote_Refeicao WHERE id_Pacote = @Pacote", conn);
            cmd.Parameters.AddWithValue("@Pacote", pacote);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }
        public void DeleteRefeicao(int refeicao)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Pacote_Refeicao WHERE id_Refeicao = @Refeicao", conn);
            cmd.Parameters.AddWithValue("@Refeicao", refeicao);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Pacote_Refeicao obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Pacote_Refeicao (id_Pacote, id_Refeicao) VALUES(@pacote, @refeicao)", conn);
            cmd.Parameters.AddWithValue("@pacote", obj.id_Pacote);
            cmd.Parameters.AddWithValue("@refeicao", obj.id_Refeicao);
            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public int CountPacote(int id)
        {
            string stmt = "SELECT COUNT(*) FROM Pacote_Refeicao Where id_Pacote = @id ";
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdCount = new SqlCommand(stmt, conn))
            {
                cmdCount.Parameters.AddWithValue("id", id);
                conn.Open();
                count = (int)cmdCount.ExecuteScalar();
            }
            conn.Close();
            return count;
        }
        public int Count()
        {
            string stmt = "SELECT COUNT(*) FROM Pacote_Refeicao ";
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand(stmt, conn))
            {
                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            conn.Close();
            return count;
        }
        public bool CountPC(int idp, int idr)
        {
            string stmt = "SELECT COUNT(*) FROM Pacote_Refeicao WHERE id_Pacote = @idp AND id_Refeicao= @idr";
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdPC = new SqlCommand(stmt, conn))
            {
                cmdPC.Parameters.AddWithValue("idp", idp);
                cmdPC.Parameters.AddWithValue("idr", idr);
                conn.Open();
                count = (int)cmdPC.ExecuteScalar();
            }
            conn.Close();
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}