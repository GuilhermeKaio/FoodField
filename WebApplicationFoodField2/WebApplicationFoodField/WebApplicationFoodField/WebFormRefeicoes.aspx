<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="WebFormRefeicoes.aspx.cs" Inherits="WebApplicationFoodField.WebFormRefeicoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function Editar() {
            $("#ModalEdit").modal("show")
        }
        function Excluir() {
            $("#ModalExcluir").modal("show")
        }
        function myFunction2() {
            $("#ModalError").modal("show")
        }
    </script>
    <asp:Panel ID="Panel1" runat="server" CssClass="txt4 text-center">
            Todas as Refeições
        </asp:Panel>
    <asp:Button ID="Button4" runat="server" Text="Nova Refeição" OnClick="Novo" CssClass="login10-form-btn-m-15" />
    <br />

    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    <div class="modal fade" id="ModalEdit">
        <div class="modal-dialog margin-a" role="document">
            <div class="modal-content size-150">
                <div class="modal-header">
                </div>
                <div class=" margin-5">
                    <asp:Label ID="Label7" runat="server" CssClass="txt10 text-center" Text="Preencha os campos"></asp:Label><br />
                    <div class="ModalREF">
                    <asp:TextBox ID="TextBoxIngredientes" placeholder="Ingredientes" runat="server" CssClass="textboxREF" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox ID="TextBoxModoPreparo" placeholder="Modo de Preparo" runat="server" CssClass="textboxREF" TextMode="MultiLine"></asp:TextBox>
                        </div><asp:TextBox ID="TextBoxNome" runat="server" placeholder="Nome" CssClass="input50-15-l"></asp:TextBox><br /><br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <div class="modal-footer">

                    <asp:Button ID="Button1" runat="server" Text="Editar" CssClass="login25-form-btn" OnClick="Button1_Click"/><asp:Button ID="Button2" runat="server" CssClass="login25-form-btn" Text="Salvar" OnClick="Insert"/><asp:Button ID="Button3" runat="server" CssClass="login25-form-btn-b" Text="Cancelar" OnClick="Button3_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalExcluir">
        <div class="modal-dialog margin-a" role="document">
            <div class="modal-content size-150">
                <div class="modal-header">
                </div>
                <div class=" margin-5">
                    <asp:Label ID="Label1" runat="server" CssClass="txt10 text-center" Text="Tem certeza em excluir essa refeição?"></asp:Label><br />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button5" runat="server" Text="Excluir" CssClass="login25-form-btn" OnClick="Button2_Click"/><asp:Button ID="Button6" CssClass="login25-form-btn-b" runat="server" Text="Cancelar" OnClick="Button3_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalError">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="margin-10">
                    <asp:Label ID="Label9" runat="server" CssClass="txt10 text-center" Text=""></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="login25-form-btn" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
