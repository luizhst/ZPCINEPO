<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Cadastro-Veiculo.aspx.cs" Inherits="SaaS_App.Forms.Cadastro.Cadastro_Veiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        <br />
        <div class="col-md-12" style="border: unset">
            <div class="panel panel-info">

                <div class="panel-heading" style="border: unset">
                    <h4>VEÍCULOS</h4>
                </div>

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h4 class="box-title">Cadastrar Veículos de Transportadora</h4>
                            <hr>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Placa do Veículo</label>
                                        <asp:TextBox runat="server" required="true" ID="txt_Num_Implacacao" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block">XXX-9999</span>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Transportadora</label>
                                        <asp:DropDownList runat="server" required="true" ID="drplst_transportadora" MaxLength="150" CssClass="form-control"></asp:DropDownList>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Tipo Veículo</label>
                                        <asp:DropDownList runat="server" required="true" MaxLength="50" ID="drplst_Tipo" CssClass="form-control"></asp:DropDownList>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Marca/Modelo</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ID="txt_Descricao" CssClass="form-control"></asp:TextBox>
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
                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h4 class="box-title">Veículos Cadastrados</h4>
                            <hr>
                        </div>

                        <div>
                            <%--Tabela com os produtos cadastrados--%>
                            <asp:GridView ID="grid_veiculos" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Cod." ItemStyle-Width="10%">
                                        <ItemTemplate><%#Eval("iCod_Transporte") %> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Implacação" ItemStyle-Width="40%">
                                        <ItemTemplate><%#Eval("vNom_Transportadora") %> </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Implacação" ItemStyle-Width="40%">
                                        <ItemTemplate><%#Eval("vNom_Transportadora") %> </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Implacação" ItemStyle-Width="40%">
                                        <ItemTemplate><%#Eval("vNom_Transportadora") %> </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>


        </div>
    </div>

</asp:Content>
