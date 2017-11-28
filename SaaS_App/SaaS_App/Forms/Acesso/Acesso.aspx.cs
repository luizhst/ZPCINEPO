using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace SaaS_App.Forms
{
    public partial class Acesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_submit_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            Conn.Conexao Connect = new Conn.Conexao();
            conn = Connect.GetConexao();
        }
    }
}