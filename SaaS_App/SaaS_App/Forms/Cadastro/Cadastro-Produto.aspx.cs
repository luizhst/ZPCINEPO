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
    public partial class Cadastro_Produto : System.Web.UI.Page
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

        /// <summary>
        /// Atualiza a lista de produtos na página
        /// </summary>
        public void Carrega_Produtos()
        {

            List<Tb_Produto> produtos = new List<Tb_Produto>();

            produtos = Produto_BO.Buscar_Produtos(ID_USUARIO);
            
            grid_produtos.DataSource = null;
            grid_produtos.DataSource = produtos;

            grid_produtos.DataBind();

        }

        public void Limpa_Campos()
        {
            txt_NomProduto.Text = "";
            txt_PrecoCusto.Text = "";
            txt_PrecoVenda.Text = "";
            txt_QtdEstoque.Text = "";
            txt_QtdMinEstoque.Text = "";

        }


        protected void btn_Registrar_Click(object sender, EventArgs e)
        {

            try
            {

                Tb_Produto Obj = new Tb_Produto();

                Obj.iCod_Conta = Convert.ToInt32(ID_USUARIO);
                Obj.vNom_Produto = txt_NomProduto.Text;
                Obj.dPreco_Custo = Convert.ToDouble(txt_PrecoCusto.Text);
                Obj.dPreco_Venda = Convert.ToDouble(txt_PrecoVenda.Text);
                Obj.vQtd_Estoque = txt_QtdEstoque.Text;
                Obj.vQtd_Min_Estoque = txt_QtdMinEstoque.Text;
                Obj.dData_Cadastro = Convert.ToDateTime(DateTime.Now);

                string retorno;
                
                retorno = Produto_BO.Valida_Produto(Obj);

                if (retorno == "1")
                {
                    string vStrSuccess = "'Produto cadastrado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Carrega_Produtos();
                }
                else if (retorno == "2")
                {
                    string vStrSuccess = "'Produto atualizado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Carrega_Produtos();

                }
                else
                {
                    string vStrWarning = "'" + retorno + "'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrWarning + ");", true);
                }


            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}