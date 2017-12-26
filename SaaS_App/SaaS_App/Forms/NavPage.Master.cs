using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaaS_App.BLL;

namespace SaaS_App.Forms
{
    public partial class NavPage : System.Web.UI.MasterPage
    {

        string Nom_Conta;
        Func_Global Pub = new Func_Global();

        protected void Page_Load(object sender, EventArgs e)
        {

            Valida_Login();

        }

        /// <summary>
        /// Faz a validação se existe sessão ativa no momento do load
        /// </summary>
        public void Valida_Login()
        {
            string Conta = Session["ID_USUARIO"].ToString();

            if (Conta == null)
            {
                Response.Redirect("~/Forms/Sair.aspx");
            }
            
            Nom_Conta = Pub.DeCifraTexto(Session["NOME_USUARIO"].ToString());


        }

    }
}