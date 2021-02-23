using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplicationFoodField
{
    public partial class WebFormPacoteDetalhar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.DALTransacaoPacote aDALTPacote = new DAL.DALTransacaoPacote();
            DAL.DALAvaliacao aDALAvaliacao = new DAL.DALAvaliacao();
            DAL.DALPacote_Refeicao aDALPacote_Refeicao = new DAL.DALPacote_Refeicao();
            DAL.DALRefeicao aDALRefeicao = new DAL.DALRefeicao();

            if (Convert.ToInt32(Session["Nivel"]) == 2 || Convert.ToInt32(Session["Nivel"]) == 3)
            {
                div2.Attributes["style"] = "display : none";
                divControl.Attributes["class"] = "d-flex";
                divComprar.Attributes["class"] = "display";
                section.Attributes["class"] = "margintop-15";
            }

            if (Convert.ToInt32(Request.QueryString["Pacote"]) > 0)
            {
                Session["idpacote"] = Convert.ToInt32(Request.QueryString["Pacote"]);

                int i, id, pacote, count, countall;
                DAL.DALPacote aDALPacote = new DAL.DALPacote();
                Metodos_Gerais aMetodos = new Metodos_Gerais();
                i = Convert.ToInt32(Session["idpacote"]);
                id = Convert.ToInt32(Session["idlogin"]);
                pacote = Convert.ToInt32(Session["idpacote"]);
                count = aDALPacote_Refeicao.CountPacote(pacote);
                countall = aDALRefeicao.Count();


                LabelNome.Text = aDALPacote.Select(i).ElementAt(0).Nome;
                LabelPreco.Text = aMetodos.VerificarDouble(aDALPacote.Select(i).ElementAt(0).Preco);

                if (!IsPostBack)
                {
                    Rating1.CurrentRating = aDALAvaliacao.Media(pacote);
                    Rating1.ReadOnly = true;
                }

                if (!IsPostBack)
                {
                    Nome.Text = aDALPacote.Select(i).ElementAt(0).Nome;
                    Preco.Text = aDALPacote.Select(i).ElementAt(0).Preco.ToString();
                    TextBox1.Text = aDALPacote.Select(i).ElementAt(0).Descricao;
                    TextBox1.Enabled = false;
                }

                ImagePacote.ImageUrl = aDALPacote.Select(i).ElementAt(0).Url_Imagem;

                if (aDALTPacote.VerificarT(pacote, id))
                {
                    if (aDALAvaliacao.SelectNota(pacote, id) == 0)
                    {
                        if (!IsPostBack)
                        {
                            Rating1.ReadOnly = false;
                            Rating1.CurrentRating = 3;
                            Button2.CssClass = "login15-form-btn-c";
                        }
                    }
                    else
                    {
                        Rating1.ReadOnly = true;
                        Rating1.CurrentRating = aDALAvaliacao.SelectNota(pacote, id);
                        Button2.CssClass = "display";

                    }

                    divComprar.Attributes["class"] = "display";
                    divCancel.Attributes["class"] = "";
                    Label8.Text = "Você tem certeza em cancelar esse pacote?";

                }

                if (countall > 0)
                {
                    for (int b = 0; b <= countall - 1; b++)
                    {
                        if (aDALPacote_Refeicao.CountPC(pacote, aDALRefeicao.SelectAll().ElementAt(b).id)){
                            ListItem List = new ListItem();

                            List.Text = aDALRefeicao.SelectAll().ElementAt(b).Nome;
                            List.Value = aDALRefeicao.SelectAll().ElementAt(b).id.ToString();

                            DropDownList1.Items.Add(List);
                        }
                           
                    }
                        
                }
                else
                {
                    section.Attributes["class"] = "margintop-15 display";
                }

                if (count > 0)
                {
                    HtmlGenericControl divm;

                    divm = new HtmlGenericControl("div");
                    for (int a = 0; a <= count - 1; a++)
                    {
                        Image img;
                        Label l1;
                        HtmlGenericControl div;
                        LiteralControl br;
                        int refeicao;

                        refeicao = aDALPacote_Refeicao.Select(pacote).ElementAt(a).id_Refeicao;

                        div = new HtmlGenericControl("div");



                        div.Attributes["class"] = "ph-refeicao container-receita";

                        img = new Image();

                        img.ImageUrl = aDALRefeicao.Select(refeicao).ElementAt(0).Url_Imagem;
                        img.CssClass = "Refeicao-Img pull-left";

                        div.Controls.Add(img);

                        l1 = new Label();

                        l1.CssClass = "txt14";
                        l1.Text = aDALRefeicao.Select(refeicao).ElementAt(0).Nome;

                        div.Controls.Add(l1);

                        l1 = new Label();

                        l1.CssClass = "txt13";
                        l1.Text = "Ingredientes: ";

                        br = new LiteralControl("<br/>");

                        div.Controls.Add(br);
                        div.Controls.Add(l1);

                        l1 = new Label();

                        l1.CssClass = "txt12";
                        l1.Text = aDALRefeicao.Select(refeicao).ElementAt(0).Ingredientes;

                        div.Controls.Add(l1);

                        l1 = new Label();

                        l1.CssClass = "txt13";
                        l1.Text = "Modo Preparo :";

                        br = new LiteralControl("<br/>");

                        div.Controls.Add(br);
                        div.Controls.Add(l1);

                        l1 = new Label();

                        l1.CssClass = "txt12";
                        l1.Text = aDALRefeicao.Select(refeicao).ElementAt(0).ModoPreparo;

                        div.Controls.Add(l1);
                        divm.Controls.Add(div);



                    }
                    PlaceHolder1.Controls.Add(divm);
                }
            }
            if (Convert.ToInt32(Request.QueryString["Edit"]) == 1)
            {
                ImagePacote.CssClass += " display";
                divName.Attributes["class"] = "Name";
                divPreco.Attributes["class"] = "Preco";
                LabelPreco.CssClass += " display";
                ImgInput.Attributes["class"] = "Pacote-Img-div ";
                LabelNome.CssClass += " display";
                CancelEdit.Attributes["class"] = "";
                Edit.Attributes["class"] = "";
                divExcluir.Attributes["class"] = "display";
                Button1.CssClass = " display";


                TextBox1.Enabled = true;
            }


        }

        protected void Refresh(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            DAL.DALTransacaoPacote aDALTPacote;
            Modelo.TransacaoPacote aTP;
            DAL.DALClientes aDALClientes = new DAL.DALClientes();
            DAL.DALPacote aDALPacote = new DAL.DALPacote();
            DAL.DALHistorico aDALHistorico = new DAL.DALHistorico();
            Modelo.Historico aH;
            int i, u;
            i = Convert.ToInt32(Session["idpacote"]);
            u = Convert.ToInt32(Session["idlogin"]);
            string error = " ";

            aDALTPacote = new DAL.DALTransacaoPacote();

            if (aDALTPacote.VerificarT(i, u))
            {
                aDALTPacote.Delete(i, u);
                Response.Redirect("~\\WebFormPacotesC.aspx");
            }
            else
            {
                double preco = aDALPacote.Select(i).ElementAt(0).Preco;
                aTP = new Modelo.TransacaoPacote(0, i, u);
                if(aDALPacote.Select(i).ElementAt(0).Preco < aDALClientes.Select1(u).ElementAt(0).Saldo)
                {
                    aDALTPacote.Insert(aTP);
                    aDALClientes.UpdateComprar(aDALPacote.Select(i).ElementAt(0).Preco, aDALClientes.Select1(u).ElementAt(0).Saldo, u);

                    aH = new Modelo.Historico(0, DateTime.Now, aDALPacote.Select(i).ElementAt(0).Preco, aDALClientes.Select1(u).ElementAt(0).Saldo, u, i);
                    aDALHistorico.InsertPacote(aH);


                    Response.Redirect("~\\WebFormPacotesListar.aspx");
                }
                else
                {
                    error = "Saldo insuficiente para realizar a transação";
                    Error(error);
                }
                
            }

        }


        protected void Button2_Click1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["idlogin"]);
            int pacote = Convert.ToInt32(Session["idpacote"]);

            DAL.DALAvaliacao aDALAvaliacao = new DAL.DALAvaliacao();
            Modelo.Avaliacao aAvalaicao = new Modelo.Avaliacao(0, Rating1.CurrentRating, pacote, id);


            aDALAvaliacao.Insert(aAvalaicao);
            Response.Redirect(Request.RawUrl);
        }

        protected void Excluir(object sender, EventArgs e)
        {
            int pacote = Convert.ToInt32(Session["idpacote"]);

            DAL.DALPacote aDALPacote = new DAL.DALPacote();
            Modelo.Pacote aP = new Modelo.Pacote(pacote, "", 0, "", "");

            aDALPacote.Delete(aP);
            Response.Redirect("~\\WebFormPacotesListar.aspx");
        }

        protected void Editar(object sender, EventArgs e)
        {
            if(Convert.ToInt32(Session["idpacote"]) > 0)
            {
                int pacote = Convert.ToInt32(Session["idpacote"]);

                DAL.DALPacote aDALPacote = new DAL.DALPacote();
                Metodos_Gerais MG = new Metodos_Gerais();
                string filename, error = " ";

                if (MG.IsNull(Nome.Text))
                {
                    if (MG.IsNull(Preco.Text))
                    {
                        if (MG.IsNull(TextBox1.Text))
                        {
                            if (FileUpload1.HasFile)
                            {
                                filename = "Imagens\\Pacote\\pacote" + pacote + ".jpg";

                                FileUpload1.SaveAs(Request.PhysicalApplicationPath + filename);
                            }
                            else
                            {
                                filename = "Imagens\\Pacote\\Background_default.jpg";
                            }
                            Modelo.Pacote aP = new Modelo.Pacote(pacote, Nome.Text, Convert.ToDouble(Preco.Text), TextBox1.Text, filename);
                            aDALPacote.Update(aP);
                            aDALPacote.UpdateImagem(aP);
                            Response.Redirect("~\\WebFormPacotesListar.aspx");
                        }
                        else
                        {
                            error = "Campo descrição vazio";
                            Error(error);
                        }
                    }
                    else
                    {
                        error = "Campo Preço vazio";
                        Error(error);
                    }
                }
                else
                {
                    error = "Campo Nome vazio";
                    Error(error);
                }

                
            }
            else
            {
                DAL.DALPacote aDALPacote = new DAL.DALPacote();
                Metodos_Gerais MG = new Metodos_Gerais();
                string filename, error = " ";


                if (MG.IsNull(Nome.Text))
                {
                    if (MG.IsNull(Preco.Text))
                    {
                        if (MG.IsNull(TextBox1.Text))
                        {
                            Modelo.Pacote aP = new Modelo.Pacote(0, Nome.Text, Convert.ToDouble(Preco.Text), TextBox1.Text, "");
                            aDALPacote.Insert(aP);

                            int count = aDALPacote.A();

                            int pacote = aDALPacote.SelectAll(5).ElementAt(count - 1).id;

                            if (FileUpload1.HasFile)
                            {
                                filename = "Imagens\\Pacote\\pacote" + pacote + ".jpg";

                                FileUpload1.SaveAs(Request.PhysicalApplicationPath + filename);
                            }
                            else
                            {
                                filename = "Imagens\\Pacote\\Background_default.jpg";
                            }
                            aP = new Modelo.Pacote(pacote, Nome.Text, Convert.ToDouble(Preco.Text), TextBox1.Text, filename);

                            aDALPacote.UpdateImagem(aP);
                            Response.Redirect("~\\WebFormPacotesListar.aspx");
                        }
                        else
                        {
                            error = "Campo descrição vazio";
                            Error(error);
                        }
                    }
                    else
                    {
                        error = "Campo Preço vazio";
                        Error(error);
                    }
                }
                else
                {
                    error = "Campo Nome vazio";
                    Error(error);
                }

                
            }
            
        }

        protected void Voltar(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["idpacote"]) > 0)
            {
                int i = Convert.ToInt32(Session["idpacote"]);
                Response.Redirect("~\\WebFormPacoteDetalhar.aspx?Pacote=" + i);
            }
            else
            {
                Response.Redirect("~\\WebFormPacotesListar.aspx");
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            int idpacote = Convert.ToInt32(Session["idpacote"]);
            int idrefeicao = Convert.ToInt32(DropDownList1.SelectedValue);

            Modelo.Pacote_Refeicao aRF = new Modelo.Pacote_Refeicao(0, idpacote, idrefeicao);
            DAL.DALPacote_Refeicao aDALPacote_Refeicao = new DAL.DALPacote_Refeicao();


            aDALPacote_Refeicao.Insert(aRF);
            Response.Redirect("~\\WebFormPacoteDetalhar.aspx?Pacote=" + idpacote);
        }
        protected void Error(string n)
        {
            divalert.Attributes["class"] = "alert alert-danger";
            Label2.Text = n;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            DAL.DALComentario aCom = new DAL.DALComentario();
            Modelo.Comentario mCom;
            int id = Convert.ToInt32(Session["idlogin"]);
            int pacote = Convert.ToInt32(Session["idpacote"]);
            mCom = new Modelo.Comentario(0,TextBox2.Text,pacote, id, DateTime.Now);

            aCom.Insert(mCom);

            Response.Redirect("~\\WebFormPacoteDetalhar.aspx?Pacote=" + pacote);
        }
    }
}