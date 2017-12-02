<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Cadastro-Empresa.aspx.cs" Inherits="SaaS_App.Forms.Cadastro_Empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div id="empresa-form" class="panel-body" role="form">
      <h3 class="box-title">Informações Empresa</h3>
                                <hr />
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
                            <h3 class="box-title">Contato</h3>
                                    <hr />
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
                                        <h3 class="box-title">Endereço</h3>
                                        <hr />
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
</asp:Content>
