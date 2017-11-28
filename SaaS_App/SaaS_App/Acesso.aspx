<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acesso.aspx.cs" Inherits="WebApplication2.Acesso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" runat="server" media="screen" href="~/Style/Login.css" />
    <link rel="stylesheet" type="text/css" runat="server" media="screen" href="~/Content/bootstrap.min.css" />
    <script type="text/javascript" src="Scripts/jquery-3.2.1.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/Functions.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<div class="container">
    	<div class="row">
			<div class="col-md-6 col-md-offset-3">
				<div class="panel panel-login">
					<div class="panel-heading">
						<div class="row">
							<div class="col-xs-6">
								<a href="#" class="active" id="login-form-link">Acessar</a>
							</div>
							<div class="col-xs-6">
								<a href="#" id="register-form-link">Registrar</a>
							</div>
						</div>
						<hr/>
					</div>
                    <%-- Form de Acesso do Usuario --%>
					<div class="panel-body">
						<div class="row">
							<div class="col-lg-12">
								<div id="login-form" role="form" style="display: block;">
									<div class="form-group">
										<asp:TextBox runat="server" TextMode="Email" ID="username" tabindex="1" CssClass="form-control" placeholder="E-mail" value=""></asp:TextBox>
									</div>
									<div class="form-group">
										<asp:TextBox runat="server" TextMode="Password" ID="password" tabindex="2" class="form-control" placeholder="Senha"></asp:TextBox>
									</div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-6 col-sm-offset-3">
												<asp:Button runat="server" ID="login_submit" tabindex="4" CssClass="form-control btn btn-login" Text="Acessar" />
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

                                <%-- Form de Registrar Usuário --%>
								<div id="register-form" role="form" style="display: none;">
									<div class="form-group">
										<asp:TextBox runat="server" ID="registername" tabindex="1" CssClass="form-control" placeholder="E-mail" ></asp:TextBox>
									</div>
									<div class="form-group">
										<asp:TextBox runat="server" ID="registerpassword" tabindex="2" CssClass="form-control" placeholder="Senha"></asp:TextBox>
									</div>
									<div class="form-group">
										<asp:TextBox runat="server" ID="confirm_password" tabindex="2" CssClass="form-control" placeholder="Confirmar Senha"></asp:TextBox>
									</div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-6 col-sm-offset-3">
												<asp:Button runat="server" ID="register_submit" tabindex="4" CssClass="form-control btn btn-register" Text="Registrar" />
											</div>
										</div>
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
