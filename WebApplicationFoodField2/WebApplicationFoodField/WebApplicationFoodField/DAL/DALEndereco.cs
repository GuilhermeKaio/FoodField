using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALEndereco
    {
        string connectionString = "";

        public DALEndereco()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Endereco> Select(int id)
        {
            // Variavel para armazenar um livro
            Modelo.Endereco aEndereco;
            // Cria Lista Vazia
            List<Modelo.Endereco> aListEndereco = new List<Modelo.Endereco>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Endereco where id_cliente = @id";
            cmd.Parameters.AddWithValue("@id", id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aEndereco = new Modelo.Endereco(
                        int.Parse(dr["id"].ToString()),
                        dr["Rua"].ToString(),
                        dr["Numero"].ToString(),
                        dr["CEP"].ToString(),
                        dr["Bairro"].ToString(),
                        dr["Cidade"].ToString(),
                        dr["UF"].ToString(),
                        int.Parse(dr["Id_Cliente"].ToString())
                        );
                    // Adiciona o livro lido à lista
                    aListEndereco.Add(aEndereco);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListEndereco;
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Endereco obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Endereco (Rua, Numero, CEP, Bairro, Cidade, UF, Id_Cliente) VALUES(@Rua, @Numero, @CEP, @Bairro, @Cidade, @UF, @Id_Cliente)", conn);
            cmd.Parameters.AddWithValue("@Rua", obj.Rua);
            cmd.Parameters.AddWithValue("@Numero", obj.Numero);
            cmd.Parameters.AddWithValue("@CEP", obj.CEP);
            cmd.Parameters.AddWithValue("@Bairro", obj.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", obj.Cidade);
            cmd.Parameters.AddWithValue("@UF", obj.UF);
            cmd.Parameters.AddWithValue("@Id_Cliente", obj.Id_Cliente);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }
        public void DeleteUsuario(int pacote)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM Endereco WHERE id_Cliente = @Cliente", conn);
            cmd.Parameters.AddWithValue("@Cliente", pacote);
            cmd.ExecuteNonQuery();

        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Endereco obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Endereco WHERE id = @Endereco_id", conn);
            cmd.Parameters.AddWithValue("@Endereco_id", obj.id);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Endereco> SelectE(int id)
        {
            // Variavel para armazenar um livro
            Modelo.Endereco aEndereco;
            // Cria Lista Vazia
            List<Modelo.Endereco> aListEndereco = new List<Modelo.Endereco>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Endereco where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aEndereco = new Modelo.Endereco(
                        int.Parse(dr["id"].ToString()),
                        dr["Rua"].ToString(),
                        dr["Numero"].ToString(),
                        dr["CEP"].ToString(),
                        dr["Bairro"].ToString(),
                        dr["Cidade"].ToString(),
                        dr["UF"].ToString(),
                        int.Parse(dr["Id_Cliente"].ToString())
                        );
                    // Adiciona o livro lido à lista
                    aListEndereco.Add(aEndereco);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListEndereco;
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Endereco obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE Endereco SET Rua = @Rua, Numero = @Numero, CEP = @CEP, Bairro = @Bairro, Cidade = @Cidade, UF = @UF where id = @id ", conn);
            cmd.Parameters.AddWithValue("@Rua", obj.Rua);
            cmd.Parameters.AddWithValue("@Numero", obj.Numero);
            cmd.Parameters.AddWithValue("@CEP", obj.CEP);
            cmd.Parameters.AddWithValue("@Bairro", obj.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", obj.Cidade);
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@UF", obj.UF);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }
        public int Count(int id)
        {
            string stmt = "SELECT COUNT(*) FROM Endereco Where id_cliente = @Cliente ";
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdCount = new SqlCommand(stmt, conn))
            {
                cmdCount.Parameters.AddWithValue("Cliente", id);
                conn.Open();
                count = (int)cmdCount.ExecuteScalar();
            }
            conn.Close();
            return count;
        }
    }
}