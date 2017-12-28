<%@ Page Title="Transportadoras" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Lista-Transportadoras.aspx.cs" Inherits="SaaS_App.Forms.Cadastro.Lista_Transportadoras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <br />
        <br />
        <br />
        <div class="col-md-12" style="border: unset">
            <div class="panel panel-info">

                <div class="panel-heading" style="border: unset">
                    <h4>TRANSPORTADORAS</h4>
                </div>

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h4 class="box-title">Transportadores Cadastrados</h4>
                            <hr>
                        </div>

                        <div>
                            <%--Tabela com os produtos cadastrados--%>
                            <asp:GridView ID="grid_transportadores" CssClass="tablesaw table-striped table-hover table-bordered table" PageSize="1" OnPageIndexChanging="grid_transportadores_PageIndexChanging" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="False" runat="server">

                                <Columns>
                                    <asp:TemplateField HeaderText="Cod." ItemStyle-Width="10%">
                                        <ItemTemplate><%#Eval("iCod_Transportadora") %> </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nome" ItemStyle-Width="50%">
                                        <ItemTemplate><%#Eval("vNom_Transportadora") %> </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Telefone 1" ItemStyle-Width="10%">
                                        <ItemTemplate><%#Eval("vTelefone1") %> </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Telefone 2" ItemStyle-Width="10%">
                                        <ItemTemplate><%#Eval("vTelefone2") %> </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Telefone 3" ItemStyle-Width="10%">
                                        <ItemTemplate><%#Eval("vTelefone3") %> </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Telefone 4" ItemStyle-Width="10%">
                                        <ItemTemplate><%#Eval("vTelefone4") %> </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                            <a href="Cadastro-Transportadora.aspx">Cadastrar Transportadora</a>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
