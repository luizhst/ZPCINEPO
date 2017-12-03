<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acesso.aspx.cs" Inherits="SaaS_App.Forms.Acesso.Acesso" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" type="text/css" runat="server" media="screen" href="~/Style/Login.css" />
    <link rel="stylesheet" type="text/css" runat="server" media="screen" href="~/Content/bootstrap.min.css" />
    <script type="text/javascript" src="../../Scripts/jquery-3.2.1.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../Scripts/Functions.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.inputmask.bundle.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/6.10.1/sweetalert2.all.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/6.10.1/sweetalert2.min.css" rel="stylesheet" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-area">
            <div class="bg-image">
                <div class="login-signup">
                    <div class="container">
                        <div class="login-header">
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="login-logo">
                                        <asp:Image runat="server" ID="ImgLogotipo" CssClass="img-responsive ImgLogotipo" ImageUrl="../../img/acesso/04_Logotipo.png" />
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="login-details">
                                        <ul class="nav nav-tabs navbar-right">
                                            <li><a data-toggle="tab" href="#register">Registrar</a></li>
                                            <li class="active"><a data-toggle="tab" href="#login">Acessar</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="tab-content">
                            <div id="register" class="tab-pane">
                                <div class="login-inner">
                                    <div class="title">
                                        <h1>Registre - <span>se</span></h1>
                                    </div>
                                    <div class="login-form">
                                        <div class="form-details">
                                            <label class="mail">
                                                <asp:TextBox TextMode="Email" CssClass="mail" runat="server" placeholder="E-mail" ID="tx_cad_email"></asp:TextBox>
                                            </label>
                                            <label class="pass">
                                                <asp:TextBox TextMode="Password" CssClass="password" runat="server" placeholder="Senha" ID="tx_cad_senha"></asp:TextBox>
                                            </label>
                                            <label class="pass">
                                                <asp:TextBox TextMode="Password" CssClass="password" runat="server" placeholder="Senha" ID="tx_cad_confirmasenha"></asp:TextBox>
                                            </label>
                                            <asp:CompareValidator ID="cv_senha" runat="server" ErrorMessage="CompareValidator" ControlToCompare="tx_cad_senha" ControlToValidate="tx_cad_confirmasenha" Text="As senhas não coincidem!"></asp:CompareValidator>
                                        </div>
                                        <asp:Button runat="server" CssClass="form-btn btn-success" OnClick="BtnRegistrar_Click" ID="BtnRegistrar" Text="Registrar" />
                                    </div>
                                </div>
                            </div>
                            <div id="login" class="tab-pane fade in active">
                                <div class="login-inner">
                                    <div class="title">
                                        <h1>Bem <span>Vindo!</span></h1>
                                    </div>
                                    <div class="login-form">
                                        <div class="form-details">
                                            <label class="user">
                                                <asp:TextBox TextMode="Email" CssClass="mail" required="true" runat="server" placeholder="E-mail" ID="txt_Email">nova@conta.com.br</asp:TextBox>
                                            </label>
                                            <label class="pass">
                                                <asp:TextBox TextMode="Password" CssClass="password" runat="server" placeholder="Senha" ID="txt_Senha">123</asp:TextBox>
                                            </label>
                                        </div>
                                        <asp:Button runat="server" CssClass="form-btn btn-success" ID="Btn_Acessar" OnClick="Btn_Acessar_Click" Text="Acessar" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
