<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/NavPage.Master" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="SaaS_App.Forms.Relatorios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />

    <h4>Gráficos</h4>

    <hr />

    <%-- Cards de resultado --%>
    <div class="row">
        <div class="col-md-6 col-sm-6"> 
            <div>     
                    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>  
                    <div id="chart_div" style="height: 400px;">  
                    </div>  
            </div>  
        </div>

<%--        <div class="col-md-3 col-sm-6"> 
            <div>     
                    <asp:Literal ID="ltScripts2" runat="server"></asp:Literal>  
                    <div id="chart_div2" style="width: 660px; height: 400px;">  
                    </div>  
            </div>  
        </div>--%>
    </div>


</asp:Content>
