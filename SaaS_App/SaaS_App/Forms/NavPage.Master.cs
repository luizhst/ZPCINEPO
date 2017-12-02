﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaaS_App.Forms
{
    public partial class NavPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Valida_Login();

        }

        public void Valida_Login()
        {
            string Conta = Session["ID_USUARIO"].ToString();

            if (Conta == null)
            {
                Encerrar_Sessao();
            }

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