using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using SaaS_App.DAL;
using SaaS_App.Entidades;
using System.Text;

namespace SaaS_App.DAL
{
    public class Tb_Saida_DAO
    {

        Conn.Conexao Db = new Conn.Conexao();

        public string Insert(Tb_Saida Obj)
        {
            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();

            Sql.Append("INSERT INTO db_app.tb_saida (iCod_Conta, iCod_Produto, vQtd_Saida, " +
                                                        "vQtd_EstoqueAnt, vQtd_EstoqueAtual, dData_Saida, bFlag_Entrada)" +
                                                        " VALUES " +
                                                        "(@iCod_Conta, @iCod_Produto, @vQtd_Saida, " +
                                                        "@vQtd_EstoqueAnt, @vQtd_EstoqueAtual, @dData_Saida, @bFlag_Entrada)");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@iCod_Produto", Obj.iCod_Produto.iCod_Produto);
                Comando.Parameters.AddWithValue("@vQtd_Saida", Obj.vQtd_Saida);
                Comando.Parameters.AddWithValue("@vQtd_EstoqueAnt", Obj.vQtd_EstoqueAnt);
                Comando.Parameters.AddWithValue("@vQtd_EstoqueAtual", Obj.vQtd_EstoqueAtual);
                Comando.Parameters.AddWithValue("@iCod_Conta", Obj.iCod_Conta.iCod_Conta);
                Comando.Parameters.AddWithValue("@dData_Saida", Obj.dData_Saida);
                Comando.Parameters.AddWithValue("@bFlag_Entrada", Obj.bFlag_Entrada);

                Comando.ExecuteNonQuery();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                if (Conexao.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
        }



    }
}