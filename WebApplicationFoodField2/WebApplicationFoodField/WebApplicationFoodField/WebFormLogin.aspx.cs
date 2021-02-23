using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationFoodField
{
    public partial class WebFormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["idlogin"]) > 0)
            {
                Response.Redirect("~/WebFormPacotesListar.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Login, senha;
            int idlogin = 0, nvl = 0;

            void Red()
            {
                Session["idlogin"] = idlogin;
                Session["Nivel"] = nvl;
                if (nvl == 1)
                {
                    Response.Redirect("~/WebFormPacotesListar.aspx");
                }
                if (nvl == 2)
                {
                    Response.Redirect("~/WebFormPacotesListar.aspx");
                }
                if (nvl == 3)
                {
                    Response.Redirect("~/WebFormClientes.aspx");
                }
            }



            Login = TextBoxLogin.Text;
            senha = TextBoxSenha.Text;

            DAL.DALClientes aDALClintes = new DAL.DALClientes();
            DAL.DALAdministrador aDALAdm = new DAL.DALAdministrador();
            DAL.DALNutricionista aDALNutri = new DAL.DALNutricionista();
            Metodos_Gerais AM = new Metodos_Gerais();
            string error = " ";
            if (AM.IsNull(Login))
            {
                if (AM.IsNull(senha))
                {
                    try
                    {
                        idlogin = aDALClintes.LogarLogin(Login, senha);
                        nvl = 1;
                        Red();
                    }
                    catch
                    {
                        try
                        {
                            idlogin = aDALClintes.LogarEmail(Login, senha);
                            nvl = 1;
                            Red();
                        }
                        catch
                        {
                            try
                            {
                                idlogin = aDALNutri.LogarLogin(Login, senha);
                                nvl = 2;
                                Red();
                            }
                            catch
                            {
                                try
                                {
                                    idlogin = aDALNutri.LogarEmail(Login, senha);
                                    nvl = 2;
                                    Red();
                                }
                                catch
                                {
                                    try
                                    {
                                        idlogin = aDALAdm.LogarLogin(Login, senha);
                                        nvl = 3;
                                        Red();
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            idlogin = aDALAdm.LogarEmail(Login, senha);
                                            nvl = 3;
                                            Red();
                                        }
                                        catch
                                        {
                                            divalert.Attributes["class"] = "alert alert-danger";
                                            Label1.Text = "O Login/Senha não estão cadastrados";
                                        }
                                    }
                                }


                            }
                        }

                    }
                }
                else
                {
                    error = "Senha";
                    Error(error);
                }
            }
            else
            {
                error = "Login";
                Error(error);
            }

            
        }

        protected void Error(string n)
        {
            divalert.Attributes["class"] = "alert alert-danger";
            Label1.Text = "O campo " + n + " se encontra vazio";
        }
    }
}