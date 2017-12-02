using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace SaaS_App.Forms
{
    public partial class Sair : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Encerrar_Sessao();
        }

        public void Encerrar_Sessao()
        {

            try
            {
                Session["ID_USUARIO"] = null;
                Session["EMPRESA"] = null;
            }
            catch (Exception)
            {
                throw;
            }

            Response.Redirect("~/Forms/Acesso/Acesso.aspx");

        }
    }
}