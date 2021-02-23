using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALAdministrador
    {
        string connectionString = "";

        public DALAdministrador()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Administrador> SelectAll()
        {
            // Variavel para armazenar um livro
            Modelo.Administrador aAdministrador;
            // Cria Lista Vazia
            List<Modelo.Administrador> aListAdministrador = new List<Modelo.Administrador>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Administrador";
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aAdministrador = new Modelo.Administrador(
                        int.Parse(dr["id"].ToString()),
                        dr["Nome"].ToString(),
                        dr["Telefone"].ToString(),
                        dr["Email"].ToString(),
                        dr["Login"].ToString(),
                        dr["Senha"].ToString(),
                        DateTime.Parse(dr["DataNascimento"].ToString())
                        );
                    // Adiciona o livro lido à lista
                    aListAdministrador.Add(aAdministrador);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListAdministrador;
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Administrador obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Administrador WHERE id = @Administrador_id", conn);
            cmd.Parameters.AddWithValue("@Administrador_id", obj.id);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Administrador obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Administrador (Nome, Telefone, Email, Login, Senha, DataNascimento) VALUES(@Nome, @Telefone, @Email, @Login, @Senha, @DataNascimento)", conn);
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
        public void Update(Modelo.Administrador obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE Administrador SET Nome = @Nome, Telefone = @Telefone, Email = @Email, Login = @Login, Senha = @Senha, DataNascimento = @DataNascimento where id = @id ", conn);
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
        public List<Modelo.Administrador> Select(int id)
        {
            // Variavel para armazenar um livro
            Modelo.Administrador aAdministrador;
            // Cria Lista Vazia
            List<Modelo.Administrador> aListAdministrador = new List<Modelo.Administrador>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Administrador Where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aAdministrador = new Modelo.Administrador(
                        int.Parse(dr["id"].ToString()),
                        dr["Nome"].ToString(),
                        dr["Telefone"].ToString(),
                        dr["Email"].ToString(),
                        dr["Login"].ToString(),
                        dr["Senha"].ToString(),
                        DateTime.Parse(dr["DataNascimento"].ToString())
                        );
                    // Adiciona o livro lido à lista
                    aListAdministrador.Add(aAdministrador);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListAdministrador;
        }
        public int LogarLogin(string Login, string senha)
        {
            string stmt = "Select id from Administrador where Login = @Login and Senha = @senha";
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
            string stmt = "Select id from Administrador where Email = @Email and Senha = @senha";
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

        public int CountLogin(string l)
        {
            string stmt = "SELECT COUNT(*) FROM Administrador WHERE Login = @login ";
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
            string stmt = "SELECT COUNT(*) FROM Administrador WHERE Email = @email ";
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
