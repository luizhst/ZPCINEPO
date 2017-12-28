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
        List<Tb_Categoria_Produto> lista = new List<Tb_Categoria_Produto>();

        protected void Page_Load(object sender, EventArgs e)
        {

            //Pega a conta logada para usar como parâmetro global
            try
            {
                ID_USUARIO = Session["ID_USUARIO"].ToString();
                Preencher_DropList();
            }
            catch (Exception)
            {
                Response.Redirect("~/Forms/Sair.aspx");
            }


        }

        /// <summary>
        /// Atualiza a lista de produtos na página
        /// </summary>


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

                Tb_Categoria_Produto Categoria = new Tb_Categoria_Produto();
                string test = drplstCategoriaProduto.SelectedItem.Text;
                Categoria = lista.Where(x => x.vNom_Categoria == drplstCategoriaProduto.SelectedItem.Text).FirstOrDefault();
                Obj.iCod_Categoria = Categoria.iCod_Categoria;
                string retorno = Produto_BO.Valida_Produto(Obj);

                if (retorno == "1")
                {
                    string vStrSuccess = "'Produto cadastrado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Sucesso(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Response.Redirect("~/Forms/Cadastro/Lista-Produtos.aspx");
                    
                }
                else if (retorno == "2")
                {
                    string vStrSuccess = "'Produto atualizado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Sucesso(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Response.Redirect("~/Forms/Cadastro/Lista-Produtos.aspx");

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

        public void Preencher_DropList()
        {

            LimpaDropList();
            List<Tb_Categoria_Produto> lista = new List<Tb_Categoria_Produto>();
            Tb_Categoria_Produto_BO CategoriaBO = new Tb_Categoria_Produto_BO();
            lista = CategoriaBO.Buscar_Categoria_Produto();

            foreach (var item in lista)
            {
                drplstCategoriaProduto.Items.Add(item.vNom_Categoria);
            }
        }

        public void LimpaDropList()
        {
            drplstCategoriaProduto.Items.Clear();
            drplstCategoriaProduto.Items.Add("Definir");
        }

    }
}