using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaaS_App.Entidades;
using SaaS_App.DAL;
using SaaS_App.BLL;

namespace SaaS_App.BLL
{
    public class Tb_Veiculo_BO
    { 
        Tb_Veiculo_DAO DAO = new Tb_Veiculo_DAO();

        /// <summary>
        /// Carrega a lista de produtos cadastrados no banco de dados
        /// </summary>
        /// <param name="ID_TRANSPORTADORA"></param>
        /// <returns></returns>
        public List<Tb_Veiculo> Buscar_Veiculo(string ID_TRANSPORTADORA)
        {

            List<Tb_Veiculo> Lista = new List<Tb_Veiculo>();

            try
            {

                Lista = DAO.Retrieve("SELECT * FROM db_app.tb_veiculo ").ToList(); //WHERE iCod_Transporte = " + ID_USUARIO).ToList();

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
        public string Valida_Veiculo(Tb_Veiculo Obj)
        {
            try
            {
                //Faz a consulta no banco de dados
                Tb_Veiculo Veiculo = new Tb_Veiculo();
                Veiculo = DAO.Retrieve("SELECT * FROM db_app.tb_transporte WHERE vNum_Implacacao = '" + Obj.vNum_Implacacao + "'").FirstOrDefault();

                if (Veiculo == null)
                {
                    //Insere a conta no banco de dados e retorna true se não houver nenhuma conta com o mesmo e-mail 
                    DAO.Insert(Obj);
                    return "1";
                }
                else
                {
                    Obj.vNum_Implacacao = Veiculo.vNum_Implacacao;
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