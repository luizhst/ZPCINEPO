using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaaS_App.Entidades;
using SaaS_App.DAL;


namespace SaaS_App.BLL
{
    public class Tb_Empresa_BO
    {
        //Inicio da Classe

        Tb_Empresa_DAO DAO = new Tb_Empresa_DAO();

        public string Valida_Empresa_Existente(Tb_Empresa Obj)
        {
            try
            {
                //Faz a consulta no banco de dados
                Tb_Empresa Empresa = new Tb_Empresa();
                Empresa = DAO.Retrieve("SELECT * FROM db_app.tb_empresa WHERE iCod_Conta = '" + Obj.iCod_Conta + "' AND vNom_Empresa = '" + Obj.vNom_Empresa + "'").FirstOrDefault();

                if (Empresa == null)
                {
                    //Insere a conta no banco de dados e retorna true se não houver nenhuma conta com o mesmo e-mail 
                    DAO.Insert(Obj);
                    return "1";
                }
                else
                {
                    Obj.iCod_Empresa = Empresa.iCod_Empresa;
                    DAO.Update(Obj);
                    return "2";

                }

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                return erro;
            }
        }


        /// <summary>
        /// Busca as informações da empresa cadastrada para a conta selecionada
        /// </summary>
        /// <param name="iCod_Conta"></param>
        /// <returns></returns>
        public Tb_Empresa Busca_Empresa(string iCod_Conta)
        {

            try
            {
                Tb_Empresa Obj = new Tb_Empresa();
                Obj = DAO.Retrieve("SELECT * FROM db_app.tb_empresa WHERE iCod_Conta = " + iCod_Conta).FirstOrDefault();

                if(Obj != null)
                {
                    return Obj;

                }
                else
                {
                    return null;
                }
            }
            catch
            {

                return null;
            
            }            

        }

        //Fim da Classe
    }
}