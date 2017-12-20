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
        Tb_Transportadora_BO Transporte_BO = new Tb_Transportadora_BO();

        protected void Page_Load(object sender, EventArgs e)
        {

            //Pega a conta logada para usar como parâmetro global
            try
            {
                ID_USUARIO = Session["ID_USUARIO"].ToString();
                //Response.Redirect("~/Forms/Cadastro/Lista-Transportadoras.aspx");
            }
            catch (Exception)
            {
                Response.Redirect("~/Forms/Sair.aspx");
            }


        }



        public void Limpa_Campos()
        {
            txt_NomeTransportadora.Text = "";
            txt_telefone1.Text = "";
            txt_telefone2.Text = "";
            txt_telefone3.Text = "";
            txt_telefone4.Text = "";
            txt_Observacao.Text = "";
 
        }


        protected void btn_Registrar_Click(object sender, EventArgs e)
        {

            try
            {

                Tb_Transportadora Obj = new Tb_Transportadora();
                Obj.iCod_Conta = new Tb_Conta();

                Obj.vNom_Transportadora = txt_NomeTransportadora.Text;
                Obj.vDes_Observacao = txt_Observacao.Text;
                Obj.vTelefone1 = txt_telefone1.Text;
                Obj.vTelefone2 = txt_telefone2.Text;
                Obj.vTelefone3 = txt_telefone3.Text;
                Obj.vTelefone4 = txt_telefone4.Text;
                Obj.iCod_Conta.iCod_Conta = Convert.ToInt32(ID_USUARIO);

                string retorno;
                retorno = Transporte_BO.Valida_Transportadora(Obj);

                if (retorno == "1")
                {
                    string vStrSuccess = "'Transportadora cadastrado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Sucesso(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Response.Redirect("~/Forms/Cadastro/Lista-Transportadoras.aspx");
                }
                else if (retorno == "2")
                {
                    string vStrSuccess = "'Transportadora atualizado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Sucesso(" + vStrSuccess + ");", true);
                    Limpa_Campos();
                    Response.Redirect("~/Forms/Cadastro/Lista-Transportadoras.aspx");

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