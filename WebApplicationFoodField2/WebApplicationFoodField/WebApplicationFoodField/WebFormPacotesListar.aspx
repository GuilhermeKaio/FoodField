<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="WebFormPacotesListar.aspx.cs" Inherits="WebApplicationFoodField.WebFormPacotesListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divPacoteNew" class="display">
        <asp:Button ID="Button1" runat="server" Text="Novo Pacote" CssClass="login10-form-btn-m-15" PostBackUrl="~/WebFormPacoteDetalhar.aspx?Edit=1" />

        <asp:Button ID="Button3" runat="server" Text="Listar Refeições" CssClass="login10-form-btn-m-15" OnClick="Button3_Click" />
        </div>

    <h1>
        <asp:Panel ID="Panel1" runat="server" CssClass="txt4 text-center">
            Pacotes Disponíveis
        </asp:Panel>
    </h1>
    <asp:DropDownList ID="DropDownList1" CssClass="txt1 margin-l-16" runat="server">
        <asp:ListItem Text="Ordem alfabética ⬇️" Value="1" ></asp:ListItem>
        <asp:ListItem Text="Ordem alfabética ⬆️" Value="2" ></asp:ListItem>
        <asp:ListItem Text="Menor preço" Value="3" ></asp:ListItem>
        <asp:ListItem Text="Maior preço" Value="4" ></asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button2" runat="server" Text="Ordenar" CssClass="login-form-btn-order" OnClick="Button2_Click"/>
    <br />
    <br />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    
</asp:Content>
