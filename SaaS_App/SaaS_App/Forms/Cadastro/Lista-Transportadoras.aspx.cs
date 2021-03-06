﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaaS_App.Entidades;
using SaaS_App.BLL;
using SaaS_App.DAL;

namespace SaaS_App.Forms.Cadastro
{
    public partial class Lista_Transportadoras : System.Web.UI.Page
    {

        string ID_USUARIO;

        Func_Global Pub = new Func_Global();
        Tb_Transportadora_BO Transportadores_BO = new Tb_Transportadora_BO();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ID_USUARIO = Session["ID_USUARIO"].ToString();
                Carregar_Transportadores();
            }
            catch (Exception)
            {
                Response.Redirect("~/Forms/Sair.aspx");
            }

        }

        /// <summary>
        /// Atualiza a lista de produtos na página
        /// </summary>
        public void Carregar_Transportadores()
        {

            List<Tb_Transportadora> transportadores = new List<Tb_Transportadora>();

            transportadores = Transportadores_BO.Buscar_Transporte(ID_USUARIO);
            grid_transportadores.DataSource = null;
            grid_transportadores.DataSource = transportadores;
            grid_transportadores.DataBind();

        }

        protected void grid_transportadores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_transportadores.PageIndex = e.NewPageIndex;
            grid_transportadores.DataBind();

        }

        protected void BtnExcluirTransporte_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton button = sender as ImageButton;
            string Transporte = Convert.ToString(button.CommandArgument);
            Tb_Transportadora_DAO DAO = new Tb_Transportadora_DAO();
            DAO.Delete(Transporte);
            Carregar_Transportadores();
        }
    }
}