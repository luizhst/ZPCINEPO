using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaaS_App.Entidades;
using SaaS_App.DAL;
using SaaS_App.BLL;

namespace SaaS_App.BLL
{
    public class Tb_Categoria_Produto_BO
    {
        Tb_Categoria_Produto_DAO DAO = new Tb_Categoria_Produto_DAO();

        /// <summary>
        /// Carrega a lista de produtos cadastrados no banco de dados
        /// </summary>
        /// <param name="ID_TRANSPORTADORA"></param>
        /// <returns></returns>
        public List<Tb_Categoria_Produto> Buscar_Categoria_Produto()
        {

            List<Tb_Categoria_Produto> Lista = new List<Tb_Categoria_Produto>();

            try
            {

                Lista = DAO.Retrieve("SELECT * FROM db_app.tb_categoria_produto ").ToList();

            }
            catch (Exception)
            {
                return null;
            }

            return Lista;
            
        }
        //fim classe
    }
}