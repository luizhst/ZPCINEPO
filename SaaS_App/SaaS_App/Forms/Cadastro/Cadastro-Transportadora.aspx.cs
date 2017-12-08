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
    public partial class Cadastro_Transportadora : System.Web.UI.Page
    {

        string ID_USUARIO;

        Func_Global Pub = new Func_Global();
        Tb_Transporte_BO Transporte_BO = new Tb_Transporte_BO();

        protected void Page_Load(object sender, EventArgs e)
        {

            //Pega a conta logada para usar como parâmetro global
            try
            {
                ID_USUARIO = Session["ID_USUARIO"].ToString();
                Carregar_Transportes();
            }
            catch (Exception)
            {
                Response.Redirect("~/Forms/Sair.aspx");
            }


        }

        /// <summary>
        /// Atualiza a lista de produtos na página
        /// </summary>
        public void Carregar_Transportes()
        {

            List<Tb_Transporte> transportes = new List<Tb_Transporte>();

            transportes = Transporte_BO.Buscar_Transporte(ID_USUARIO);            
            grid_transportes.DataSource = null;
            grid_transportes.DataSource = transportes;
            grid_transportes.DataBind();

        }

        public void Limpa_Campos()
        {
            txt_NomeTransportadora.Text = "";
            txt_Observacao.Text = "";
 

        }


        protected void btn_Registrar_Click(object sender, EventArgs e)
        {

            try
            {

                Tb_Transporte Obj = new Tb_Transporte();
                Obj.vNom_Transportadora = txt_NomeTransportadora.Text;
                Obj.vDes_Observacao = txt_Observacao.Text;
                string retorno;
                retorno = Transporte_BO.Valida_Transporte(Obj);

                if (retorno == "1")
                {
                    string vStrSuccess = "'Transportadora cadastrado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Sucesso(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Carregar_Transportes();
                }
                else if (retorno == "2")
                {
                    string vStrSuccess = "'Transportadora atualizado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Sucesso(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Carregar_Transportes();

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