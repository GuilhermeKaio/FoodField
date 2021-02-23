using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplicationFoodField
{
    public partial class WebFormPacotesC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int count;
            DAL.DALPacote aDALPacote = new DAL.DALPacote();
            Metodos_Gerais aMetodos = new Metodos_Gerais();
            DAL.DALTransacaoPacote aDALTPacote = new DAL.DALTransacaoPacote();
            count = aDALPacote.A();

            int type = Convert.ToInt32(DropDownList1.SelectedValue);

            for (int i = 0; i <= count - 1; i++)
            {
                int id = aDALPacote.SelectAll(type).ElementAt(i).id;
                if (aDALTPacote.VerificarT(id, Convert.ToInt32(Session["idlogin"])))
                {
                    Panel p1, p2, p3;
                    Image img;
                    Label l1, l2;
                    HtmlGenericControl h3, h5;
                    Button b1;

                    h3 = new HtmlGenericControl("h3");

                    h5 = new HtmlGenericControl("h5");

                    l1 = new Label();

                    l1.Text = aDALPacote.SelectAll(type).ElementAt(i).Nome;
                    l1.CssClass = "txt5";

                    l2 = new Label();
                    l2.Text = aMetodos.VerificarDouble(aDALPacote.SelectAll(type).ElementAt(i).Preco);
                    l2.CssClass = "txt6";

                    img = new Image();
                    img.ImageUrl = aDALPacote.SelectAll(type).ElementAt(i).Url_Imagem;
                    b1 = new Button();
                    b1.CssClass = "login-form-btn center-block";
                    b1.Text = "Ver Mais";
                    b1.PostBackUrl = "~/WebFormPacoteDetalhar.aspx?Pacote=" + id;

                    p2 = new Panel();
                    p2.CssClass = "thumbnail";

                    p3 = new Panel();
                    p3.CssClass = "caption text-center";

                    p1 = new Panel();
                    p1.CssClass = "col-sm-3";


                    p2.Controls.Add(img);
                    h3.Controls.Add(l1);
                    p3.Controls.Add(h3);
                    h5.Controls.Add(l2);
                    p3.Controls.Add(h5);
                    p3.Controls.Add(b1);
                    p2.Controls.Add(p3);
                    p1.Controls.Add(p2);
                    PlaceHolder1.Controls.Add(p1);
                }
                else
                {
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}