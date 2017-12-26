using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaaS_App.BLL;
using SaaS_App.DAL;
using SaaS_App.Entidades;


namespace SaaS_App.Forms
{
    public partial class Principal : System.Web.UI.Page
    {

        string ID_USUARIO;
        string ID_EMPRESA;

        Func_Global Pub = new Func_Global();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Pega a conta logada para usar como parâmetro global
            try
            {
                ID_USUARIO = Session["ID_USUARIO"].ToString();
            }
            catch (Exception)
            {
                Response.Redirect("~/Forms/Sair.aspx");
            }
            
            //Caso já tenha sido verificado o ID_EMPRESA, não há necessidade de ficar verificando a cada load da pagina principal
            if(ID_EMPRESA == null)
            {
                Verifica_Empresa();
            }

            //Atualiza todas as informações da página principal
            Atualiza_Indicadores();
            
        }

        /// <summary>
        /// Verifica se a conta logada já possui uma empresa cadastrada
        /// </summary>
        private void Verifica_Empresa()
        {

            //Consulta empresa no BD
            ID_EMPRESA = Pub.Verifica_Cad_Empresa(ID_USUARIO);
            Session["EMPRESA"] = ID_EMPRESA;

            //Se não houver empresa cadastrada para aquela conta, sempre redireciona para a tela de cadastro de empresa
            if (ID_EMPRESA == "0")
            {
                Response.Redirect("~/Forms/Cadastro/Cadastro-Empresa.aspx");
            }
                        
        }


        private void Atualiza_Indicadores()
        {

            List<Tb_Produto> Lista = new List<Tb_Produto>();
            Tb_Produto_BO Produto_BO = new Tb_Produto_BO();
            Lista = Produto_BO.Buscar_Produtos(ID_USUARIO);
            grid_produtos.DataSource = Lista;
            grid_produtos.DataBind();

            GridView1.DataSource = Lista;
            GridView1.DataBind();

        }
    }
}