<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Cadastro-Produto.aspx.cs" Inherits="SaaS_App.Forms.Cadastro.Cadastro_Produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        <br />
        <div class="col-md-12" style="border: unset">
            <div class="panel panel-info">

                <div class="panel-heading" style="border: unset">
                    <h4>PRODUTOS</h4>
                </div>

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h4 class="box-title">Cadastrar um novo produto</h4>
                            <hr>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Nome do Produto</label>
                                        <asp:TextBox runat="server" required="true" ID="txt_NomProduto" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Preço Custo</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_PrecoCusto" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Preço Venda</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_PrecoVenda" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Quantidade em Estoque</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ID="txt_QtdEstoque" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Minimo em Estoque</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ID="txt_QtdMinEstoque" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <br />
                            </div>

                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Registrar" OnClick="btn_Registrar_Click" Text="Cadastrar" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>


        </div>
    </div>

</asp:Content>
