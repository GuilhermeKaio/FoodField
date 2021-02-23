using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationFoodField
{
    public partial class WebFormClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.DALClientes DC = new DAL.DALClientes();
            Metodos_Gerais aM = new Metodos_Gerais();

            int count = DC.Count();

            if (count > 0)
            {
                Table t1;
                TableRow tr1;
                TableCell tc1;
                Button b2;
                t1 = new Table();
                tr1 = new TableRow();
                tc1 = new TableCell();
                tc1.Text = "Nome";
                tc1.CssClass = "txt16";
                tr1.Controls.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = "Telefone";
                tc1.CssClass = "txt16";
                tr1.Controls.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = "Email";
                tc1.CssClass = "txt16";
                tr1.Controls.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = "Login";
                tc1.CssClass = "txt16";
                tr1.Controls.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = "CPF";
                tc1.CssClass = "txt16";
                tr1.Controls.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = "Data de Cadastro";
                tc1.CssClass = "txt16";
                tr1.Controls.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = "Saldo";
                tc1.CssClass = "txt16";
                tr1.Controls.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = "Excluir";
                tc1.CssClass = "txt16";
                tr1.Controls.Add(tc1);
                t1.Controls.Add(tr1);
                for (int i = 0; i <= count - 1; i++)
                {
                    tr1 = new TableRow();
                    tc1 = new TableCell();

                    tc1.Text = DC.SelectAll().ElementAt(i).Nome;
                    tc1.CssClass = "txt17";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = DC.SelectAll().ElementAt(i).Telefone;
                    tc1.CssClass = "txt17";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = DC.SelectAll().ElementAt(i).Email;
                    tc1.CssClass = "txt17";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = DC.SelectAll().ElementAt(i).Login;
                    tc1.CssClass = "txt17";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = DC.SelectAll().ElementAt(i).CPF;
                    tc1.CssClass = "txt17";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = aM.VerificarDouble(DC.SelectAll().ElementAt(i).Saldo);
                    tc1.CssClass = "txt17";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = DC.SelectAll().ElementAt(i).DataCadastro.ToString();
                    tc1.CssClass = "txt17";
                    tr1.Controls.Add(tc1);
                    t1.Controls.Add(tr1);

                    b2 = new Button();

                    tc1 = new TableCell();

                    b2.Text = "Excluir";
                    b2.ID = " " + DC.SelectAll().ElementAt(i).id.ToString();

                    b2.Click += new EventHandler(Excluir);

                    b2.CssClass = "login20-form-btn";


                    tc1.Controls.Add(b2);
                    tr1.Controls.Add(tc1);
                    t1.Controls.Add(tr1);
                }
                t1.CssClass = "bug table-striped";
                PlaceHolder2.Controls.Add(t1);

                DAL.DALNutricionista DN = new DAL.DALNutricionista();

                int count2 = DN.Count();

                if (count > 0)
                {
                    Table t2;
                    TableRow tr2;
                    TableCell tc2;
                    Button b3;
                    t2 = new Table();
                    tr2 = new TableRow();
                    tc2 = new TableCell();
                    tc2.Text = "Nome";
                    tc2.CssClass = "txt16";
                    tr2.Controls.Add(tc2);
                    tc2 = new TableCell();
                    tc2.Text = "Telefone";
                    tc2.CssClass = "txt16";
                    tr2.Controls.Add(tc2);
                    tc2 = new TableCell();
                    tc2.Text = "Email";
                    tc2.CssClass = "txt16";
                    tr2.Controls.Add(tc2);
                    tc2 = new TableCell();
                    tc2.Text = "Login";
                    tc2.CssClass = "txt16";
                    tr2.Controls.Add(tc2);
                    tc2 = new TableCell();
                    tc2.Text = "Data Nascimento";
                    tc2.CssClass = "txt16";
                    tr2.Controls.Add(tc2);
                    tc2 = new TableCell();
                    tc2.Text = "Excluir";
                    tc2.CssClass = "txt16";
                    tr2.Controls.Add(tc2);
                    t2.Controls.Add(tr2);
                    for (int i = 0; i <= count2 - 1; i++)
                    {
                        tr2 = new TableRow();
                        tc2 = new TableCell();

                        tc2.Text = DN.SelectAll().ElementAt(i).Nome;
                        tc2.CssClass = "txt17";
                        tr2.Controls.Add(tc2);
                        tc2 = new TableCell();
                        tc2.Text = DN.SelectAll().ElementAt(i).Telefone;
                        tc2.CssClass = "txt17";
                        tr2.Controls.Add(tc2);
                        tc2 = new TableCell();
                        tc2.Text = DN.SelectAll().ElementAt(i).Email;
                        tc2.CssClass = "txt17";
                        tr2.Controls.Add(tc2);
                        tc2 = new TableCell();
                        tc2.Text = DC.SelectAll().ElementAt(i).Login;
                        tc2.CssClass = "txt17";
                        tr2.Controls.Add(tc2);
                        tc2 = new TableCell();
                        tc2.Text = DN.SelectAll().ElementAt(i).DataNascimento.ToString();
                        tc2.CssClass = "txt17";
                        tr2.Controls.Add(tc2);
                        t2.Controls.Add(tr2);

                        b3 = new Button();

                        tc2 = new TableCell();

                        b3.Text = "Excluir";
                        b3.ID = " " + DN.SelectAll().ElementAt(i).id.ToString();
                        b3.Click += new EventHandler(ExcluirA);

                        b3.CssClass = "login20-form-btn";


                        tc2.Controls.Add(b3);
                        tr2.Controls.Add(tc2);
                        t2.Controls.Add(tr2);
                    }
                    t2.CssClass = "bug table-striped";
                    PlaceHolder1.Controls.Add(t2);
                }
            }
        }
        protected void Excluir(object sender, EventArgs e)
        {
            Button button = sender as Button;

            int id = Convert.ToInt32(button.ID);
            Button2.CssClass += " display";

            Session["ExcluirC"] = id;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Excluir()", true);
        }
        protected void ExcluirA(object sender, EventArgs e)
        {
            Button button = sender as Button;

            int id = Convert.ToInt32(button.ID);
            Button1.CssClass += " display";
            Session["ExcluirA"] = id;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Excluir()", true);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DAL.DALClientes DC = new DAL.DALClientes();
            Modelo.Clientes MC = new Modelo.Clientes();
            int id = Convert.ToInt32(Session["ExcluirC"]);

            MC = new Modelo.Clientes(id, "", "", "", "", "", "", DateTime.Now, 0, "");

            DC.Delete(MC);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            DAL.DALNutricionista DN = new DAL.DALNutricionista();
            Modelo.Nutricionista MN;
            int id = Convert.ToInt32(Session["ExcluirC"]);

            MN = new Modelo.Nutricionista(id, "", "", "", "", "", DateTime.Now);

            DN.Delete(MN);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            Modelo.Administrador MA;
            DAL.DALClientes aDALClientes;
            DAL.DALAdministrador aDALAdministrador = new DAL.DALAdministrador();
            DAL.DALNutricionista aDALNutricionista = new DAL.DALNutricionista();
            aDALClientes = new DAL.DALClientes();
            string error = " ";
            Metodos_Gerais MG = new Metodos_Gerais();
            if (MG.IsNull(TextBoxNome.Text))
            {
                if (MG.IsNull(TextBoxTelefone.Text))
                {
                    if (MG.IsNull(TextBoxEmail.Text))
                    {
                        if (MG.IsNull(TextBoxLogin.Text))
                        {
                            if (MG.IsNull(TextBoxSenha.Text))
                            {
                                if (aDALClientes.CountLogin(TextBoxLogin.Text) <= 0 && aDALAdministrador.CountLogin(TextBoxLogin.Text) <= 0 && aDALNutricionista.CountLogin(TextBoxLogin.Text) <= 0)
                                {
                                    if (aDALClientes.CountEmail(TextBoxEmail.Text) <= 0 && aDALAdministrador.CountEmail(TextBoxEmail.Text) <= 0 && aDALNutricionista.CountEmail(TextBoxEmail.Text) <= 0)
                                    {
                                        MA = new Modelo.Administrador(0, TextBoxNome.Text, TextBoxTelefone.Text, TextBoxLogin.Text, TextBoxLogin.Text, TextBoxSenha.Text, DateTime.Now);

                                        aDALAdministrador.Insert(MA);
                                        Response.Redirect("~\\WebFormClientes.aspx");
                                    }
                                    else
                                    {
                                        error = "O Email já está cadastrado";
                                        Error(error);
                                    }
                                }
                                else
                                {
                                    error = "O Login já está cadastrado";
                                    Error(error);
                                }
                            }
                            else
                            {
                                error = "O campo senha está vazio";
                                Error(error);
                            }
                        }
                        else
                        {
                            error = "O campo login está vazio";
                            Error(error);
                        }
                    }
                    else
                    {
                        error = "O campo email está vazio";
                        Error(error);
                    }
                }
                else
                {
                    error = "O campo telefone está vazio";
                    Error(error);
                }
            }
            else
            {
                error = "O campo Nome está vazio";
                Error(error);
            }

        }

        protected void Button7_Click1(object sender, EventArgs e)
        {
            Modelo.Nutricionista MA;
            DAL.DALClientes aDALClientes;
            DAL.DALAdministrador aDALAdministrador = new DAL.DALAdministrador();
            DAL.DALNutricionista aDALNutricionista = new DAL.DALNutricionista();
            aDALClientes = new DAL.DALClientes();
            string error = " ";
            Metodos_Gerais MG = new Metodos_Gerais();
            if (MG.IsNull(TextBoxNome.Text))
            {
                if (MG.IsNull(TextBoxTelefone.Text))
                {
                    if (MG.IsNull(TextBoxEmail.Text))
                    {
                        if (MG.IsNull(TextBoxLogin.Text))
                        {
                            if (MG.IsNull(TextBoxSenha.Text))
                            {
                                if (aDALClientes.CountLogin(TextBoxLogin.Text) <= 0 && aDALAdministrador.CountLogin(TextBoxLogin.Text) <= 0 && aDALNutricionista.CountLogin(TextBoxLogin.Text) <= 0)
                                {
                                    if (aDALClientes.CountEmail(TextBoxEmail.Text) <= 0 && aDALAdministrador.CountEmail(TextBoxEmail.Text) <= 0 && aDALNutricionista.CountEmail(TextBoxEmail.Text) <= 0)
                                    {
                                        MA = new Modelo.Nutricionista(0, TextBoxNome.Text, TextBoxTelefone.Text, TextBoxLogin.Text, TextBoxLogin.Text, TextBoxSenha.Text, DateTime.Now);

                                        aDALNutricionista.Insert(MA);
                                        Response.Redirect("~\\WebFormClientes.aspx");
                                    }
                                    else
                                    {
                                        error = "O Email já está cadastrado";
                                        Error(error);
                                    }
                                }
                                else
                                {
                                    error = "O Login já está cadastrado";
                                    Error(error);
                                }
                            }
                            else
                            {
                                error = "O campo senha está vazio";
                                Error(error);
                            }
                        }
                        else
                        {
                            error = "O campo login está vazio";
                            Error(error);
                        }
                    }
                    else
                    {
                        error = "O campo email está vazio";
                        Error(error);
                    }
                }
                else
                {
                    error = "O campo telefone está vazio";
                    Error(error);
                }
            }
            else
            {
                error = "O campo Nome está vazio";
                Error(error);
            }

        }
        protected void Error(string n)
        {
            divalert.Attributes["class"] = "alert alert-danger";
            Label1.Text = n;
        }
    }
}