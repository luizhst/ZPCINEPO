﻿<%@ Page Title="Pagina Principal" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="SaaS_App.Forms.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />

    <h4>Resultados de Hoje</h4>

    <hr />

    <%-- Cards de resultado --%>
    <div class="row">
        <div class="col-md-3 col-sm-6">
            <div class="white-box">
                <div class="r-icon-stats">
                    <i class="ti-check bg-megna"></i>
                    <div class="bodystate">
                        <h4>
                            <asp:Label ID="Lbl_CustoTotal" runat="server" Text="000"></asp:Label></h4>
                        <span class="text-muted">Custo Total Estoque</span>
                        <br />
                        <span class="text-muted"></span>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-3 col-sm-6">
            <div class="white-box">
                <div class="r-icon-stats">
                    <i class="ti-user bg-info"></i>
                    <div class="bodystate">
                        <h4>
                            <asp:Label ID="Lbl_ReceitaTotal" runat="server" Text="000"></asp:Label></h4>
                        <span class="text-muted">Receita Total Estoque</span>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-3 col-sm-6">
            <div class="white-box">
                <div class="r-icon-stats">
                    <i class="ti-time bg-success"></i>
                    <div class="bodystate">
                        <h4>
                            <asp:Label ID="Lbl_LucroBruto" runat="server" Text="000"></asp:Label></h4>
                        <span class="text-muted">Lucro Bruto</span>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-3 col-sm-6">
            <div class="white-box">
                <div class="r-icon-stats">
                    <i class="ti-microsoft bg-inverse"></i>
                    <div class="bodystate">
                        <h4>
                            <asp:Label ID="Lbl_TotalItens" runat="server" Text="000"></asp:Label></h4>
                        <span class="text-muted">Total Produtos Estoque</span>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- Fim Cards de Resultado --%>

    <br />

    <%-- Tabela de Saídas Hoje e Produtos Estoque Atual --%>
    <hr />

    <div class="row">

        <div class="col-md-6">

            <h4>Produtos Cadastrados</h4>

            <%--Tabela com os produtos cadastrados--%>
            <asp:GridView ID="grid_produtos" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server" AllowPaging="False" PagerSettings-Mode="NextPrevious" PageSize="5" PagerSettings-PageButtonCount="5">

                <Columns>
                    <asp:TemplateField HeaderText="Cod." ItemStyle-Width="10%">
                        <ItemTemplate><%#Eval("iCod_Produto") %> </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nome" ItemStyle-Width="40%">
                        <ItemTemplate><%#Eval("vNom_Produto") %> </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estoque" ItemStyle-Width="15%">
                        <ItemTemplate><%#Eval("vQtd_Estoque") %> </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>

        </div>


        <div class="col-md-6">

            <h4>Produtos Cadastrados 2</h4>

            <%--Tabela com os produtos cadastrados--%>
            <asp:GridView ID="GridView1" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

                <Columns>
                    <asp:TemplateField HeaderText="Cod." ItemStyle-Width="10%">
                        <ItemTemplate><%#Eval("iCod_Produto") %> </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nome" ItemStyle-Width="40%">
                        <ItemTemplate><%#Eval("vNom_Produto") %> </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estoque" ItemStyle-Width="15%">
                        <ItemTemplate><%#Eval("vQtd_Estoque") %> </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>

        </div>

    </div>

    <br />

    <div class="row">
        <h4>Ultimas Saidas</h4>

        <%--Tabela com os produtos cadastrados--%>
        <asp:GridView ID="GridSaidas" CssClass="tablesaw table-striped table-hover table-bordered table" AutoGenerateColumns="False" runat="server">

            <Columns>
                <asp:TemplateField HeaderText="Cod." ItemStyle-Width="10%">
                    <ItemTemplate><%#Eval("iCod_Produto.vNom_Produto") %> </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nome" ItemStyle-Width="40%">
                    <ItemTemplate><%#Eval("vQtd_EstoqueAnt") %> </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Estoque" ItemStyle-Width="25%">
                    <ItemTemplate><%#Eval("vQtd_Saida") %> </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Estoque" ItemStyle-Width="25%">
                    <ItemTemplate><%#Eval("vQtd_EstoqueAtual") %> </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>

        </asp:GridView>


    </div>


    <%-- Fim Tabela de Saídas Hoje e Produtos Estoque Atual --%>
</asp:Content>
