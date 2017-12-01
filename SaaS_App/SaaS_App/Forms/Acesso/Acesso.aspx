<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acesso.aspx.cs" Inherits="SaaS_App.Forms.Acesso" %>

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
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-md-offset-5">
                    <asp:Image runat="server" ID="ImgLogo" ImageUrl="~/img/acesso/04_Logo.png" Height="180px" Width="150px" />
                </div>
                <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-login">
                        <div class="panel-heading">
                            <div class="row">
                                <div id="divSize" class="col-xs-6">
                                    <a href="#" style="display:none" class="active" id="login-form-link">Acessar</a>
                                </div>
                                <div id="colSize" class="col-xs-6">
                                    <a href="#" id="register-form-link">Registrar</a>
                                </div>
                            </div>
                            <hr />
                        </div>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">

                                    <%-- Form de Login --%>

                                    <div id="login-form" role="form" style="display: block;">
                                        <div class="form-group">
                                            <label class="control-label col-md-5">Email</label>
                                            <asp:TextBox runat="server" TextMode="Email" ID="txt_login" TabIndex="1" CssClass="form-control" value=""></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-5">Senha</label>
                                            <asp:TextBox runat="server" TextMode="Password" ID="txt_senha" TabIndex="2" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-12 col-sm-offset-3">
                                                    <asp:Button runat="server" ID="btn_logar" TabIndex="4" Width="250px" CssClass="btn btn-info" Text="Acessar" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="text-center">
                                                        <a href="#" tabindex="5" class="forgot-password">Esqueceu sua senha?</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- Fim do Form de Login --%>

                                    <%-- Form de Registrar Conta --%>
                                    <div id="register-form" role="form" style="display: none;">

                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txt_cad_usuario" ClientIDMode="Static" TabIndex="1" CssClass="form-control" placeholder="E-mail"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txt_cad_senha" ClientIDMode="Static" TextMode="Password" TabIndex="2" CssClass="form-control" placeholder="Senha"></asp:TextBox>

                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txt_cad_confirmar_senha" ClientIDMode="Static" TextMode="Password" TabIndex="3" CssClass="form-control" placeholder="Confirmar Senha"></asp:TextBox>
                                            <asp:CompareValidator ID="ValidatorSenha" runat="server" ErrorMessage="Senha Não Confere" ControlToValidate="txt_cad_confirmar_senha" ControlToCompare="txt_cad_senha" Text="" Display="Dynamic" Font-Bold="True"></asp:CompareValidator>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-3 col-md-offset-5">
                                                <asp:Button runat="server" ID="btn_Valida_Cadastro" ClientIDMode="Static" OnClick="btn_Valida_Cadastro_Click" CssClass="btn btn-success" Text="Prosseguir" />
                                            </div>
                                        </div>
                                    </div>

                                    <%-- Fim do Form Registro de Conta --%>


                                    <%--Form de Cadastro da Empresa--%>

                                    <div id="empresa-form" role="form" style="display: none;">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label col-md-5">Empresa</label>
                                                    <asp:TextBox runat="server" ID="txEmpresa" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block">Razão Social/Nome Fantasia </span>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-5">Responsável</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ID="txResponsavel" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block">Ponto Focal</span>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-5">CNPJ</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ID="cpf_cnpj" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block">CPF/CNPJ</span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-8">Comercial</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ID="txFone1" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block">(34) 9999-9999</span>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-5">Celular</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ID="txFone2" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block">(34) 99999-9999</span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label col-md-5">CEP</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ID="cep" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block">00000-000</span>
                                                </div>
                                            </div>

                                            <div class="col-md-8">
                                                <div class="form-group">
                                                    <label class="control-label col-md-5">Endereço</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ID="rua" CssClass="form-control"></asp:TextBox>
                                                    <span class="help-block">Ex.: Avenia, Rua</span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-8">
                                                <div class="form-group">
                                                    <label class="control-label col-md-5">Cidade</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ID="cidade" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label col-md-5">Estado/UF</label>
                                                    <asp:TextBox runat="server" MaxLength="50" ID="uf" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <%-- Fim do Form Cadastro da Empresa --%>
                                </div>
                            </div>
                            <div class="form-group w3-margin-top" id="MenuCadastro" role="form" style="display: none;">
                                <div class="row">
                                    <div class="col-md-3 col-md-offset-2">
                                        <div class="form-group">
                                            <asp:Image runat="server" ID="ImgUser" ImageUrl="~/img/acesso/01_Icon_User_Disable.png" Height="50px" Width="50px" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:Image runat="server" ID="ImgEmpresa" ImageUrl="~/img/acesso/02_Icon_Empresa_Disable.png" Height="50px" Width="50px" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:Image runat="server" ID="ImgMenu3" ImageUrl="~/img/acesso/03_Icon_Menu3_Disable.png" Height="50px" Width="50px" />
                                        </div>
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
