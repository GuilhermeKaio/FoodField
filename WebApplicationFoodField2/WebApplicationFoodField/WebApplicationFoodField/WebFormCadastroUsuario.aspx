<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCadastroUsuario.aspx.cs" Inherits="WebApplicationFoodField.WebFormCadastroUsuario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css" />
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css" />
    <link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css" />
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css" />
    <link rel="stylesheet" type="text/css" href="css/util.css" />
    <link rel="stylesheet" type="text/css" href="css/main.css" />
    <link href="Style.css" rel="stylesheet" />
    <style>
        
    </style>
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="js/jquery.mask.js"></script>
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="vendor/select2/select2.min.js"></script>
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <script src="js/main.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextBoxTelefone").mask("(00)0000-0000");
            $("#TextBoxCPF").mask("000.000.000-00");
        });

    </script>
</head>
<body style="background-image: url('Imagens/Background_2.jpg')">
    <div class="filtro">
        <form id="form1" runat="server">
            <div class="container-login100">
                <div class="wrap-login100">
                    <div class="login100-form validate-form p-l-55 p-r-55 p-t-178 p-b-45 txt1">
                        <span class="login100-form-title">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/Untitled-10.png" />
                        </span>
                        <div runat="server" id="divalert" class="alert alert-danger display">
                                <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="15px"></asp:Label>
                            </div>
                        <asp:TextBox ID="TextBoxNome" runat="server" CssClass="input100-35" placeholder="Nome"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBoxCPF" name="TextBoxRG" runat="server" CssClass="input50-35 col-xs-5" placeholder="CPF"></asp:TextBox>
                        <asp:TextBox ID="TextBoxTelefone" runat="server" CssClass="input50-35 col-xs-5 col-xs-offset-1" placeholder="Telefone"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                        <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="input100-35" TextMode="Email" placeholder="Email"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBoxLogin" runat="server" CssClass="input100-35" placeholder="Login"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBoxSenha" runat="server" CssClass="input50-35 col-xs-5" placeholder="Senha" TextMode="Password"></asp:TextBox>
                        <asp:TextBox ID="TextBoxSenhaV" runat="server" CssClass="input50-35 col-xs-5 col-xs-offset-1" placeholder="Repita" TextMode="Password"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Cadastrar Usuario" CssClass="login100-form-btn" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
