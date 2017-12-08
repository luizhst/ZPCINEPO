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
    public partial class Cadastro_Veiculo : System.Web.UI.Page
    {

        string ID_USUARIO;
        string ID_TRANSPORTADORA;

        Func_Global Pub = new Func_Global();
        Tb_Veiculo_BO Veiculo_BO = new Tb_Veiculo_BO();

        protected void Page_Load(object sender, EventArgs e)
        {

            //Pega a conta logada para usar como parâmetro global
            try
            {
                ID_USUARIO = Session["ID_USUARIO"].ToString();
                Carregar_Veiculos();
            }
            catch (Exception)
            {
                Response.Redirect("~/Forms/Sair.aspx");
            }


        }

        /// <summary>
        /// Atualiza a lista de produtos na página
        /// </summary>
        public void Carregar_Veiculos()
        {

            List<Tb_Veiculo> veiculos = new List<Tb_Veiculo>();

            veiculos = Veiculo_BO.Buscar_Veiculo(ID_TRANSPORTADORA);            
            grid_veiculos.DataSource = null;
            grid_veiculos.DataSource = veiculos;
            grid_veiculos.DataBind();

        }

        public void Limpa_Campos()
        {
            txt_Descricao.Text = "";
            txt_Num_Implacacao.Text = "";

        }


        protected void btn_Registrar_Click(object sender, EventArgs e)
        {

            try
            {

                Tb_Veiculo Obj = new Tb_Veiculo();
                Obj.vNum_Implacacao = txt_Num_Implacacao.Text;
                Obj.vTipo_Veiculo = drplst_Tipo.Text;
                Obj.iCod_Transportadora = Busca_Cod_Transportadora(drplst_transportadora.Text);
                Obj.vDes_Veiculo = txt_Descricao.Text;

                string retorno;
                retorno = Veiculo_BO.Valida_Veiculo(Obj);

                if (retorno == "1")
                {
                    string vStrSuccess = "'Veículo cadastrado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Sucesso(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Carregar_Veiculos();
                }
                else if (retorno == "2")
                {
                    string vStrSuccess = "'Veículo atualizado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Sucesso(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Carregar_Veiculos();

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

        public int Busca_Cod_Transportadora(String vNom_Transportadora)
        {
            return 1;
        }

        public void Preenche_DropList()
        {
              // Preencher DropLists
        }
        public void Limpar_Drop_List()
        {
            drplst_Tipo.Items.Clear();
            drplst_Tipo.Items.Add("Definir");
            drplst_transportadora.Items.Clear();
            drplst_transportadora.Items.Add("Definir");
        }
    }
}