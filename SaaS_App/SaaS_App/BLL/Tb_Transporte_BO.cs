using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaaS_App.Entidades;
using SaaS_App.DAL;
using SaaS_App.BLL;

namespace SaaS_App.BLL
{
    public class Tb_Transporte_BO
    {

        Tb_Transporte_DAO DAO = new Tb_Transporte_DAO();

        /// <summary>
        /// Carrega a lista de produtos cadastrados no banco de dados
        /// </summary>
        /// <param name="ID_USUARIO"></param>
        /// <returns></returns>
        public List<Tb_Transporte> Buscar_Transporte(string ID_USUARIO)
        {

            List<Tb_Transporte> Lista = new List<Tb_Transporte>();

            try
            {

                Lista = DAO.Retrieve("SELECT * FROM db_app.tb_transporte ").ToList(); //WHERE iCod_Transporte = " + ID_USUARIO).ToList();

            }
            catch (Exception)
            {
                return null;
            }

            return Lista;
            
        }

        /// <summary>
        /// Valida se o produto já é existente no banco de dados e atualiza o mesmo ou insere um novo registro
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public string Valida_Transporte(Tb_Transporte Obj)
        {
            try
            {
                //Faz a consulta no banco de dados
                Tb_Transporte Transporte = new Tb_Transporte();
                Transporte = DAO.Retrieve("SELECT * FROM db_app.tb_transporte WHERE iCod_Transporte = '" + Obj.iCod_Transporte + "' AND vNom_Transportadora = '" + Obj.vNom_Transportadora + "'").FirstOrDefault();

                if (Transporte == null)
                {
                    //Insere a conta no banco de dados e retorna true se não houver nenhuma conta com o mesmo e-mail 
                    DAO.Insert(Obj);
                    return "1";
                }
                else
                {
                    Obj.iCod_Transporte = Transporte.iCod_Transporte;
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


        //fim classe
    }
}