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
            //Aqui vai a função de logar

        }
        protected void BtnProximoPasso_Click(object sender, EventArgs e)
        {
         ScriptManager.RegisterStartupScript(this, GetType(), "MoveNext", "ProximaEtapa(e);", true);
        }
    }
}