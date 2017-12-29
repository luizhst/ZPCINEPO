<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>jQuery Grafico de Pizza Google com asp.net</title>
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://www.google.com/jsapi" type="text/javascript"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Default.aspx/GetDadosGrafico',
                data: '{}',
                success:
                    function (response) {
                        drawchart(response.d);
                    },

                error: function () {
                    alert("Erro ao carregar dados! Tente novamente.");
                }
            });
        })
        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Paises');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].NomePais, dataValues[i].Total]);
            }
            new google.visualization.LineChart(document.getElementById('chartdiv')).
                draw(data, { title: "JcmSoft - Participação Mercado por País" });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Macoratti .net</h2>
        <hr />
        <div id="chartdiv" style="width: 600px; height: 350px;">
        </div>
    </form>
</body>
</html>
