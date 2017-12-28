<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Cadastro-Transportadora.aspx.cs" Inherits="SaaS_App.Forms.Cadastro.Cadastro_Transportadora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        <br />
        <div class="col-md-12" style="border: unset">
            <div class="panel panel-info">

                <div class="panel-heading" style="border: unset">
                    <h4>TRANSPORTADORA</h4>
                </div>

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h4 class="box-title">Cadastrar uma nova transportadora</h4>
                            <hr>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Nome da Transportadora</label>
                                        <asp:TextBox runat="server" required="true" ID="txt_NomeTransportadora" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label class="control-label col-md-5">Telefone 1</label>
                                    <asp:TextBox runat="server" ID="txt_telefone1" ClientIDMode="Static" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                    <span class="help-block"></span>
                                </div>
                                <div class="col-md-6">
                                    <label class="control-label col-md-5">Telefone 2</label>
                                    <asp:TextBox runat="server" ID="txt_telefone2" ClientIDMode="Static" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                    <span class="help-block"></span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="control-label col-md-5">Telefone 3</label>
                                    <asp:TextBox runat="server" ID="txt_telefone3" ClientIDMode="Static" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                    <span class="help-block"></span>
                                </div>
                                <div class="col-md-6">
                                    <label class="control-label col-md-5">Telefone 4</label>
                                    <asp:TextBox runat="server" ID="txt_telefone4" ClientIDMode="Static" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                    <span class="help-block"></span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Observação</label>
                                        <asp:TextBox runat="server" MaxLength="50" ID="txt_Observacao" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>
                            <br />

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
