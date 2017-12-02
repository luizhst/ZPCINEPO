using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaaS_App.BLL;

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
            if(ID_EMPRESA == null)
            {
                Verifica_Empresa();
            }
            
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
                Response.Redirect("~/Forms/Cadastro-Empresa.aspx");
            }
                        
        }
    }
}