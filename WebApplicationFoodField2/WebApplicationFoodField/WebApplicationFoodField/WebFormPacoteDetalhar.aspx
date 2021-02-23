<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="WebFormPacoteDetalhar.aspx.cs" Inherits="WebApplicationFoodField.WebFormPacoteDetalhar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .starRating {
            width: 25px;
            height: 25px;
            padding: 2px;
            background-repeat: no-repeat;
            display: block;
        }

        .FilledStars {
            background-image: url("Imagens/Star1.png");
        }

        .WatingStars {
            background-image: url("Imagens/Star1.png");
        }

        .EmptyStars {
            background-image: url("Imagens/Star3.png");
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" CssClass="" runat="server">
        <div runat="server" id="divalert" class="alert alert-danger display">
            <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="15px"></asp:Label>
        </div>

        <div runat="server" id="divControl" class="display">
            <div runat="server" class="display" id="Edit">
                <asp:Button ID="Button5" runat="server" Text="Confirmar Edição" CssClass="login10-form-btn-m-15" OnClick="Editar" />
            </div>
            <div runat="server" class="display" id="CancelEdit">
                <asp:Button ID="Button6" runat="server" Text="Cancelar edição" CssClass="login10-form-btn-b-m-15" OnClick="Voltar" />
            </div>
            <asp:Button ID="Button1" runat="server" Text="Editar pacote" CssClass="login10-form-btn-m-15" PostBackUrl="~/WebFormPacoteDetalhar.aspx?Edit=1" />
            <div runat="server" id="divExcluir">
                <button type="button" class="login10-form-btn-b-m-15" data-toggle="modal" data-target="#ModalExcluir">
                    Excluir Pacote
                </button>
            </div>
        </div>
        <div class="d-flex2">
            <asp:Image ID="ImagePacote" runat="server" CssClass="Pacote-Img" />
            <div runat="server" id="ImgInput" class="Pacote-Img-div display">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
            <div>
                <asp:Label ID="LabelNome" runat="server" CssClass="txt11"></asp:Label><br />
                <div id="divName" runat="server" class="Name display">
                    <asp:TextBox runat="server" ID="Nome" CssClass="input100-edit3 txt11"></asp:TextBox>
                </div>
                <div class="d-flex4">
                    <asp:Label ID="LabelPreco" runat="server" CssClass="txt7" Text="Label"></asp:Label>
                    <div runat="server" id="divPreco" class="Preco display">
                        <asp:TextBox runat="server" ID="Preco" CssClass="input100-edit3 txt7"></asp:TextBox>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <ajaxToolkit:Rating ID="Rating1" runat="server" StarCssClass="starRating" FilledStarCssClass="FilledStars" EmptyStarCssClass="EmptyStars" WaitingStarCssClass="WatingStars" MaxRating="5" ReadOnly="False"></ajaxToolkit:Rating>
                        <asp:Timer ID="Timer1" runat="server"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <br />
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="txt8 textboxD" Height="135px"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>



    <div id="div2" class="d-flex3" runat="server">
        <div runat="server" id="divComprar">
            <button type="button" class="login15-form-btn-a" data-toggle="modal" data-target="#ModalValidar">
                Comprar
            </button>
        </div>
        <div runat="server" id="divCancel" class="display">
            <button type="button" class="login15-form-btn-b" data-toggle="modal" data-target="#ModalValidar">
                Cancelar
            </button>
        </div>
        <asp:Button ID="Button2" runat="server" CssClass="login15-form-btn-c display" Text="Avaliar" OnClick="Button2_Click1" />
    </div>


    <section runat="server" id="section" class="margintop-15 display">
        <div runat="server" class="margin-l-16per">
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button9" runat="server" Text="Inserir" CssClass="login10-form-btn-m-15-a" OnClick="Button9_Click" />
            <br />
            <br />
        </div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </section>


    <div class="modal fade" id="ModalValidar">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="margin-10">
                    <asp:Label ID="Label8" runat="server" CssClass="txt10 text-center" Text="Você tem certeza em comprar esse pacote?"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button7" runat="server" CssClass="login25-form-btn" Text="Confirmar" OnClick="Button1_Click" />
                    <asp:Button ID="Button8" runat="server" CssClass="login25-form-btn-b" Text="Cancelar" OnClick="Refresh" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalExcluir">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="margin-10">
                    <asp:Label ID="Label1" runat="server" CssClass="txt10 text-center" Text="Você tem certeza em excluir esse pacote?"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button3" runat="server" CssClass="login25-form-btn" Text="Confirmar" OnClick="Excluir" />
                    <asp:Button ID="Button4" runat="server" CssClass="login25-form-btn-b" Text="Cancelar" OnClick="Refresh" />
                </div>
            </div>
        </div>
    </div>
    <div class="margin-l-16per" style="width : 57%;">
    <hr />

    <h1>Comentários </h1>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="txt8 textboxD" TextMode="MultiLine" MaxLength="280"></asp:TextBox>
        <br />
        <br />
    <asp:Button ID="Button10" runat="server" CssClass="login15-form-btn-a" Width="50%" Text="Comentar" OnClick="Button10_Click" />
    <hr />
        </div>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
            <div class="margin-l-16per" style="width : 57%;">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "img_url")%>' CssClass="img-circle user" /></td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "comentario")%>' CssClass="txt8 textboxD" Enabled="false" Height="0"></asp:TextBox>
                <br />
                    <a class="pull-right"><%# DataBinder.Eval(Container.DataItem, "data")%></a>
                </td>
            </tr>
                <hr />
                </div>
            
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectId_Pacote" TypeName="WebApplicationFoodField.DAL.DALComentario">
        <SelectParameters>
            <asp:SessionParameter Name="id" SessionField="idpacote" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
