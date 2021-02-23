<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplicationFoodField.WebForm2" %>
<!DOCTYPE html>
<style>
   .aa{
       margin-left : 1.5%
   }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title></title>
      <link href="css/bootstrap.css" rel="stylesheet" />
      <link href="Style.css" rel="stylesheet" />
   </head>
   <body>
      <form id="form1" runat="server">
         <div>
            <section class="header-sites">
               <div class="filtro">
                  <div class="container">
                     <div class="row">
                        <div class="col-xs-12">
                           <img src="Imagens/Food-Field_Logo.png" class="img-responsive center-block logo" />
                           <br />
                           <p class="text-center butao">
                              <a href="WebFormCadastroUsuario.aspx" class="btn btn-primary">Registrar-se</a>
                              <a href="WebFormLogin.aspx" class="btn btn-success">Fazer Login</a>
                           </p>
                        </div>
                     </div>
                  </div>
               </div>
            </section>
            <section class="content-site">
               <div class="container">
                  <div class="row">
                     <div class="col-xs-12">
                        <h1 class="text-center">
                           consectetur adipiscing elit.
                        </h1>
                        <p class="text-center">
                           Morbi ex odio, eleifend vitae interdum a, efficitur ut urna. In posuere turpis vitae tortor sollicitudin blandit. Aliquam iaculis scelerisque elit et imperdiet. Aenean at maximus arcu. Curabitur sed mi quis diam molestie ultrices. Integer varius dapibus justo ac rutrum. Mauris blandit erat quis faucibus ultrices. Pellentesque auctor pretium hendrerit. Maecenas tempus bibendum dolor vitae luctus. Etiam sagittis odio ut nibh lobortis ultrices sit amet et arcu. Fusce arcu ante, euismod et mi in, hendrerit convallis sem. Phasellus et volutpat libero, scelerisque scelerisque leo. Proin fermentum mollis odio at porta.
                        </p>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-sm-4">
                        <div class="thumbnail">
                           <img src="Imagens/Background_1.jpg" />
                           <div class="caption text-center">
                              <h3>Suspendisse eget erat tincidunt</h3>
                              <p>Aenean at maximus arcu. Curabitur sed mi quis diam molestie ultrices. Integer varius dapibus justo ac rutrum. Mauris blandit erat quis faucibus ultrices.</p>
                           </div>
                        </div>
                     </div>
                     <div class="col-sm-4">
                        <div class="thumbnail">
                           <img src="Imagens/Background_3.jpg" />
                           <div class="caption text-center">
                              <h3>Vivamus aliquam ornare ex</h3>
                              <p>Aenean at maximus arcu. Curabitur sed mi quis diam molestie ultrices. Integer varius dapibus justo ac rutrum. Mauris blandit erat quis faucibus ultrices.</p>
                           </div>
                        </div>
                     </div>
                     <div class="col-sm-4">
                        <div class="thumbnail">
                           <img src="Imagens/Background_5.jpg" />
                           <div class="caption text-center">
                              <h3>Morbi ex odio</h3>
                              <p>Aenean at maximus arcu. Curabitur sed mi quis diam molestie ultrices. Integer varius dapibus justo ac rutrum. Mauris blandit erat quis faucibus ultrices.</p>
                           </div>
                        </div>
                     </div>
                      <asp:Panel ID="Panel1" runat="server" CssClass="col-sm-4">
                          <asp:Panel ID="Panel2" runat="server" CssClass="thumbnail">
                              <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/Background_1.jpg" />
                                <asp:Panel ID="Panel3" runat="server" CssClass="caption text-center">
                                    <h3>Morbi ex odio</h3>
                                    <p>Aenean at maximus arcu. Curabitur sed mi quis diam molestie ultrices. Integer varius dapibus justo ac rutrum. Mauris blandit erat quis faucibus ultrices.</p>
                                </asp:Panel>
                          </asp:Panel>
                      </asp:Panel>



                  </div>
               </div>
            </section>
            <section class="img-site">
               <div class="container">
                  <div class="row">
                     <div class="row">
                        <div class="col-xs-12">
                           <p class="lead text-center">consectetur adipiscing elit. Nulla efficitur non dolor sit amet sodales. Sed augue turpis, scelerisque quis nisi non, ullamcorper pellentesque diam. Phasellus et magna ligula. Maecenas condimentum, ligula in tincidunt finibus, justo nisl tempus sapien, a semper ex augue ut risus. Nulla cursus mollis magna, quis porta nunc pretium sagittis. Nunc in ligula massa. Donec tempus mi vestibulum libero consectetur pretium. Quisque in sapien ac lacus semper mattis id sit amet tortor. Integer vitae mollis sapien.</p>
                           <p class="text-center">
                           </p>
                        </div>
                     </div>
                  </div>
               </div>
            </section>
         </div>
      </form>
   </body>
</html>