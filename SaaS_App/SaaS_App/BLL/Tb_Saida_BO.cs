using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaaS_App.Entidades;
using SaaS_App.DAL;

namespace SaaS_App.BLL
{
    public class Tb_Saida_BO
    {
        Tb_Saida_DAO DAO = new Tb_Saida_DAO();

        /// <summary>
        /// Carrega a lista de lancamentos cadastrados no banco de dados
        /// </summary>
        /// <param name="ID_USUARIO"></param>
        /// <returns></returns>
        public List<Tb_Saida> Buscar_Saidas(string ID_USUARIO)
        {

            List<Tb_Saida> Lista = new List<Tb_Saida>();

            try
            {

                Lista = DAO.Retrieve("SELECT s.iCod_Conta, p.vNom_Produto, s.vQtd_EstoqueAtual, " +
                                     "s.vQtd_Saida, s.vQtd_EstoqueAnt, s.dData_Saida, s.bFlag_Entrada " +
                                     "FROM db_app.tb_saida s, db_app.tb_produto p " +
                                     "WHERE s.iCod_Produto = p.iCod_Produto AND " +
                                     "s.iCod_Conta = " + ID_USUARIO +
                                     " order by s.iCod_Saida DESC").ToList();

            }
            catch (Exception ex)
            {
                var texto = ex.ToString();
                return null;
            }

            return Lista;

        }

    }
}