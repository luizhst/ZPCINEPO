using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using SaaS_App.Entidades;
using SaaS_App.DAL;
using SaaS_App.BLL;

namespace SaaS_App.Forms
{
    public partial class Acesso : System.Web.UI.Page
    {

        Func_Global Pub = new Func_Global();
        Tb_Conta_BO Conta_BO = new Tb_Conta_BO();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_submit_Click(object sender, EventArgs e)
        {
            //Aqui vai a função de logar

        }
        
        /// <summary>
        /// Coleta as informações inseridas na tela de registro de conta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Valida_Cadastro_Click(object sender, EventArgs e)
        {
            //Variaveis Locais
            String Usuario, Senha;

            //Criptografando usuario e senha
            Usuario = Pub.CifraTexto(txt_cad_usuario.Text);
            Senha = Pub.CifraTexto(txt_cad_senha.Text);

            //atribuindo ao objeto conta
            Tb_Conta Obj = new Tb_Conta();

            Obj.vDes_Login = Usuario;
            Obj.vDes_Senha = Senha;
            Obj.dData_Cadastro = Convert.ToDateTime(DateTime.Now);
            Obj.bFlag_Ativa = true;
            Obj.bFlag_Primaria = true;

            //Verificando se existe conta com este usuário e senha
            if(Conta_BO.Valida_Conta_Existente(Obj) == true) {
                ScriptManager.RegisterStartupScript(this, GetType(), "MoveNext", "ProximaEtapa()", true);
            }
            else
            {
                //Faz Nada
            }




        }
    }
}