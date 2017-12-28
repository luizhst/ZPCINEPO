using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaaS_App.Entidades;
using SaaS_App.BLL;

namespace SaaS_App.Forms.Cadastro
{
    public partial class Lista_Produtos : System.Web.UI.Page
    {

        string ID_USUARIO;
        //string ID_EMPRESA;

        Func_Global Pub = new Func_Global();
        Tb_Produto_BO Produto_BO = new Tb_Produto_BO();

        protected void Page_Load(object sender, EventArgs e)
        {

            //Pega a conta logada para usar como parâmetro global
            try
            {
                ID_USUARIO = Session["ID_USUARIO"].ToString();
                Carrega_Produtos();
            }
            catch (Exception)
            {
                Response.Redirect("~/Forms/Sair.aspx");
            }            

        }

        public void Carrega_Produtos()
        {

            List<Tb_Produto> produtos = new List<Tb_Produto>();

            produtos = Produto_BO.Buscar_Produtos(ID_USUARIO);

            grid_produtos.DataSource = null;
            grid_produtos.DataSource = produtos;

            grid_produtos.DataBind();

        }

        protected void grid_produtos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_produtos.PageIndex = e.NewPageIndex;
            grid_produtos.DataBind();
        }
    }
}