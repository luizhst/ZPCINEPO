<%@ Page Title="Cadastro Empresa" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Cadastro-Empresa.aspx.cs" Inherits="SaaS_App.Forms.Cadastro_Empresa" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        <br />
        <div class="col-md-12" style="border:unset">
            <div class="panel panel-info">

                <div class="panel-heading" style="border:unset">
                    <h4>SOBRE VOCÊ</h4>
                </div>

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h4 class="box-title">Atualizar informações sobre a empresa</h4>
                            <hr>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Empresa</label>
                                        <asp:TextBox runat="server" ID="txt_Empresa" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">Razão Social ou Nome Fantasia</span>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Responsável</label>
                                        <asp:TextBox runat="server" MaxLength="50" ID="txt_Responsavel" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">Ponto Focal</span>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">CNPJ</label>
                                        <asp:TextBox runat="server" MaxLength="50" ID="txt_CpfCnpj" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">CPF ou CNPJ Sem Pontuação</span>
                                    </div>
                                </div>
                            </div>
                            <h3 class="box-title">Contato</h3>
                            <hr />
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-8">Comercial</label>
                                        <asp:TextBox runat="server" MaxLength="50" ID="txt_Fone1" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">(99) 9999-9999</span>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Celular</label>
                                        <asp:TextBox runat="server" MaxLength="50" ID="txt_Fone2" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">(99) 99999-9999</span>
                                    </div>
                                </div>
                            </div>
                            <h3 class="box-title">Endereço</h3>
                            <hr />
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">CEP</label>
                                        <asp:TextBox runat="server" MaxLength="50" ID="txt_Cep" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">00000-000</span>
                                    </div>
                                </div>

                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Endereço</label>
                                        <asp:TextBox runat="server" MaxLength="50" ID="txt_Rua" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">Ex.: Avenia, Rua...</span>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Cidade</label>
                                        <asp:TextBox runat="server" MaxLength="50" ID="txt_Cidade" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">Sua Cidade</span>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Estado/UF</label>
                                        <asp:TextBox runat="server" MaxLength="50" ID="txt_Uf" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">Ex.: MG</span>
                                    </div>
                                </div>
                            </div>

                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="BtnRegistrar" Text="Cadastrar e Continuar" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
