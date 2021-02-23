using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplicationFoodField
{
    public partial class WebFormRefeicoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Nivel"]) == 2 || Convert.ToInt32(Session["Nivel"]) == 3)
            {
                DAL.DALRefeicao aDALRefeicao = new DAL.DALRefeicao();

                HtmlGenericControl divflex, divmae;

                divflex = new HtmlGenericControl("div");
                divmae = new HtmlGenericControl("div");

                int count = aDALRefeicao.Count(), v = 0;
                for (int a = 0; a <= count - 1; a++)
                {
                    Image img;
                    Label l1;
                    HtmlGenericControl div;
                    LiteralControl br;
                    Button b1, b2;


                    div = new HtmlGenericControl("div");



                    div.Attributes["class"] = "ph-refeicao container-receita-listar";

                    img = new Image();

                    img.ImageUrl = aDALRefeicao.SelectAll().ElementAt(a).Url_Imagem;
                    img.CssClass = "Refeicao-Img pull-left";

                    div.Controls.Add(img);

                    l1 = new Label();

                    l1.CssClass = "txt14";
                    l1.Text = aDALRefeicao.SelectAll().ElementAt(a).Nome;

                    div.Controls.Add(l1);

                    l1 = new Label();

                    l1.CssClass = "txt13";
                    l1.Text = "Ingredientes: ";

                    br = new LiteralControl("<br/>");

                    div.Controls.Add(br);
                    div.Controls.Add(l1);

                    l1 = new Label();

                    l1.CssClass = "txt12";
                    l1.Text = aDALRefeicao.SelectAll().ElementAt(a).Ingredientes;

                    div.Controls.Add(l1);

                    l1 = new Label();

                    l1.CssClass = "txt13";
                    l1.Text = "Modo Preparo :";

                    br = new LiteralControl("<br/>");

                    div.Controls.Add(br);
                    div.Controls.Add(l1);

                    l1 = new Label();

                    l1.CssClass = "txt12";
                    l1.Text = aDALRefeicao.SelectAll().ElementAt(a).ModoPreparo;

                    div.Controls.Add(l1);
                    b1 = new Button();
                    b2 = new Button();

                    b1.Text = "Editar";
                    b2.Text = "Excluir";

                    b1.CssClass = "login10-form-btn-m-15";
                    b2.CssClass = "login10-form-btn-m-15";

                    b1.ID = aDALRefeicao.SelectAll().ElementAt(a).id.ToString();
                    b2.ID = " " + aDALRefeicao.SelectAll().ElementAt(a).id.ToString();

                    b1.Click += new EventHandler(Editar);
                    b2.Click += new EventHandler(Excluir);

                    div.Controls.Add(b1);
                    div.Controls.Add(b2);

                    if (v < 2)
                    {
                        divflex.Attributes["class"] = "d-flex6";
                        divflex.Controls.Add(div);


                        v += +1;
                    }
                    else
                    {
                        divmae.Controls.Add(divflex);
                        divflex = new HtmlGenericControl();
                        divflex.Controls.Add(div);
                        v = 1;
                    }
                    divmae.Controls.Add(divflex);
                    PlaceHolder1.Controls.Add(divmae);
                }
            }
            else
            {
                Response.Redirect("~\\WebFormPacotesListar.aspx");
            }
        }
        protected void Editar(object sender, EventArgs e)
        {
            DAL.DALRefeicao aDALRefeicao = new DAL.DALRefeicao();

            Button button = sender as Button;

            int id = Convert.ToInt32(button.ID);

            Session["EditR"] = id;
            TextBoxIngredientes.Text = aDALRefeicao.Select(id).ElementAt(0).Ingredientes;
            TextBoxModoPreparo.Text = aDALRefeicao.Select(id).ElementAt(0).ModoPreparo;
            TextBoxNome.Text = aDALRefeicao.Select(id).ElementAt(0).Nome;

            Button2.CssClass += " display";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Editar()", true);
        }

        protected void Excluir(object sender, EventArgs e)
        {
            DAL.DALRefeicao aDALRefeicao = new DAL.DALRefeicao();

            Button button = sender as Button;

            int id = Convert.ToInt32(button.ID);

            Session["ExcluirR"] = id;

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Excluir()", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["EditR"]);
            DAL.DALRefeicao aDALRefeicao = new DAL.DALRefeicao();
            Modelo.Refeicao aR = new Modelo.Refeicao(id, TextBoxIngredientes.Text, TextBoxModoPreparo.Text, "", TextBoxNome.Text);
            Metodos_Gerais MG = new Metodos_Gerais();
            string error = " ";

            if (MG.IsNull(TextBoxIngredientes.Text))
            {
                if (MG.IsNull(TextBoxModoPreparo.Text))
                {
                    if (MG.IsNull(TextBoxNome.Text))
                    {
                        aDALRefeicao.Update(aR);

                        if (FileUpload1.HasFile)
                        {
                            string filename = "Imagens\\Receitas\\Refeicao" + id + ".jpg";

                            FileUpload1.SaveAs(Request.PhysicalApplicationPath + filename);
                            aR = new Modelo.Refeicao(id, TextBoxIngredientes.Text, TextBoxModoPreparo.Text, filename, TextBoxNome.Text);

                            aDALRefeicao.UpdateImagem(aR);
                        }

                        Response.Redirect("~\\WebFormRefeicoes.aspx");
                    }
                    else
                    {
                        error = "Nome";
                        Error(error);
                    }
                }
                else
                {
                    error = "Modo de Preparo";
                    Error(error);
                }
            }
            else
            {
                error = "Ingredientes";
                Error(error);
            }



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["ExcluirR"]);
            DAL.DALRefeicao aDALRefeicao = new DAL.DALRefeicao();
            Modelo.Refeicao aR = new Modelo.Refeicao(id, "", "", "", "");
            aDALRefeicao.Delete(aR);
            Response.Redirect("~\\WebFormRefeicoes.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\WebFormRefeicoes.aspx");
        }

        protected void Novo(object sender, EventArgs e)
        {
            Button1.CssClass += " display";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Editar()", true);
        }

        protected void Insert(object sender, EventArgs e)
        {
            DAL.DALRefeicao aDALRefeicao = new DAL.DALRefeicao();
            Modelo.Refeicao aR = new Modelo.Refeicao(0, TextBoxIngredientes.Text, TextBoxModoPreparo.Text, "", TextBoxNome.Text);

            Metodos_Gerais MG = new Metodos_Gerais();
            string error = " ";

            if (MG.IsNull(TextBoxIngredientes.Text))
            {
                if (MG.IsNull(TextBoxModoPreparo.Text))
                {
                    if (MG.IsNull(TextBoxNome.Text))
                    {
                        aDALRefeicao.Insert(aR);
                        int count = aDALRefeicao.Count();
                        int id = aDALRefeicao.SelectAll().ElementAt(count - 1).id;

                        if (FileUpload1.HasFile)
                        {
                            string filename = "Imagens\\Receitas\\Refeicao" + id + ".jpg";

                            FileUpload1.SaveAs(Request.PhysicalApplicationPath + filename);
                            aR = new Modelo.Refeicao(id, TextBoxIngredientes.Text, TextBoxModoPreparo.Text, filename, TextBoxNome.Text);

                            aDALRefeicao.UpdateImagem(aR);
                        }
                        Response.Redirect("~\\WebFormRefeicoes.aspx");
                    }
                    else
                    {
                        error = "Nome";
                        Error(error);
                    }
                }
                else
                {
                    error = "Modo de Preparo";
                    Error(error);
                }
            }
            else
            {
                error = "Ingredientes";
                Error(error);
            }

            
        }
        protected void Error(string n)
        {
            Label9.Text = "O campo " + n + " se encontra vazio ou invalido";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "myFunction2()", true);
        }
    }
}