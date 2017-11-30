using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using SaaS_App.Entidades;
using SaaS_App.DAL;
using SaaS_App.BLL;

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


        protected void BtnProximoPasso_Click(object sender, EventArgs e)
        {
            Tb_Conta_BO BO = new Tb_Conta_BO();
            string usuario = registername.Text;
            string senha = registerpassword.Text;
            bool vStatusCadastro = BO.InputCadastro(usuario, senha);
            if (vStatusCadastro == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MoveNext", "ProximaEtapa()", true);
            }
                ScriptManager.RegisterStartupScript(this, GetType(), "MoveNext", "ProximaEtapa()", true);
        }
    }
}