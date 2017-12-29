Imports System.Web.Services
Imports System.Data
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    <WebMethod> _
    Public Shared Function GetDadosGrafico() As List(Of DadosDetalhes)
        Dim dt As New DataTable()
        Using con As New SqlConnection("Data Source=(LocalDB)\v11.0;Initial Catalog=Cadastro;Integrated Security=True")
            con.Open()
            Dim cmd As New SqlCommand("select nome, total=valor from DadosGrafico order by total desc", con)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            con.Close()
        End Using
        Dim listaDados As New List(Of DadosDetalhes)()
        For Each dtrow As DataRow In dt.Rows
            Dim details As New DadosDetalhes()
            details.NomePais = dtrow(0).ToString()
            details.Total = Convert.ToInt32(dtrow(1))
            listaDados.Add(details)
        Next
        Return listaDados
    End Function
End Class
Public Class DadosDetalhes
    Public Property NomePais() As String
    Public Property Total() As Integer
End Class


