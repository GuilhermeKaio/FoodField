using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplicationFoodField
{
    public partial class WebFormUsuariosEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Nivel"]) == 1)
            {
                int id = Convert.ToInt32(Session["idlogin"]);
                if (!IsPostBack)
                {

                    DAL.DALClientes aDALClientes = new DAL.DALClientes();

                    Image1.ImageUrl = aDALClientes.Select1(id).ElementAt(0).Url_Imagem;
                    LabelNome.Text = aDALClientes.Select1(id).ElementAt(0).Nome;
                    TextBoxNome.Text = aDALClientes.Select1(id).ElementAt(0).Nome;
                    LabelCPF.Text = aDALClientes.Select1(id).ElementAt(0).CPF;
                    TextBoxCPF.Text = aDALClientes.Select1(id).ElementAt(0).CPF;
                    LabelTelefone.Text = aDALClientes.Select1(id).ElementAt(0).Telefone;
                    TextBoxTelefone.Text = aDALClientes.Select1(id).ElementAt(0).Telefone;
                    LabelEmail.Text = aDALClientes.Select1(id).ElementAt(0).Email;
                    TextBoxEmail.Text = aDALClientes.Select1(id).ElementAt(0).Email;
                    rua.Text = "";
                    numero.Text = "";
                    cep.Text = "";
                    bairro.Text = "";
                    cidade.Text = "";
                    uf.Text = "AC";
                }
                if (Convert.ToInt32(Session["Edit"]) == 1)
                {
                    CPF.Attributes["class"] = "display";
                    CPFEdit.Attributes["class"] = "";
                    Tel.Attributes["class"] = "display";
                    TelEdit.Attributes["class"] = "";
                    Email.Attributes["class"] = "display";
                    EmailEdit.Attributes["class"] = "";
                    Nome.Attributes["class"] = "display";
                    NomeEdit.Attributes["class"] = "";
                    btn2.Attributes["class"] = "";
                    btn1.Attributes["class"] = "display";
                    EmailL.Attributes["class"] = "";
                }

                DAL.DALHistorico aDALHistorico = new DAL.DALHistorico();
                DAL.DALPacote aDALPacote = new DAL.DALPacote();
                DAL.DALEndereco aDALEndereco = new DAL.DALEndereco();
                Metodos_Gerais Metodos = new Metodos_Gerais();
                int count = aDALHistorico.Count(id);
                int countE = aDALEndereco.Count(id);

                if (countE > 0)
                {
                    Table t1;
                    TableRow tr1;
                    TableCell tc1;
                    Button b1, b2;
                    t1 = new Table();
                    tr1 = new TableRow();
                    tc1 = new TableCell();
                    countE = countE - 1;
                    tc1.Text = "Logradouro";
                    tc1.CssClass = "txt16";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = "Numero";
                    tc1.CssClass = "txt16";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = "CEP";
                    tc1.CssClass = "txt16";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = "Bairro";
                    tc1.CssClass = "txt16";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = "Cidade";
                    tc1.CssClass = "txt16";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = "Unidade da Federação";
                    tc1.CssClass = "txt16";
                    tr1.Controls.Add(tc1);
                    tc1 = new TableCell();
                    tc1.Text = "Editar";
                    tc1.CssClass = "txt16";
                    tr1.Controls.Add(tc1); tc1 = new TableCell();
                    tc1.Text = "Excluir";
                    tc1.CssClass = "txt16";
                    tr1.Controls.Add(tc1);
                    t1.Controls.Add(tr1);
                    for (int i = countE; i >= 0; i--)
                    {
                        tr1 = new TableRow();
                        tc1 = new TableCell();

                        tc1.Text = aDALEndereco.Select(id).ElementAt(i).Rua;
                        tc1.CssClass = "txt17";
                        tr1.Controls.Add(tc1);
                        tc1 = new TableCell();
                        tc1.Text = aDALEndereco.Select(id).ElementAt(i).Numero;
                        tc1.CssClass = "txt17";
                        tr1.Controls.Add(tc1);
                        tc1 = new TableCell();
                        tc1.Text = aDALEndereco.Select(id).ElementAt(i).CEP;
                        tc1.CssClass = "txt17";
                        tr1.Controls.Add(tc1);
                        tc1 = new TableCell();
                        tc1.Text = aDALEndereco.Select(id).ElementAt(i).Bairro;
                        tc1.CssClass = "txt17";
                        tr1.Controls.Add(tc1);
                        tc1 = new TableCell();
                        tc1.Text = aDALEndereco.Select(id).ElementAt(i).Cidade;
                        tc1.CssClass = "txt17";
                        tr1.Controls.Add(tc1);
                        tc1 = new TableCell();
                        tc1.Text = aDALEndereco.Select(id).ElementAt(i).UF;
                        tc1.CssClass = "txt17";
                        tr1.Controls.Add(tc1);
                        t1.Controls.Add(tr1);

                        b1 = new Button();
                        b2 = new Button();

                        tc1 = new TableCell();

                        b1.Text = "Editar";
                        b2.Text = "Excluir";

                        b1.ID = aDALEndereco.Select(id).ElementAt(i).id.ToString();
                        b2.ID = " " + aDALEndereco.Select(id).ElementAt(i).id.ToString();

                        b1.Click += new EventHandler(EditarE);
                        b2.Click += new EventHandler(ExcluirE);

                        b1.CssClass = "login20-form-btn";
                        b2.CssClass = "login20-form-btn";


                        tc1.Controls.Add(b1);
                        tr1.Controls.Add(tc1);
                        tc1 = new TableCell();
                        tc1.Controls.Add(b2);
                        tr1.Controls.Add(tc1);
                    }
                    t1.CssClass = "tablel table table-striped";
                    PlaceHolder2.Controls.Add(t1);
                }

                if (count > 0)
                {
                    Table t;
                    TableRow tr;
                    TableCell tc;
                    t = new Table();
                    tr = new TableRow();
                    tc = new TableCell();
                    count = count - 1;
                    tc.Text = "Data da Compra";
                    tc.CssClass = "txt16";
                    tr.Controls.Add(tc);
                    tc = new TableCell();
                    tc.Text = "Nome do Pacote";
                    tc.CssClass = "txt16";
                    tr.Controls.Add(tc);
                    tc = new TableCell();
                    tc.Text = "Saldo pós-compra";
                    tc.CssClass = "txt16";
                    tr.Controls.Add(tc);
                    tc = new TableCell();
                    tc.Text = "Preço";
                    tc.CssClass = "txt16";
                    tr.Controls.Add(tc);
                    t.Controls.Add(tr);
                    for (int i = count; i >= 0; i--)
                    {
                        tr = new TableRow();
                        tc = new TableCell();
                        int pacote = aDALHistorico.Select(id).ElementAt(i).id_Pacote;

                        tc.Text = aDALHistorico.Select(id).ElementAt(i).Data_Compra.ToString();
                        tc.CssClass = "txt17";
                        tr.Controls.Add(tc);
                        tc = new TableCell();
                        try
                        {
                            tc.Text = aDALPacote.Select(pacote).ElementAt(0).Nome;
                            tc.CssClass = "txt17";
                            tr.Controls.Add(tc);
                            tc = new TableCell();
                            tc.Text = Metodos.VerificarDouble(aDALHistorico.Select(id).ElementAt(i).Saldo);
                            tc.CssClass = "txt17";
                            tr.Controls.Add(tc);
                            tc = new TableCell();
                            tc.Text = "- " + Metodos.VerificarDouble(aDALHistorico.Select(id).ElementAt(i).Preco);
                            tc.CssClass = "txt19";
                            tr.Controls.Add(tc);
                        }
                        catch
                        {
                            tc.Text = " - ";
                            tc.CssClass = "txt17";
                            tr.Controls.Add(tc);
                            tc = new TableCell();
                            tc.Text = Metodos.VerificarDouble(aDALHistorico.Select(id).ElementAt(i).Saldo);
                            tc.CssClass = "txt17";
                            tr.Controls.Add(tc);
                            tc = new TableCell();
                            tc.Text = "+ " + Metodos.VerificarDouble(aDALHistorico.Select(id).ElementAt(i).Preco);
                            tc.CssClass = "txt18";
                            tr.Controls.Add(tc);
                        }


                        t.Controls.Add(tr);
                    }
                    t.CssClass = "tablel table table-striped";
                    PlaceHolder1.Controls.Add(t);
                }

            }

            if (Convert.ToInt32(Session["Nivel"]) == 2)
            {
                int id = Convert.ToInt32(Session["idlogin"]);
                DAL.DALNutricionista aDALNutricionista = new DAL.DALNutricionista();

                LabelNome.Text = aDALNutricionista.Select(id).ElementAt(0).Nome;


                /*Table tb;
                TableRow tr;
                TableCell tc1, tc2;
                Image img;
                Label Nome, RG, Telefone, Email, a;
                HtmlGenericControl h1, h3, h4;

                img = new Image();
                img.ImageUrl = "~/Imagens/user.jpg";
                img.CssClass = "img-responsive img-circle";

                Nome = new Label();
                Nome.Text = aDALNutricionista.Select(id).ElementAt(0).Nome;

                //RG = new Label();
                //RG.Text = aDALNutricionista.Select(id).ElementAt(0).RG;

                Telefone = new Label();
                Telefone.Text = aDALNutricionista.Select(id).ElementAt(0).Telefone;

                Email = new Label();
                Email.Text = aDALNutricionista.Select(id).ElementAt(0).Email;

                h1 = new HtmlGenericControl("h1");

                tb = new Table();

                tr = new TableRow();

                tc1 = new TableCell();

                a = new Label();
                a.Text = "Nome :";
                a.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);

                tc2 = new TableCell();
                tc2.RowSpan = 7;

                tc2.Controls.Add(img);
                h1.Controls.Add(Nome);
                tc1.Controls.Add(h1);
                tr.Controls.Add(tc2);
                tr.Controls.Add(tc1);
                tb.Controls.Add(tr);

                tr = new TableRow();

                tc1 = new TableCell();

                h3 = new HtmlGenericControl("h3");

                a = new Label();
                a.Text = "RG :";
                a.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);

                h3.Controls.Add(a);
                tc1.Controls.Add(h3);
                tr.Controls.Add(tc1);
                tb.Controls.Add(tr);

                //tr = new TableRow();

                //tc1 = new TableCell();

                //h4 = new HtmlGenericControl("h4");

                //h4.Controls.Add(RG);
                //tc1.Controls.Add(h4);
                //tr.Controls.Add(tc1);
                //tb.Controls.Add(tr);

                tr = new TableRow();

                tc1 = new TableCell();

                h3 = new HtmlGenericControl("h3");

                a = new Label();
                a.Text = "Telefone :";
                a.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);

                h3.Controls.Add(a);
                tc1.Controls.Add(h3);
                tr.Controls.Add(tc1);
                tb.Controls.Add(tr);

                tr = new TableRow();

                tc1 = new TableCell();

                h4 = new HtmlGenericControl("h4");


                h4.Controls.Add(Telefone);
                tc1.Controls.Add(h4);
                tr.Controls.Add(tc1);
                tb.Controls.Add(tr);

                tr = new TableRow();

                tc1 = new TableCell();

                h3 = new HtmlGenericControl("h3");

                a = new Label();
                a.Text = "Email :";
                a.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);

                h3.Controls.Add(a);
                tc1.Controls.Add(h3);
                tr.Controls.Add(tc1);
                tb.Controls.Add(tr);

                tr = new TableRow();

                tc1 = new TableCell();

                h4 = new HtmlGenericControl("h4");

                h4.Controls.Add(Email);
                tc1.Controls.Add(h4);
                tr.Controls.Add(tc1);
                tb.Controls.Add(tr);

                PlaceHolder1.Controls.Add(tb);*/
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Edit"] = 1;
            Response.Redirect(Request.Url.ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Modelo.Clientes aClientes;
            DAL.DALClientes aDALClientes;
            Metodos_Gerais AM = new Metodos_Gerais();
            aClientes = new Modelo.Clientes(
                Convert.ToInt32(Session["idlogin"]), TextBoxNome.Text, TextBoxCPF.Text, TextBoxTelefone.Text, TextBoxEmail.Text, "", "", DateTime.Now, 0, "");
            aDALClientes = new DAL.DALClientes();
            string error = " ";
            if (AM.IsNull(TextBoxNome.Text))
            {
                if (AM.VerifyCpf(TextBoxCPF.Text))
                {
                    if (AM.IsNull(TextBoxTelefone.Text))
                    {
                        if (AM.IsNull(TextBoxEmail.Text))
                        {
                            aDALClientes.Update(aClientes);
                            Session["Edit"] = 0;
                            Response.Redirect(Request.Url.ToString());
                        }
                        else
                        {
                            error = "Email";
                            Error(error);
                        }
                    }
                    else
                    {
                        error = "Telefone";
                        Error(error);
                    }
                }
                else
                {
                    error = "CPF";
                    Error(error);
                }
            }
            else
            {
                error = "Nome";
                Error(error);
            }
            

            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            Modelo.Clientes aClientes;
            DAL.DALClientes aDALClientes;
            string filename, s;
            int id = Convert.ToInt32(Session["idlogin"]);

            filename = "Imagens\\Usuarios\\user" + id.ToString() + ".jpg";

            FileUpload1.SaveAs(Request.PhysicalApplicationPath + filename);

            aClientes = new Modelo.Clientes(
                id, "", "", "", "", "", "", DateTime.Now, 0, filename);

            aDALClientes = new DAL.DALClientes();
            aDALClientes.UpdateImagem(aClientes);
            Response.Redirect(Request.Url.ToString());

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Metodos_Gerais MG = new Metodos_Gerais();
            string error = " ";
            int id = Convert.ToInt32(Session["idlogin"]);
            DAL.DALEndereco aDALEndereco = new DAL.DALEndereco();
            Modelo.Endereco aE = new Modelo.Endereco(0, rua.Text, numero.Text, cep.Text, bairro.Text, cidade.Text, uf.Text, id);

            if (MG.IsNull(rua.Text))
            {
                if (MG.IsNull(numero.Text))
                {
                    if (MG.IsNull(cep.Text))
                    {
                        if (MG.IsNull(bairro.Text))
                        {
                            if (MG.IsNull(cidade.Text))
                            {
                                aDALEndereco.Insert(aE);
                                Response.Redirect(Request.Url.ToString());
                            }
                            else
                            {
                                error = "Cidade";
                                Error(error);
                            }
                        }
                        else
                        {
                            error = "Bairro";
                            Error(error);
                        }
                    }
                    else
                    {
                        error = "CEP";
                        Error(error);
                    }
                }
                else
                {
                    error = "Numero";
                    Error(error);
                }
            }
            else
            {
                error = "Rua";
                Error(error);
            }
        }

        protected void EditarE(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string error = " ";
            if (button.ID == "Button5")
            {
                int id = Convert.ToInt32(Session["idlogin"]);
                Metodos_Gerais MG = new Metodos_Gerais();
                DAL.DALEndereco aDALEndereco = new DAL.DALEndereco();
                Modelo.Endereco aE = new Modelo.Endereco(Convert.ToInt32(Session["EditE"]), rua.Text, numero.Text, cep.Text, bairro.Text, cidade.Text, uf.Text, id);
                if (MG.IsNull(rua.Text))
                {
                    if (MG.IsNull(numero.Text))
                    {
                        if (MG.IsNull(cep.Text))
                        {
                            if (MG.IsNull(bairro.Text))
                            {
                                if (MG.IsNull(cidade.Text))
                                {
                                    aDALEndereco.Update(aE);
                                    Response.Redirect(Request.Url.ToString());
                                }
                                else
                                {
                                    error = "Cidade";
                                    Error(error);
                                }
                            }
                            else
                            {
                                error = "Bairro";
                                Error(error);
                            }
                        }
                        else
                        {
                            error = "CEP";
                            Error(error);
                        }
                    }
                    else
                    {
                        error = "Numero";
                        Error(error);
                    }
                }
                else
                {
                    error = "Rua";
                    Error(error);
                }
            }
            else
            {
                if (button.ID == "Button6")
                {
                    Response.Redirect(Request.Url.ToString());
                }
                else
                {
                    DAL.DALEndereco aDALEndereco = new DAL.DALEndereco();
                    int id = Convert.ToInt32(button.ID);
                    Session["EditE"] = id;
                    rua.Text = aDALEndereco.SelectE(id).ElementAt(0).Rua;
                    numero.Text = aDALEndereco.SelectE(id).ElementAt(0).Numero;
                    cep.Text = aDALEndereco.SelectE(id).ElementAt(0).CEP;
                    bairro.Text = aDALEndereco.SelectE(id).ElementAt(0).Bairro;
                    cidade.Text = aDALEndereco.SelectE(id).ElementAt(0).Cidade;
                    uf.Text = aDALEndereco.SelectE(id).ElementAt(0).UF;
                    Button4.CssClass = "login25-form-btn display";
                    Button5.CssClass = "login25-form-btn";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "myFunction()", true);
                }

            }


        }
        protected void ExcluirE(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button.ID == "Button7")
            {
                DAL.DALEndereco aDALEndereco = new DAL.DALEndereco();
                Modelo.Endereco aE = new Modelo.Endereco(Convert.ToInt32(Session["EditE"]), "", "", "", "", "", "", 0);
                aDALEndereco.Delete(aE);
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                if (button.ID == "Button8")
                {
                    Response.Redirect(Request.Url.ToString());
                }
                else
                {
                    int id = Convert.ToInt32(button.ID);
                    Label8.Text = "Você tem certeza em excluir esse Endereço?";
                    Session["EditE"] = id;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "myFunction1()", true);
                }
            }
        }

        protected void Error(string n)
        {
            Label9.Text = "O campo " + n + " se encontra vazio ou invalido";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "myFunction2()", true);
        }
    }
}