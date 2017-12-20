using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaaS_App.Entidades;
using SaaS_App.DAL;
using SaaS_App.BLL;

namespace SaaS_App.BLL
{
    public class Tb_Transportadora_BO
    {

        Tb_Transportadora_DAO DAO = new Tb_Transportadora_DAO();

        /// <summary>
        /// Carrega a lista de produtos cadastrados no banco de dados
        /// </summary>
        /// <param name="ID_USUARIO"></param>
        /// <returns></returns>
        public List<Tb_Transportadora> Buscar_Transporte(string ID_USUARIO)
        {

            List<Tb_Transportadora> Lista = new List<Tb_Transportadora>();

            try
            {

                Lista = DAO.Retrieve("SELECT * FROM db_app.tb_transportadora ").ToList(); //WHERE iCod_Transporte = " + ID_USUARIO).ToList();

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
        public string Valida_Transportadora(Tb_Transportadora Obj)
        {
            try
            {
                //Faz a consulta no banco de dados
                Tb_Transportadora Transportadora = new Tb_Transportadora();
                Transportadora = DAO.Retrieve("SELECT * FROM db_app.tb_transportadora WHERE iCod_Transportadora = '" + Obj.iCod_Transportadora + "' AND vNom_Transportadora = '" + Obj.vNom_Transportadora + "'").FirstOrDefault();

                if (Transportadora == null)
                {
                    //Insere a conta no banco de dados e retorna true se não houver nenhuma conta com o mesmo e-mail 
                    DAO.Insert(Obj);
                    return "1";
                }
                else
                {
                    Obj.iCod_Transportadora = Transportadora.iCod_Transportadora;
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