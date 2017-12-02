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
                    //Se houver alguma conta cadastrada com o mesmo e-mail retorna false
                    return "Já existe uma empresa cadastrada para essa conta!";
                }

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                return erro;
            }
        }

        //Fim da Classe
    }
}