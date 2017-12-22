using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaaS_App.Entidades;
using SaaS_App.DAL;

namespace SaaS_App.BLL
{
    public class Tb_Produto_BO
    {

        Tb_Produto_DAO DAO = new Tb_Produto_DAO();
        Tb_Saida_DAO SaidaDAO = new Tb_Saida_DAO();


        /// <summary>
        /// Carrega a lista de produtos cadastrados no banco de dados
        /// </summary>
        /// <param name="ID_USUARIO"></param>
        /// <returns></returns>
        public List<Tb_Produto> Buscar_Produtos(string ID_USUARIO)
        {

            List<Tb_Produto> Lista = new List<Tb_Produto>();

            try
            {

                Lista = DAO.Retrieve("SELECT * FROM db_app.tb_produto WHERE iCod_Conta = " + ID_USUARIO).ToList();

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
        public string Valida_Produto(Tb_Produto Obj)
        {
            try
            {
                //Faz a consulta no banco de dados
                Tb_Produto Produto = new Tb_Produto();
                Produto = DAO.Retrieve("SELECT * FROM db_app.tb_produto WHERE iCod_Conta = '" + Obj.iCod_Conta + "' AND vNom_Produto = '" + Obj.vNom_Produto + "'").FirstOrDefault();

                if (Produto == null)
                {
                    //Insere a conta no banco de dados e retorna true se não houver nenhuma conta com o mesmo e-mail 
                    DAO.Insert(Obj);
                    return "1";
                }
                else
                {
                    Obj.iCod_Produto = Produto.iCod_Produto;
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
        /// Função da tela de lancamento de saída de produtos
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="saida"></param>
        /// <returns></returns>
        public string SaidaProduto(Tb_Produto produto, Tb_Saida saida)
        {
            try
            {

                DAO.Update(produto);
                SaidaDAO.Insert(saida);
                
                return "1";

            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }


        //fim classe
    }
}