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

namespace SaaS_App.Forms.Acesso
{
    public partial class Acesso : System.Web.UI.Page
    {
        Func_Global Pub = new Func_Global();
        Tb_Conta_BO Conta_BO = new Tb_Conta_BO();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            ValidaCadastro();
        }


        public void ValidaCadastro()
        {
            //Variaveis Locais
            String Usuario, Senha;

            if (tx_cad_email.Text != "" || tx_cad_confirmasenha.Text != "")
            {
                //Criptografando usuario e senha
                Usuario = Pub.CifraTexto(tx_cad_email.Text);
                Senha = Pub.CifraTexto(tx_cad_confirmasenha.Text);

                //atribuindo ao objeto conta
                Tb_Conta Obj = new Tb_Conta();

                Obj.vDes_Login = Usuario;
                Obj.vDes_Senha = Senha;
                Obj.dData_Cadastro = Convert.ToDateTime(DateTime.Now);
                Obj.bFlag_Ativa = true;
                Obj.bFlag_Primaria = true;

                //Verificando se existe conta com este usuário e senha
                if (Conta_BO.Valida_Conta_Existente(Obj) == true)
                {
                    string vStrSuccess = "'Usuário cadastrado com sucesso!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrSuccess + ");", true);
                    Response.Redirect("~/Forms/Cadastro-Empresa.aspx");
                }
                else
                {
                    string vStrWarning = "'Usuário já cadastrado no sistema!'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrWarning + ");", true);
                }
            }
            else
            {
                string vStrWarning = "'Preencha todos os campos para continuar!'";
                ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrWarning + ");", true);
            }
        }


        protected void Btn_Acessar_Click(object sender, EventArgs e)
        {
            Acessar();
        }



        public void Acessar()
        {

            //Variaveis Locais
            String Usuario, Senha;

            if (txt_Email.Text != "" || txt_Senha.Text != "")
            {
                //Criptografa a conta do usuário
                Usuario = Pub.CifraTexto(txt_Email.Text);
                Senha = Pub.CifraTexto(txt_Senha.Text);

                //Registra o Obj do usuário
                Tb_Conta Usuario_Logado = new Tb_Conta();
                Usuario_Logado = Conta_BO.Valida_Login(Usuario, Senha);

                if (Usuario_Logado != null)
                {
                    //define o usuário logado na sessão
                    Session["ID_USUARIO"] = Usuario_Logado.iCod_Conta;

                    string vStrSuccess = "'Usuario autenticado com sucesso, você será direcionado agora...'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrSuccess + ");", true);
                    Response.Redirect("~/Forms/Principal.aspx");

                }
                else
                {
                    string vStrWarning = "'Usuário sem cadastro no sistema! Registre-se para continuar.'";
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrWarning + ");", true);
                }
            }
            else
            {
                string vStrWarning = "'Preencha todos os campos para continuar!'";
                ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Msg_Warning(" + vStrWarning + ");", true);
            }

               

        }



    }
}