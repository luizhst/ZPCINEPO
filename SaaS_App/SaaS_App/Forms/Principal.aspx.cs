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
            if (ID_EMPRESA == null)
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
            grid_produtos.DataSource = Lista.OrderByDescending(x => Convert.ToInt32(x.vQtd_Estoque)).ToList();
            grid_produtos.DataBind();


            List<Tb_Saida> Lancamentos = new List<Tb_Saida>();
            Tb_Saida_BO Saida_BO = new Tb_Saida_BO();
            Lancamentos = Saida_BO.Buscar_Saidas(ID_USUARIO);

            List<Tb_Saida> LancamentosEntrada = new List<Tb_Saida>();
            List<Tb_Saida> LancamentosSaida = new List<Tb_Saida>();

            LancamentosEntrada = Lancamentos.Where(x => x.bFlag_Entrada == true).ToList();
            LancamentosSaida = Lancamentos.Where(x => x.bFlag_Entrada == false).ToList();

            GridSaidas.DataSource = LancamentosSaida.Take(5);
            GridSaidas.DataBind();

            GridEntradas.DataSource = LancamentosEntrada.Take(5);
            GridEntradas.DataBind();
            
            double TotalCusto = 0;
            double TotalReceita = 0;

            for (int item = 0; item <= Lista.Count - 1; item++)
            {
                TotalCusto = TotalCusto + (Convert.ToInt32(Lista[item].vQtd_Estoque) * Convert.ToDouble(Lista[item].dPreco_Custo));
                TotalReceita = TotalReceita + (Convert.ToInt32(Lista[item].vQtd_Estoque) * Convert.ToDouble(Lista[item].dPreco_Venda));
            }

            Lbl_CustoTotal.Text = TotalCusto.ToString("C");
            Lbl_ReceitaTotal.Text = TotalReceita.ToString("C");

            var LucroBruto = Convert.ToDouble(TotalReceita) - Convert.ToDouble(TotalCusto);
            Lbl_LucroBruto.Text = LucroBruto.ToString("C");

            var TotalItens = Lista.Sum(x => Convert.ToInt32(x.vQtd_Estoque));
            Lbl_TotalItens.Text = TotalItens.ToString("n0");

            
        }
    }
}