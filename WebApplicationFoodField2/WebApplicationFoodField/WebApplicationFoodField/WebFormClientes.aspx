<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="WebFormClientes.aspx.cs" Inherits="WebApplicationFoodField.WebFormClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function Excluir() {
            $("#ModalExcluir").modal("show")
        }
    </script>
    <div>
        <button type="button" class="login10-form-btn-m-15" data-toggle="modal" data-target="#ModalNovo">Nova conta</button>
        <div class="">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
        
        <div>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        </div>
    </div>
    <div class="modal fade" id="ModalExcluir">
        <div class="modal-dialog margin-a" role="document">
            <div class="modal-content size-150">
                <div class="modal-header">
                </div>
                <div class=" margin-5">
                    <asp:Label ID="Label2" runat="server" CssClass="txt10 text-center" Text="Tem certeza em excluir?"></asp:Label><br />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button1" runat="server" Text="Excluir" CssClass="login25-form-btn" OnClick="Button5_Click"/>
                    <asp:Button ID="Button2" runat="server" Text="Excluir" CssClass="login25-form-btn" OnClick="Button7_Click"/>
                    <asp:Button ID="Button3" CssClass="login25-form-btn-b" runat="server" Text="Cancelar" OnClick="Button6_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalNovo">
        <div class="modal-dialog margin-a" role="document">
            <div class="modal-content size-150">
                <div class="modal-header">
                </div>
                <div class="pad-5 margin-5">
                    <div runat="server" id="divalert" class="alert alert-danger display">
                                <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="15px"></asp:Label>
                            </div>
                    <asp:TextBox ID="TextBoxNome" placeholder="Nome" runat="server" CssClass="input50-m"></asp:TextBox>
                    <asp:TextBox ID="TextBoxTelefone" placeholder="Telefone" runat="server" CssClass="input50-m"></asp:TextBox>
                    <asp:TextBox ID="TextBoxEmail" placeholder="Email" runat="server" CssClass="input50-m"></asp:TextBox>
                    <asp:TextBox ID="TextBoxLogin" placeholder="Login" runat="server" CssClass="input50-m"></asp:TextBox>
                    <asp:TextBox ID="TextBoxSenha" placeholder="Senha" TextMode="Password" runat="server" CssClass="input50-m"></asp:TextBox>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button5" runat="server" Text="Novo Administrador" CssClass="login25-form-btn" OnClick="Button5_Click1"/>
                    <asp:Button ID="Button7" runat="server" Text="Novo Nutricionista" CssClass="login25-form-btn" OnClick="Button7_Click1"/>
                    <asp:Button ID="Button6" CssClass="login25-form-btn-b" runat="server" Text="Cancelar" OnClick="Button6_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
