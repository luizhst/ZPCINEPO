using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using SaaS_App.DAL;
using SaaS_App.Entidades;
using System.Text;
using System.Web.SessionState;

namespace SaaS_App.BLL
{

    public class Tb_Conta_BO
    {

        Tb_Conta_DAO DAO = new Tb_Conta_DAO();

        /// <summary>
        /// Verifica no banco de dados se já existe alguma conta com o mesmo endereço de e-mail
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public bool Valida_Conta_Existente(Tb_Conta Obj)
        {
            try
            {
                //Faz a consulta no banco de dados
                Tb_Conta Conta_Antiga = new Tb_Conta();
                Conta_Antiga = DAO.Retrieve("SELECT * FROM db_app.tb_conta WHERE vDes_Login = '" + Obj.vDes_Login + "'").FirstOrDefault();

                if (Conta_Antiga == null)
                {
                    //Insere a conta no banco de dados e retorna true se não houver nenhuma conta com o mesmo e-mail 
                    DAO.Insert(Obj);

                    return true;
                }
                else
                {
                    //Se houver alguma conta cadastrada com o mesmo e-mail retorna false
                    return false;
                }
            }
            catch (Exception)
            {
                //Se erro retorna false (Verificar uma forma melhor de retornar caso erro)
                return false;
            }
        }

        public Tb_Conta Valida_Login(string Usuario, string Senha)
        {
            try
            {

                //Faz a consulta no banco de dados
                Tb_Conta Conta = new Tb_Conta();
                Conta = DAO.Retrieve("SELECT * FROM db_app.tb_conta WHERE vDes_Login = '" + Usuario + "' AND vDes_Senha = '" + Senha + "'").FirstOrDefault();

                if (Conta != null)
                {
                    //Armazena as informações na váriavel de sessão
                    return Conta;
                }
                else
                {
                    //Se houver alguma conta cadastrada com o mesmo e-mail retorna false
                    return null;
                }

            }
            catch (Exception)
            {
                return null;

            }
        }






        //Final da Classe
    }
}