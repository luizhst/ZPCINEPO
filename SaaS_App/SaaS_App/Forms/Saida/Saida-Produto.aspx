<%@ Page Title="Lançamento de Saída" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Saida-Produto.aspx.cs" Inherits="SaaS_App.Forms.Saida.Saida_Produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        <br />
        <div class="col-md-12" style="border: unset">
            <div class="panel panel-info">

                <div class="panel-heading" style="border: unset">
                    <h4>SAÍDA DE PRODUTOS</h4>
                </div>

                <div class="panel-wrapper collapse in" aria-expanded="false">

                    <div class="panel-body">

                        <div class="form-body">
                            <h4 class="box-title">Lançar Saída</h4>
                            <hr>
                        </div>

                        <div class="form-body">

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-6">Produto</label>
                                        <asp:DropDownList ID="Drop_Produtos" runat="server" MaxLength="150" CssClass="form-control"></asp:DropDownList>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-6">Quantidade estoque</label>
                                        <asp:TextBox runat="server" required="true" ID="txt_QtdEstoque" ReadOnly="true" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-6">Quantidade saída</label>
                                        <asp:TextBox runat="server" required="true" ID="txt_QtdeProduto" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Registrar" Text="Adicionar" />
                            </div>

                        </div>
                    </div>
                    <%-- Produtos a serem atualizados --%>

                    <div class="panel-wrapper collapse in" aria-expanded="false">
                        <div class="panel-body">

                            <div class="form-body">
                                <h4 class="box-title">Lista de Saída de Produtos</h4>
                                <hr>
                            </div>

                            <div class="form-body">


                                <br />
                                <div>
                                    <asp:Button runat="server" CssClass="btn btn-success" ID="btn_ConfirmarLancamentos" Text="Confirmar Lancamentos" />
                                </div>

                            </div>



                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
