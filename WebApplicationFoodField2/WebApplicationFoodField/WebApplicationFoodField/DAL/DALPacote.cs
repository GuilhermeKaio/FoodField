using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALPacote
    {
        string connectionString = "";

        public DALPacote()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Pacote> SelectAll(int type)
        {
            Modelo.Pacote aPacote;
            List<Modelo.Pacote> aListPacote = new List<Modelo.Pacote>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            if (type == 1)
            {
                cmd.CommandText = "Select * from Pacote ORDER BY Nome ASC";
            }
            else
            {
                if (type == 2)
                {
                    cmd.CommandText = "Select * from Pacote ORDER BY Nome DESC";
                }
                else
                {
                    if (type == 3)
                    {
                        cmd.CommandText = "Select * from Pacote ORDER BY Preco ASC";
                    }
                    else
                    {
                        if (type == 4)
                        {
                            cmd.CommandText = "Select * from Pacote ORDER BY Preco DESC";
                        }
                        else
                        {
                            cmd.CommandText = "Select * from Pacote";
                        }
                    }
                }
            }

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aPacote = new Modelo.Pacote(
                        int.Parse(dr["id"].ToString()),
                        dr["Nome"].ToString(),
                        double.Parse(dr["Preco"].ToString()),
                        dr["Descricao"].ToString(),
                        dr["Url_Imagem"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListPacote.Add(aPacote);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListPacote;
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Pacote obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            DAL.DALAvaliacao DA = new DALAvaliacao();
            DAL.DALTransacaoPacote DT = new DALTransacaoPacote();
            DAL.DALPacote_Refeicao DPR = new DALPacote_Refeicao();
            DAL.DALHistorico DH = new DALHistorico();

            DA.DeletePacote(obj.id);
            DT.DeletePacote(obj.id);
            DPR.DeletePacote(obj.id);
            DH.DeletePacote(obj.id);

            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM Pacote WHERE id = @Pacote_id", conn);
            cmd.Parameters.AddWithValue("@Pacote_id", obj.id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateImagem(Modelo.Pacote obj)
        {
            SqlConnection conn = new SqlConnection(connectionString); ;
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("UPDATE Pacote SET Url_Imagem = @Imagem where id = @id", conn);
            cmd.Parameters.AddWithValue("@Imagem", obj.Url_Imagem);
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Pacote obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Pacote (Nome, Preco, Descricao) VALUES(@Nome, @Preco, @Descricao)", conn);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            cmd.Parameters.AddWithValue("@Preco", obj.Preco);
            cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Pacote obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE Pacote SET Nome = @Nome, Preco = @Preco, Descricao = @Descricao where id = @id", conn);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            cmd.Parameters.AddWithValue("@Preco", obj.Preco);
            cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("@id", obj.id);
            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Pacote> Select(int id)
        {
            // Variavel para armazenar um livro
            Modelo.Pacote aPacote;
            // Cria Lista Vazia
            List<Modelo.Pacote> aListPacote = new List<Modelo.Pacote>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Pacote Where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aPacote = new Modelo.Pacote(
                        int.Parse(dr["id"].ToString()),
                        dr["Nome"].ToString(),
                        double.Parse(dr["Preco"].ToString()),
                        dr["Descricao"].ToString(),
                        dr["Url_Imagem"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListPacote.Add(aPacote);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListPacote;
        }
        public int A()
        {
            string stmt = "SELECT COUNT(*) FROM Pacote ";
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdCount = new SqlCommand(stmt, conn))
            {
                conn.Open();
                count = (int)cmdCount.ExecuteScalar();
            }
            conn.Close();
            return count;
        }
    }
}