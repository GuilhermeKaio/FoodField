using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALClientes
    {
        string connectionString = "";

        public DALClientes()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Clientes> SelectAll()
        {
            string padrao;
            padrao = "Imagens\\user.jpg";
            Modelo.Clientes aClientes;
            List<Modelo.Clientes> aListClientes = new List<Modelo.Clientes>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Clientes";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    if (dr["Url_Imagem"].ToString() == "")
                    {
                        aClientes = new Modelo.Clientes(
                         int.Parse(dr["id"].ToString()),
                         dr["Nome"].ToString(),
                         dr["CPF"].ToString(),
                         dr["Telefone"].ToString(),
                         dr["Email"].ToString(),
                         dr["Login"].ToString(),
                         dr["Senha"].ToString(),
                         DateTime.Parse(dr["DataCadastro"].ToString()),
                         double.Parse(dr["Saldo"].ToString()),
                         padrao
                         );
                    }
                    else
                    {
                        aClientes = new Modelo.Clientes(
                                                int.Parse(dr["id"].ToString()),
                                                dr["Nome"].ToString(),
                                                dr["CPF"].ToString(),
                                                dr["Telefone"].ToString(),
                                                dr["Email"].ToString(),
                                                dr["Login"].ToString(),
                                                dr["Senha"].ToString(),
                                                DateTime.Parse(dr["DataCadastro"].ToString()),
                                                double.Parse(dr["Saldo"].ToString()),
                                                dr["Url_Imagem"].ToString()
                                                );
                    }
                    aListClientes.Add(aClientes);
                }
            }
            dr.Close();
            conn.Close();

            return aListClientes;
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Clientes obj)
        {
            DAL.DALHistorico AH = new DALHistorico();
            DAL.DALAvaliacao DA = new DALAvaliacao();
            DAL.DALEndereco DE = new DALEndereco();
            DAL.DALTransacaoPacote DT = new DALTransacaoPacote();

            DT.DeleteCliente(obj.id);
            DE.DeleteUsuario(obj.id);
            DA.DeleteCliente(obj.id);
            AH.DeleteUsuario(obj.id);

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE id = @Clientes_id", conn);
            cmd.Parameters.AddWithValue("@Clientes_id", obj.id);
            
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete1(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Clientes obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO Clientes (Nome, CPF, Telefone, Email, Login, Senha, DataCadastro, Saldo , Url_Imagem) VALUES(@Nome, @CPF, @Telefone, @Email, @Login, @Senha, @DataCadastro, @Saldo, @Imagem)", conn);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            cmd.Parameters.AddWithValue("@CPF", obj.CPF);
            cmd.Parameters.AddWithValue("@Telefone", obj.Telefone);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Login", obj.Login);
            cmd.Parameters.AddWithValue("@Senha", obj.Senha);
            cmd.Parameters.AddWithValue("@DataCadastro", obj.DataCadastro);
            cmd.Parameters.AddWithValue("@Saldo", obj.Saldo);
            cmd.Parameters.AddWithValue("@Imagem", obj.Url_Imagem);
            // Executa Comando
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Clientes obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("UPDATE Clientes SET Nome = @Nome, CPF = @CPF, Telefone = @Telefone, Email = @Email where id = @id ", conn);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            cmd.Parameters.AddWithValue("@CPF", obj.CPF);
            cmd.Parameters.AddWithValue("@Telefone", obj.Telefone);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateImagem(Modelo.Clientes obj)
        {
            SqlConnection conn = new SqlConnection(connectionString); ;
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("UPDATE Clientes SET Url_Imagem = @Imagem where id = @id", conn);
            cmd.Parameters.AddWithValue("@Imagem", obj.Url_Imagem);
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Clientes> Select1(int id)
        {
            // Variavel para armazenar um livro
            string padrao;
            padrao = "Imagens\\user.jpg";
            Modelo.Clientes aClientes;
            // Cria Lista Vazia
            List<Modelo.Clientes> aListClientes = new List<Modelo.Clientes>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Clientes where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    if (dr["Url_Imagem"].ToString() == "")
                    {
                        aClientes = new Modelo.Clientes(
                         int.Parse(dr["id"].ToString()),
                         dr["Nome"].ToString(),
                         dr["CPF"].ToString(),
                         dr["Telefone"].ToString(),
                         dr["Email"].ToString(),
                         dr["Login"].ToString(),
                         dr["Senha"].ToString(),
                         DateTime.Parse(dr["DataCadastro"].ToString()),
                         double.Parse(dr["Saldo"].ToString()),
                         padrao
                         );
                    }
                    else
                    {
                        aClientes = new Modelo.Clientes(
                                                int.Parse(dr["id"].ToString()),
                                                dr["Nome"].ToString(),
                                                dr["CPF"].ToString(),
                                                dr["Telefone"].ToString(),
                                                dr["Email"].ToString(),
                                                dr["Login"].ToString(),
                                                dr["Senha"].ToString(),
                                                DateTime.Parse(dr["DataCadastro"].ToString()),
                                                double.Parse(dr["Saldo"].ToString()),
                                                dr["Url_Imagem"].ToString()
                                                );
                    }
                    // Adiciona o livro lido à lista
                    aListClientes.Add(aClientes);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListClientes;
        }
        public int LogarLogin(string Login, string senha)
        {
            string stmt = "Select id from Clientes where Login = @Login and Senha = @senha";
            int id = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdid = new SqlCommand(stmt, conn))
            {
                conn.Open();
                cmdid.Parameters.AddWithValue("@Login", Login);
                cmdid.Parameters.AddWithValue("@senha", senha);
                id = (int)cmdid.ExecuteScalar();
            }
            conn.Close();
            return id;
        }
        public int LogarEmail(string Email, string senha)
        {
            string stmt = "Select id from Clientes where Email = @Email and Senha = @senha";
            int id = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdid = new SqlCommand(stmt, conn))
            {
                conn.Open();
                cmdid.Parameters.AddWithValue("@Email", Email);
                cmdid.Parameters.AddWithValue("@senha", senha);
                id = (int)cmdid.ExecuteScalar();
            }
            conn.Close();
            return id;
        }
        public void UpdateDinheiro(int id, double valor)
        {
            double saldo;
            SqlConnection conn = new SqlConnection(connectionString); ;
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            saldo = this.Select1(id).ElementAt(0).Saldo;
            saldo = saldo + valor;
            SqlCommand cmd = new SqlCommand("UPDATE Clientes SET Saldo = @Saldo where id = @id", conn);
            cmd.Parameters.AddWithValue("@Saldo", saldo);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateComprar(double valor, double saldo, int id)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            valor = saldo - valor;

            SqlCommand cmd2 = new SqlCommand("update Clientes SET Saldo = @Saldo where id = @id ", conn);
            cmd2.Parameters.AddWithValue("@Saldo", valor);
            cmd2.Parameters.AddWithValue("@id", id);

            // Executa Comando
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
        public int Count()
        {
            string stmt = "SELECT COUNT(*) FROM Clientes ";
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
            string stmt = "SELECT COUNT(*) FROM Clientes WHERE Login = @login ";
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
        public int CountSenha(string l)
        {
            string stmt = "SELECT COUNT(*) FROM Clientes WHERE Senha = @senha ";
            int count = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmdCount = new SqlCommand(stmt, conn))
            {
                cmdCount.Parameters.AddWithValue("senha", l);
                conn.Open();
                count = (int)cmdCount.ExecuteScalar();
            }
            conn.Close();
            return count;
        }
        public int CountEmail(string l)
        {
            string stmt = "SELECT COUNT(*) FROM Clientes WHERE Email = @email ";
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