using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALHistorico
    {
        string connectionString = "";

        public DALHistorico()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Historico> Select(int id_cliente)
        {
            Modelo.Historico aHistorico;
            List<Modelo.Historico> aListHistorico = new List<Modelo.Historico>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Historico where id_cliente = @id";
            cmd.Parameters.AddWithValue("@id", id_cliente);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    try
                    {
                        aHistorico = new Modelo.Historico(
                                                int.Parse(dr["id"].ToString()),
                                                DateTime.Parse(dr["Data_Compra"].ToString()),
                                                double.Parse(dr["Preco"].ToString()),
                                                double.Parse(dr["Saldo"].ToString()),
                                                int.Parse(dr["id_Cliente"].ToString()),
                                                int.Parse(dr["id_Pacote"].ToString())
                                                );
                        aListHistorico.Add(aHistorico);
                    }
                    catch
                    {
                        aHistorico = new Modelo.Historico(
                                                int.Parse(dr["id"].ToString()),
                                                DateTime.Parse(dr["Data_Compra"].ToString()),
                                                double.Parse(dr["Preco"].ToString()),
                                                double.Parse(dr["Saldo"].ToString()),
                                                int.Parse(dr["id_Cliente"].ToString()),
                                                0
                                                );
                        aListHistorico.Add(aHistorico);
                    }
                    
                }
            }
            dr.Close();
            conn.Close();

            return aListHistorico;
        }
        public void DeletePacote(int pacote)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM Historico WHERE id_Pacote = @Pacote", conn);
            cmd.Parameters.AddWithValue("@Pacote", pacote);
            cmd.ExecuteNonQuery();

        }
        public void DeleteUsuario(int pacote)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM Historico WHERE id_Cliente = @Cliente", conn);
            cmd.Parameters.AddWithValue("@Cliente", pacote);
            cmd.ExecuteNonQuery();

        }
        public void InsertPacote(Modelo.Historico obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO Historico (Data_Compra, Preco, Saldo, id_Cliente, id_Pacote) VALUES(@Data, @Preco, @Saldo, @Cliente, @Pacote)", conn);
            cmd.Parameters.AddWithValue("@Data", obj.Data_Compra);
            cmd.Parameters.AddWithValue("@Preco", obj.Preco);
            cmd.Parameters.AddWithValue("@Saldo", obj.Saldo);
            cmd.Parameters.AddWithValue("@Cliente", obj.id_Cliente);
            cmd.Parameters.AddWithValue("@Pacote", obj.id_Pacote);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void InsertSaldo(Modelo.Historico obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO Historico (Data_Compra, Preco, Saldo, id_Cliente) VALUES(@Data, @Preco, @Saldo, @Cliente)", conn);
            cmd.Parameters.AddWithValue("@Data", obj.Data_Compra);
            cmd.Parameters.AddWithValue("@Preco", obj.Preco);
            cmd.Parameters.AddWithValue("@Saldo", obj.Saldo);
            cmd.Parameters.AddWithValue("@Cliente", obj.id_Cliente);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public int Count(int id)
        {
            string stmt = "SELECT COUNT(*) FROM Historico Where id_Cliente = @Cliente ";
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