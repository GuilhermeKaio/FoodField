using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationFoodField
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Metodos_Gerais aMetodos = new Metodos_Gerais();
            aMetodos.VerificarUL(Convert.ToInt32(Session["idlogin"]));
        }
    }
}