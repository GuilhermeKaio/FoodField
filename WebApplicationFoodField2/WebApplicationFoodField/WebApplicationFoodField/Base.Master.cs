using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationFoodField
{
    public partial class Base : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(Session["idlogin"]);

            Metodos_Gerais aMetodos = new Metodos_Gerais();
            aMetodos.VerficarL(i);
            DAL.DALClientes aDALClientes = new DAL.DALClientes();
            

            //Button1.Text = Session["Nivel"].ToString();
            //Button2.Text = Session["idlogin"].ToString();
            if (Convert.ToInt32(Session["Nivel"]) == 3)
            {
                Button2.Text = "Funcionarios";
                Button3.Text = "Pacotes";
                Label1.Attributes["style"] = "display : none;";
                ImageButton1.CssClass = "display";
            }
            if (Convert.ToInt32(Session["Nivel"]) == 2)
            {
                Button3.CssClass = "display";
                Label1.Attributes["style"] = "display : none;";
                ImageButton1.CssClass = "display";
            }
            if (Convert.ToInt32(Session["Nivel"]) == 1)
            {

                Label1.Text = aMetodos.VerificarDouble(aDALClientes.Select1(i).ElementAt(0).Saldo);
                Label1.CssClass += " txt15";
                ImageButton1.ImageUrl = aDALClientes.Select1(i).ElementAt(0).Url_Imagem;


                //Image1.ImageUrl = aDALClientes.Select1(i).ElementAt(0).Url_Imagem;
                //Image1.CssClass = "img-responsive img-circle";
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["idlogin"] = 0;
            Response.Redirect("~/WebFormLogin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Nivel"]) == 3)
            {
                Response.Redirect("~/WebFormClientes.aspx");
            }
            Response.Redirect("~/WebFormPacotesListar.aspx");

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/WebFormUsuariosEdit.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Nivel"]) == 2)
            {
                Response.Redirect("~/WebFormPacotesListar.aspx");
            }
            if (Convert.ToInt32(Session["Nivel"]) == 3)
            {
                Response.Redirect("~/WebFormPacotesListar.aspx");
            }
            Response.Redirect("~/WebFormPacotesC.aspx");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DAL.DALClientes aDALClientes = new DAL.DALClientes();
            DAL.DALHistorico aDALHistorico = new DAL.DALHistorico();

            int id = Convert.ToInt32(Session["idlogin"]);
            double preco = Convert.ToDouble(TextBox1.Text);

            aDALClientes.UpdateDinheiro(id, preco);
            double saldo = aDALClientes.Select1(id).ElementAt(0).Saldo;

            Modelo.Historico aH = new Modelo.Historico(0 , DateTime.Now, preco, saldo, id, 0);

            aDALHistorico.InsertSaldo(aH);

            Response.Redirect(Request.Url.ToString());

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}