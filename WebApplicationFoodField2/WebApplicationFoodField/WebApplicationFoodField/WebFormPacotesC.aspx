<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="WebFormPacotesC.aspx.cs" Inherits="WebApplicationFoodField.WebFormPacotesC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/bootstrap.css" rel="stylesheet" />
    <h1>
        <asp:Panel ID="Panel1" runat="server" CssClass="txt4 text-center">
            Seus Pacotes
        </asp:Panel>

    </h1>
    <div style="display: none">
    <asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label></div>
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
