using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaaS_App.Entidades;
using SaaS_App.BLL;
using SaaS_App.DAL;

namespace SaaS_App.Forms.Saida
{
    public partial class Saida_Produto : System.Web.UI.Page
    {
        string ID_USUARIO;

        Func_Global Pub = new Func_Global();
        Tb_Transportadora_BO Transporte_BO = new Tb_Transportadora_BO();

        List<Tb_Produto> produtos = new List<Tb_Produto>();
        List<Tb_Produto> produtos2 = new List<Tb_Produto>();
        Tb_Produto_BO ProdutoBO = new Tb_Produto_BO();


        protected void Page_Load(object sender, EventArgs e)
        {

            //Pega a conta logada para usar como parâmetro global
            try
            {
                ID_USUARIO = Session["ID_USUARIO"].ToString();
                produtos = ProdutoBO.Buscar_Produtos(ID_USUARIO);

            }
            catch (Exception)
            {
                Response.Redirect("~/Forms/Sair.aspx");
            }

            if (!IsPostBack)
            {
                CarregaProdutosDrop();
            }

        }

        public void CarregaProdutosDrop()
        {

            Drop_Produtos.Items.Clear();

            Drop_Produtos.DataSource = produtos;
            Drop_Produtos.DataValueField = "vNom_Produto";
            Drop_Produtos.DataTextField = "vNom_Produto";
            Drop_Produtos.DataBind();

            Drop_Produtos.SelectedIndex = -1;

        }

        protected void Drop_Produtos_TextChanged(object sender, EventArgs e)
        {

            if (Drop_Produtos.SelectedItem.Text != "")
            {
                txt_QtdEstoque.Text = "";
                SelecionaProduto(Drop_Produtos.SelectedItem.Text);
            }

        }

        private void SelecionaProduto(string produto)
        {
            try
            {
                Tb_Produto Obj = new Tb_Produto();
                Obj = produtos.Where(x => x.vNom_Produto == produto).FirstOrDefault();
                txt_QtdEstoque.Text = Obj.vQtd_Estoque;
            }
            catch (Exception)
            {

            }

        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {
            IncluirAlteracao();
        }

        private void IncluirAlteracao()
        {
            if ((txt_QtdeProduto.Text.Trim()).Equals(""))
            {
                ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning('Informe a quantidade de saída do produto!');", true);
            }
            else
            {
                Tb_Produto Obj = new Tb_Produto();
                Obj = produtos.Where(x => x.vNom_Produto == Drop_Produtos.SelectedItem.Text).FirstOrDefault();
                string Quantidade = txt_QtdeProduto.Text;

                if (Convert.ToInt32(Quantidade) > Convert.ToInt32(Obj.vQtd_Estoque))
                {
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning('A quantidade de saída é maio do que a quantidade em estoque!');", true);
                }
                else
                {

                    Tb_Saida Saida = new Tb_Saida();
                    Saida.iCod_Conta = new Tb_Conta();
                    Saida.iCod_Produto = new Tb_Produto();

                    Saida.dData_Saida = DateTime.Now;
                    Saida.iCod_Conta.iCod_Conta = Convert.ToInt32(ID_USUARIO);
                    Saida.iCod_Produto.iCod_Produto = Obj.iCod_Produto;
                    Saida.vQtd_EstoqueAnt = Obj.vQtd_Estoque;
                    Saida.vQtd_Saida = Quantidade;
                    Saida.vQtd_EstoqueAtual = Convert.ToString(Convert.ToInt32(Obj.vQtd_Estoque) - Convert.ToInt32(Quantidade));

                    Obj.vQtd_Estoque = Saida.vQtd_EstoqueAtual;

                    ProdutoBO.SaidaProduto(Obj, Saida);

                    string vStrWarning = "'Estoque atualizado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Sucesso(" + vStrWarning + ");", true);
                    
                    txt_QtdeProduto.Text = "";
                    txt_QtdEstoque.Text = "";
                    Drop_Produtos.SelectedIndex = -1;

                }
            }
        }



        ///Fim da Classe
    }
}