<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormLogin.aspx.cs" Inherits="WebApplicationFoodField.WebFormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    <title></title>
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="vendor/select2/select2.min.js"></script>
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <script src="js/main.js"></script>
</head>
<body style="background-image: url('Imagens/Background_2.jpg')">
    <div class="filtro">
        <form id="form1" runat="server">
            <div class="limiter">
                <div class="container-login100">
                    <div class="wrap-login100">
                        <div class="login100-form validate-form p-l-55 p-r-55 p-t-178">
                            <span class="login100-form-title">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/Untitled-10.png" />
                            </span>
                            <div runat="server" id="divalert" class="alert alert-danger display">
                                <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="15px"></asp:Label>
                            </div>

                            <div class="wrap-input100 validate-input m-b-16" data-validate="Please enter username">
                                <asp:TextBox ID="TextBoxLogin" placeholder="Login" CssClass="input100" name="username" runat="server"></asp:TextBox>
                                <span class="focus-input100"></span>
                            </div>

                            <div class="wrap-input100 validate-input" data-validate="Please enter password">
                                <asp:TextBox ID="TextBoxSenha" placeholder="Senha" CssClass="input100" runat="server" TextMode="Password"></asp:TextBox>
                                <span class="focus-input100"></span>
                            </div>
                            <br />
                            <br />
                            <br />

                            <div class="container-login100-form-btn">
                                <asp:Button ID="Button1" CssClass="login100-form-btn" runat="server" Text="Entrar" OnClick="Button1_Click" />
                            </div>

                            <div class="flex-col-c p-t-170 p-b-40">
                                <span class="txt1 p-b-9">Não tem uma conta?
                                </span>

                                <a href="WebFormCadastroUsuario.aspx" class="txt3">Cadastre-se
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



        </form>
    </div>

</body>
</html>
