<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Forms/NavPage.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Lista-Produtos.aspx.cs" Inherits="SaaS_App.Forms.Cadastro.Lista_Produtos" %>

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
                            <h4 class="box-title">Produtos Cadastrados</h4>
                            <hr>
                        </div>

                        <div>
                            <%--Tabela com os produtos cadastrados--%>
                            <asp:GridView ID="grid_produtos"  OnPageIndexChanging="grid_produtos_PageIndexChanging" ClientIDMode="Static" AllowPaging="true" AllowSorting="true" PageSize="10" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">
                               
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"> 
                                        <ItemTemplate>                        
                                            <asp:ImageButton ID="BtnExcluirProduto" CommandArgument='<%#Bind("iCod_Produto")%>' OnClick="BtnExcluirProduto_Click"  CssClass="mimg" runat="server" Width= "20px" Height="20px" ImageUrl="https://www.shareicon.net/data/2015/05/04/33380_trash_256x256.png"/>
                                        </ItemTemplate>
                                        <HeaderTemplate> Excluir </HeaderTemplate>
                                    </asp:TemplateField>   

                                    <asp:TemplateField HeaderText="Cod." ItemStyle-Width="10%">
                                        <ItemTemplate><%#Eval("iCod_Produto") %> </ItemTemplate>
                                    </asp:TemplateField>                                

                                    <asp:TemplateField HeaderText="Nome" ItemStyle-Width="40%">
                                        <ItemTemplate><%#Eval("vNom_Produto") %> </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Valor Custo" ItemStyle-Width="10%">
                                        <ItemTemplate>R$ <%#Eval("dPreco_Custo") %> </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Valor Venda" ItemStyle-Width="10%">
                                        <ItemTemplate>R$ <%#Eval("dPreco_Venda") %> </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total em Estoque" ItemStyle-Width="15%">
                                        <ItemTemplate><%#Eval("vQtd_Estoque") %> </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Estoque Minimo" ItemStyle-Width="15%">
                                        <ItemTemplate><%#Eval("vQtd_Min_Estoque") %> </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                            <a href="Cadastro-Produto.aspx">Cadastrar Produto</a>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
