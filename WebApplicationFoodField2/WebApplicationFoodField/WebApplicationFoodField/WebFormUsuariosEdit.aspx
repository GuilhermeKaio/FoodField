<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="WebFormUsuariosEdit.aspx.cs" Inherits="WebApplicationFoodField.WebFormUsuariosEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .over {
            width: 320px;
            height: 320px;
            position: absolute;
            top: 0px;
            bottom: 0;
            transition: 0.5s;
        }

            .over:hover {
                background-image: url(Imagens/profile-hover.png);
                background-repeat: no-repeat;
                opacity: 0.4;
                width: 320px;
                height: 320px;
            }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_cep').blur(function () {
                var cep = $('#ContentPlaceHolder1_cep').val() || '';
                if (!cep) {
                    return
                }
                var url = 'http://viacep.com.br/ws/' + cep + '/json';
                $.getJSON(url, function (data) {
                    if ("error" in data) {
                        return
                    }
                    $('#ContentPlaceHolder1_rua').val(data.logradouro);
                    $('#ContentPlaceHolder1_cidade').val(data.localidade);
                    $('#ContentPlaceHolder1_bairro').val(data.bairro);
                    $('#ContentPlaceHolder1_uf').val(data.uf);
                });
            });
        });

        $(document).ready(function () {
            $("#ContentPlaceHolder1_cep").mask("00000-000");
            $("#ContentPlaceHolder1_TextBoxTelefone").mask("(00)0000-0000");
            $("#ContentPlaceHolder1_TextBoxCPF").mask("000.000.000-00");
            $("#ContentPlaceHolder1_numero").mask("00000");
        });

        function myFunction() {
            $("#ModalEdit").modal("show")
        }
        function myFunction2() {
            $("#ModalError").modal("show")
        }
        function myFunction1() {
            $("#ModalDelete").modal("show")
        }
    </script>
    <div class="container">
        <div class="row pd-40">
            <div class="containera col-xl-6">
                <div class="avatar-flip">
                    <a class="over" href="#" data-toggle="modal" data-target="#myModal"></a>
                    <asp:Image ID="Image1" runat="server" Height="320px" Width="320px" />
                </div>
                <a runat="server" id="Nome">
                    <asp:Label ID="LabelNome" CssClass="txt20" runat="server" Text="Nome"></asp:Label><br />
                </a>
                <a runat="server" id="NomeEdit" class="display">
                    <asp:TextBox ID="TextBoxNome" CssClass="input100-edit text-center " placeholder="Nome" runat="server"></asp:TextBox>
                </a>
                <a runat="server" id="EmailL" class="display">
                    <asp:Label ID="Label4" runat="server" Text="Email: " CssClass="txt9"></asp:Label>
                </a>
                <a runat="server" id="Email">
                    <asp:Label ID="LabelEmail" runat="server" Text="aaaa@bbb.com" CssClass="txt8"></asp:Label><br />
                </a>
                <a runat="server" id="EmailEdit" class="display">
                    <asp:TextBox ID="TextBoxEmail" CssClass="input100-edit2 text-center" placeholder="Email" runat="server"></asp:TextBox>
                </a>
                <asp:Label ID="Label2" runat="server" Text="Telefone: " CssClass="txt9"></asp:Label>
                <a runat="server" id="Tel">
                    <asp:Label ID="LabelTelefone" runat="server" Text="98888-7777" CssClass="txt8"></asp:Label><br />
                </a>
                <a runat="server" id="TelEdit" class="display">
                    <asp:TextBox ID="TextBoxTelefone" CssClass="input100-edit2 text-center" placeholder="Telefone" runat="server"></asp:TextBox>
                </a>
                <asp:Label ID="Label3" runat="server" Text="CPF: " CssClass="txt9"></asp:Label>
                <a runat="server" id="CPF">
                    <asp:Label ID="LabelCPF" runat="server" Text="XXX.XXX.XXX" CssClass="txt8"></asp:Label>
                </a>
                <a runat="server" id="CPFEdit" class="display">
                    <asp:TextBox ID="TextBoxCPF" CssClass="input100-edit2 text-center" placeholder="CPF" runat="server"></asp:TextBox>
                </a>
                <br />
                <br />
                <a runat="server" id="btn1">
                    <asp:Button ID="Button1" runat="server" CssClass="login100-form-btn" Text="Editar" OnClick="Button1_Click" />
                </a>
                <a runat="server" id="btn2" class="display">
                    <asp:Button ID="Button2" runat="server" CssClass="login100-form-btn" Text="Confirmar" OnClick="Button2_Click" />
                </a>
            </div>
            <div class=" col-xl-5 col-sm-offset-1">
                <asp:Label ID="Label1" CssClass="txt7" runat="server" Text="Seus Endereços"></asp:Label><br />
                <br />
                <a href="#" data-toggle="modal" data-target="#ModalEdit" class="login25-form-btn" data-marcacao="frase">Adicionar um Endereço</a>
                <br />
                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                <br />
                <asp:Label ID="Label6" runat="server" CssClass="txt7" Text="Histórico de Transações"></asp:Label>
                <br />
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModal">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="margin-25">
                    <asp:Label ID="Label5" runat="server" CssClass="txt10 text-center" Text="Escolha sua Imagem:"></asp:Label>
                    <asp:FileUpload ID="FileUpload1" CssClass="text-center" runat="server" accept=".png,.jpg,.jpeg" />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button3" runat="server" CssClass="login25-form-btn" Text="Confirmar" OnClick="Button3_Click" />
                    <button type="button" class="login25-form-btn-b" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ModalEdit">
        <div class="modal-dialog margin-a" role="document">
            <div class="modal-content size-150">
                <div class="modal-header">
                </div>
                <div class="margin-5">
                    <asp:Label ID="Label7" runat="server" CssClass="txt10 text-center" Text="Adicione o endereço"></asp:Label><br />
                    <asp:TextBox ID="rua" placeholder="Logradouro" runat="server" CssClass="input50-15-r"></asp:TextBox>
                    <asp:TextBox ID="numero" placeholder="Numero" runat="server" CssClass="input24-15-r margin-9-r"></asp:TextBox>
                    <asp:TextBox ID="cep" placeholder="CEP" runat="server" CssClass="input24-15-l" onclick="tryPlaceholderCEP(this,'CEP')" Text="CEP"></asp:TextBox>
                    <asp:TextBox ID="bairro" placeholder="Bairro" runat="server" CssClass="input50-15-l"></asp:TextBox>
                    <asp:TextBox ID="cidade" placeholder="Cidade" runat="server" CssClass="input50-15-r"></asp:TextBox>
                    <asp:DropDownList ID="uf" runat="server" CssClass="center-block">
                        <asp:ListItem Text="AC" Value="AC" />
                        <asp:ListItem Text="AL" Value="AL" />
                        <asp:ListItem Text="AP" Value="AP" />
                        <asp:ListItem Text="AM" Value="AM" />
                        <asp:ListItem Text="BA" Value="BA" />
                        <asp:ListItem Text="CE" Value="CE" />
                        <asp:ListItem Text="DF" Value="DF" />
                        <asp:ListItem Text="ES" Value="ES" />
                        <asp:ListItem Text="GO" Value="GO" />
                        <asp:ListItem Text="MA" Value="MA" />
                        <asp:ListItem Text="MT" Value="MT" />
                        <asp:ListItem Text="MS" Value="MS" />
                        <asp:ListItem Text="MG" Value="MG" />
                        <asp:ListItem Text="PA" Value="PA" />
                        <asp:ListItem Text="PB" Value="PB" />
                        <asp:ListItem Text="PR" Value="PR" />
                        <asp:ListItem Text="PE" Value="PE" />
                        <asp:ListItem Text="PE" Value="PE" />
                        <asp:ListItem Text="PI" Value="PI" />
                        <asp:ListItem Text="RJ" Value="RJ" />
                        <asp:ListItem Text="RN" Value="RN" />
                        <asp:ListItem Text="RS" Value="RS" />
                        <asp:ListItem Text="RO" Value="RO" />
                        <asp:ListItem Text="RR" Value="RR" />
                        <asp:ListItem Text="SC" Value="SC" />
                        <asp:ListItem Text="SP" Value="SP" />
                        <asp:ListItem Text="SE" Value="SE" />
                        <asp:ListItem Text="TO" Value="TO" />
                    </asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button4" runat="server" CssClass="login25-form-btn" Text="Confirmar" OnClick="Button4_Click" />
                    <asp:Button ID="Button5" runat="server" CssClass="login25-form-btn display" Text="Confirmar" OnClick="EditarE" />
                    <asp:Button ID="Button6" runat="server" CssClass="login25-form-btn-b" Text="Cancelar" OnClick="EditarE" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalDelete">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="margin-10">
                    <asp:Label ID="Label8" runat="server" CssClass="txt10 text-center" Text=""></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button7" runat="server" CssClass="login25-form-btn" Text="Confirmar" OnClick="ExcluirE" />
                    <asp:Button ID="Button8" runat="server" CssClass="login25-form-btn-b" Text="Cancelar" OnClick="ExcluirE" />
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
