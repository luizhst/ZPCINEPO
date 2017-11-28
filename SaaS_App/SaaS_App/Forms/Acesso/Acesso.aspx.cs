using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using SaaS_App.Entidades;
using SaaS_App.DAL;

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

        protected void register_submit_Click(object sender, EventArgs e)
        {
            Tb_Conta Obj = new Tb_Conta();
            Obj.vDes_Login = registername.Text;
            Obj.vDes_Senha = registerpassword.Text;
            Tb_Conta_DAO DAO = new Tb_Conta_DAO();
            DAO.Insert(Obj);
        }
    }
}