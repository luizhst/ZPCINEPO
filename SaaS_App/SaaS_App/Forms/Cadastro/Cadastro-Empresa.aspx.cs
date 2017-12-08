using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaaS_App.Entidades;
using SaaS_App.BLL;

namespace SaaS_App.Forms
{
    public partial class Cadastro_Empresa : System.Web.UI.Page
    {
        string ID_USUARIO;
        //string ID_EMPRESA;

        Func_Global Pub = new Func_Global();
        Tb_Empresa_BO Empresa_BO = new Tb_Empresa_BO();

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


            if (txt_Empresa.Text == "")
            {
                Busca_Empresa();
            }
            

        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {
            Valida_Cadastro_Empresa();
        }


        public void Valida_Cadastro_Empresa()
        {

            try
            {
                Tb_Empresa Obj = new Tb_Empresa();

                Obj.iCod_Conta = Convert.ToInt32(Session["ID_USUARIO"].ToString());
                Obj.vNom_Empresa = txt_Empresa.Text;
                Obj.vNum_CnpjCpf = txt_CpfCnpj.Text;
                Obj.vNom_Responsavel = txt_Responsavel.Text;
                Obj.vNum_TelefoneComercial = txt_Fone1.Text;
                Obj.vNum_Celular = txt_Fone2.Text;
                Obj.vCep = txt_Cep.Text;
                Obj.vEndereco = txt_Rua.Text;
                Obj.vCidade = txt_Cidade.Text;
                Obj.vUf = txt_Uf.Text;
                Obj.dData_Cadastro = Convert.ToDateTime(DateTime.Now);

                string retorno = Empresa_BO.Valida_Empresa_Existente(Obj);

                if (retorno == "1")
                {
                    string vStrSuccess = "'Empresa cadastrada com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrSuccess + ");", true);
                    Response.Redirect("~/Forms/Principal.aspx");
                }
                else if (retorno == "2")
                {
                    string vStrSuccess = "'Empresa atualizada com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrSuccess + ");", true);
                    
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

        public void Busca_Empresa()
        {
            try
            {

                Tb_Empresa Obj = new Tb_Empresa();

                if (ID_USUARIO != null)
                {
                    Obj = Empresa_BO.Busca_Empresa(ID_USUARIO);

                    txt_Empresa.Text = Obj.vNom_Empresa;
                    txt_CpfCnpj.Text = Obj.vNum_CnpjCpf;
                    txt_Responsavel.Text = Obj.vNom_Responsavel;
                    txt_Fone1.Text = Obj.vNum_TelefoneComercial;
                    txt_Fone2.Text = Obj.vNum_Celular;
                    txt_Cep.Text = Obj.vCep;
                    txt_Rua.Text = Obj.vEndereco;
                    txt_Cidade.Text = Obj.vCidade;
                    txt_Uf.Text = Obj.vUf;

                    txt_Empresa.ReadOnly = true;

                    btn_Registrar.Text = "Atualizar Dados";

                }

            }
            catch (Exception)
            {
                txt_Empresa.ReadOnly = false;
                btn_Registrar.Text = "Cadastrar e Continuar";
            }
            
        }






    }
}