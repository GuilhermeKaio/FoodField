using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationFoodField
{
    public partial class WebFormCadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Modelo.Clientes aClientes;
            DAL.DALClientes aDALClientes;
            DAL.DALAdministrador aDALAdministrador = new DAL.DALAdministrador();
            DAL.DALNutricionista aDALNutricionista = new DAL.DALNutricionista();
            aDALClientes = new DAL.DALClientes();
            string error = " ";
            Metodos_Gerais MG = new Metodos_Gerais();
            if (TextBoxSenha.Text == TextBoxSenhaV.Text)
            {
                if (MG.VerifyCpf(TextBoxCPF.Text))
                {
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
                                                string filename;

                                                filename = "Imagens\\user.jpg";

                                                // Instancia um Objeto de Livro com as informações fornecidas
                                                aClientes = new Modelo.Clientes(
                                                    0, TextBoxNome.Text, TextBoxCPF.Text, TextBoxTelefone.Text, TextBoxEmail.Text, TextBoxLogin.Text, TextBoxSenha.Text, DateTime.Now, 0, filename);
                                                aDALClientes.Insert(aClientes);
                                                Response.Redirect("~\\WebForm2.aspx");
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
                else
                {
                    error = "O campo CPF não é valido";
                    Error(error);
                }

            }
            else
            {
                error = "As senhas não coincidem";
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