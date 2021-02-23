using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALRefeicao
    {
        string connectionString = "";

        public DALRefeicao()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Refeicao> SelectAll()
        {
            // Variavel para armazenar um livro
            Modelo.Refeicao aRefeicao;
            // Cria Lista Vazia
            List<Modelo.Refeicao> aListRefeicao = new List<Modelo.Refeicao>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Refeicao";
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aRefeicao = new Modelo.Refeicao(
                        int.Parse(dr["id"].ToString()),
                        dr["Ingredientes"].ToString(),
                        dr["ModoPreparo"].ToString(),
                        dr["Url_Imagem"].ToString(),
                        dr["Nome"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListRefeicao.Add(aRefeicao);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListRefeicao;
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Refeicao obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();

            DAL.DALPacote_Refeicao aDALPacote_Refeicao = new DALPacote_Refeicao();

            aDALPacote_Refeicao.DeleteRefeicao(obj.id);

            SqlCommand cmd = new SqlCommand("DELETE FROM Refeicao WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", obj.id);

            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Refeicao obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Refeicao (Ingredientes, ModoPreparo, Nome) VALUES(@Ingredientes, @ModoPreparo, @Nome)", conn);
            cmd.Parameters.AddWithValue("@Ingredientes", obj.Ingredientes);
            cmd.Parameters.AddWithValue("@ModoPreparo", obj.ModoPreparo);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void InsertImagem(Modelo.Refeicao obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Refeicao (Url_Imagem) VALUES(@Imagem)", conn);
            cmd.Parameters.AddWithValue("@Imagem", obj.Url_Imagem);
            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void UpdateImagem(Modelo.Refeicao obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("Update Refeicao SET Url_Imagem = @Imagem WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@Imagem", obj.Url_Imagem);
            cmd.Parameters.AddWithValue("@id", obj.id);
            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Refeicao obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE Refeicao SET Ingredientes = @Ingredientes, ModoPreparo = @ModoPreparo, Nome = @Nome where id = @id", conn);
            cmd.Parameters.AddWithValue("@Ingredientes", obj.Ingredientes);
            cmd.Parameters.AddWithValue("@ModoPreparo", obj.ModoPreparo);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            cmd.Parameters.AddWithValue("@id", obj.id);
            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Refeicao> Select(int id)
        {
            // Variavel para armazenar um livro
            Modelo.Refeicao aRefeicao;
            // Cria Lista Vazia
            List<Modelo.Refeicao> aListRefeicao = new List<Modelo.Refeicao>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Refeicao Where id = @refid";
            cmd.Parameters.AddWithValue("@refid", id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aRefeicao = new Modelo.Refeicao(
                        int.Parse(dr["id"].ToString()),
                        dr["Ingredientes"].ToString(),
                        dr["ModoPreparo"].ToString(),
                        dr["Url_Imagem"].ToString(),
                        dr["Nome"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListRefeicao.Add(aRefeicao);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListRefeicao;
        }
        public int Count()
        {
            string stmt = "SELECT COUNT(*) FROM Refeicao ";
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
    }
}