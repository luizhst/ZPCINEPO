<%@ Page Title="Lançamento de Entrada" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Entrada-Produto.aspx.cs" Inherits="SaaS_App.Forms.Saida.Entrada_Produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <br />
        <br />
        <br />
        <div class="col-md-12" style="border: unset">
            <div class="panel panel-info">

                <div class="panel-heading" style="border: unset">
                    <h4>ENTRADA DE PRODUTOS</h4>
                </div>

                <div class="panel-wrapper collapse in" aria-expanded="false">

                    <div class="panel-body">

                        <div class="form-body">
                            <h4 class="box-title">Lançar Entrada</h4>
                            <hr>
                        </div>

                        <div class="form-body">



                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-6">Produto</label>
                                        <asp:DropDownList ID="Drop_Produtos" AutoPostBack="true" runat="server" MaxLength="150" OnTextChanged="Drop_Produtos_TextChanged" CssClass="form-control"></asp:DropDownList>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-6">Quantidade estoque</label>
                                        <%--<asp:TextBox runat="server" required="true" ID="txt_QtdEstoque" ReadOnly="true" MaxLength="150" CssClass="form-control"></asp:TextBox>--%>
                                        <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox runat="server" required="true" ID="txt_QtdEstoque" ReadOnly="true" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Drop_Produtos" EventName="TextChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-6">Quantidade Entrada</label>
                                        <asp:TextBox runat="server" required="true" ID="txt_QtdeProduto" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Registrar" OnClick="btn_Registrar_Click" Text="Confirmar Lançamento" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
