using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using SaaS_App.Entidades;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SaaS_App.Forms
{
    public partial class Relatorios : System.Web.UI.Page
    {
        Conn.Conexao Db = new Conn.Conexao();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Bind Charts  
                BindChart();
            }
        }

        private void BindChart()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = GetChartData();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Produto','Qtd.'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["Produto"] + "'," + row["Qtd."] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Gráfico de Produtos', vAxis: {title: ''},  hAxis: {title: ''}, seriesType: 'bars', series: {1: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");
                ltScripts.Text = strScript.ToString();
            }
            catch(Exception ex)        
            {
               string  test = ex.Message;
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        /// <summary>  
        /// fetch data from mdf file saved in app_data  
        /// </summary>  
        /// <returns>DataTable</returns>  
        private DataTable GetChartData()
        {
            DataSet dsData = new DataSet();        
            MySqlConnection Conexao = new MySqlConnection();
   

            try
            {
                Conexao = Db.GetConexao();
                MySqlDataAdapter Cmd = new MySqlDataAdapter("buscaresultados",Conexao);
                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Fill(dsData);
                Conexao.Close();

            }
            catch
            {
                return null;
            }
            finally
            {
                if (Conexao.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Close();
                }

            }
            return dsData.Tables[0];
        }

    }
}