using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationFoodField.DAL
{
    public class DALComentario
    {
        string connectionString = "";

        public DALComentario()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                      ["PubsConnectionString"].ConnectionString;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Img_Comentario> SelectId_Pacote(int id)
        {
            Modelo.Img_Comentario aComen;
            List<Modelo.Img_Comentario> aListComen = new List<Modelo.Img_Comentario>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Comentario where pacote_id = @id order by data", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            DAL.DALClientes aC = new DALClientes();
            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    aComen = new Modelo.Img_Comentario(
                        aC.Select1(int.Parse(dr["cliente_id"].ToString())).ElementAt(0).Url_Imagem,
                        dr["comentario"].ToString(),
                        Convert.ToDateTime(dr["data"].ToString())
                        );
                    aListComen.Add(aComen);
                }
            }
            dr.Close();
            conn.Close();
            return aListComen;
        }

        public void Insert(Modelo.Comentario mC)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO Comentario (comentario, pacote_id, cliente_id, data) VALUES(@comentario, @Pacote, @Cliente, @Data)", conn);
            cmd.Parameters.AddWithValue("@comentario", mC.comentario);
            cmd.Parameters.AddWithValue("@Pacote", mC.pacote_id);
            cmd.Parameters.AddWithValue("@Cliente", mC.cliente_id);
            cmd.Parameters.AddWithValue("@Data", mC.data);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}