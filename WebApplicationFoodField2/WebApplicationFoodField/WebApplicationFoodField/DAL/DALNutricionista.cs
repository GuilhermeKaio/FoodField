using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALNutricionista
    {
        string connectionString = "";

        public DALNutricionista()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Nutricionista> SelectAll()
        {
            // Variavel para armazenar um livro
            Modelo.Nutricionista aNutricionista;
            // Cria Lista Vazia
            List<Modelo.Nutricionista> aListNutricionista = new List<Modelo.Nutricionista>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Nutricionista";
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aNutricionista = new Modelo.Nutricionista(
                        int.Parse(dr["id"].ToString()),
                        dr["Nome"].ToString(),
                        dr["Telefone"].ToString(),
                        dr["Email"].ToString(),
                        dr["Login"].ToString(),
                        dr["Senha"].ToString(),
                        DateTime.Parse(dr["DataNascimento"].ToString())
                        );
                    // Adiciona o livro lido à lista
                    aListNutricionista.Add(aNutricionista);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListNutricionista;
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Nutricionista obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Nutricionista WHERE id = @Nutricionista_id", conn);
            cmd.Parameters.AddWithValue("@Nutricionista_id", obj.id);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Nutricionista obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Nutricionista (Nome, Telefone, Email, Login, Senha, DataNascimento) VALUES(@Nome, @Telefone, @Email, @Login, @Senha, @DataNascimento)", conn);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            cmd.Parameters.AddWithValue("@Telefone", obj.Telefone);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Login", obj.Login);
            cmd.Parameters.AddWithValue("@Senha", obj.Senha);
            cmd.Parameters.AddWithValue("@DataNascimento", obj.DataNascimento);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Nutricionista obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE Nutricionista SET Nome = @Nome, Telefone = @Telefone, Email = @Email, Login = @Login, Senha = @Senha, DataNascimento = @DataNascimento where id = @id ", conn);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            cmd.Parameters.AddWithValue("@Telefone", obj.Telefone);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Login", obj.Login);
            cmd.Parameters.AddWithValue("@Senha", obj.Senha);
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@DataNascimento", obj.DataNascimento);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Nutricionista> Select(int id)
        {
            // Variavel para armazenar um livro
            Modelo.Nutricionista aNutricionista;
            // Cria Lista Vazia
            List<Modelo.Nutricionista> aListNutricionista = new List<Modelo.Nutricionista>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Nutricionista Where id = @nutid";
            cmd.Parameters.AddWithValue("@nutid", id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aNutricionista = new Modelo.Nutricionista(
                        int.Parse(dr["id"].ToString()),
                        dr["Nome"].ToString(),
                        dr["Telefone"].ToString(),
                        dr["Email"].ToString(),
                        dr["Login"].ToString(),
                        dr["Senha"].ToString(),
                        DateTime.Parse(dr["DataNascimento"].ToString())
                        );
                    // Adiciona o livro lido à lista
                    aListNutricionista.Add(aNutricionista);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListNutricionista;
        }
        public int LogarLogin(string Login, string senha)
        {
            string stmt = "Select id from Nutricionista where Login = @Login and Senha = @senha";
            int id = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdid = new SqlCommand(stmt, conn))
            {
                conn.Open();
                cmdid.Parameters.AddWithValue("@Login", Login);
                cmdid.Parameters.AddWithValue("@senha", senha);
                id = (int)cmdid.ExecuteScalar();
            }
            return id;
        }
        public int LogarEmail(string Email, string senha)
        {
            string stmt = "Select id from Nutricionista where Email = @Email and Senha = @senha";
            int id = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdid = new SqlCommand(stmt, conn))
            {
                conn.Open();
                cmdid.Parameters.AddWithValue("@Email", Email);
                cmdid.Parameters.AddWithValue("@senha", senha);
                id = (int)cmdid.ExecuteScalar();
            }
            return id;
        }
        public int Count()
        {
            string stmt = "SELECT COUNT(*) FROM Nutricionista ";
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
        public int CountLogin(string l)
        {
            string stmt = "SELECT COUNT(*) FROM Nutricionista WHERE Login = @login ";
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdCount = new SqlCommand(stmt, conn))
            {
                cmdCount.Parameters.AddWithValue("login", l);
                conn.Open();
                count = (int)cmdCount.ExecuteScalar();
            }
            conn.Close();
            return count;
        }
        public int CountEmail(string l)
        {
            string stmt = "SELECT COUNT(*) FROM Nutricionista WHERE Email = @email ";
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdCount = new SqlCommand(stmt, conn))
            {
                cmdCount.Parameters.AddWithValue("email", l);
                conn.Open();
                count = (int)cmdCount.ExecuteScalar();
            }
            conn.Close();
            return count;
        }
    }
}
