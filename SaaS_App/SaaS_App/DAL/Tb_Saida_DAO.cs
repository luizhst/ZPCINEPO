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


        public List<Tb_Saida> Retrieve(String Sql)
        {
            List<Tb_Saida> Lista = new List<Tb_Saida>();
            Tb_Saida Obj = new Tb_Saida();

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();

            //MySqlDataReader Reader = new MySqlDataReader();

            try
            {
                Conexao = Db.GetConexao();

                Comando.CommandTimeout = 120;
                Comando.CommandText = Sql;
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.Connection = Conexao;
                MySqlDataReader Reader = Comando.ExecuteReader();

                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {

                        Obj = new Tb_Saida();
                        Obj.iCod_Conta = new Tb_Conta();
                        Obj.iCod_Produto = new Tb_Produto();

                        Obj.iCod_Conta.iCod_Conta = Convert.ToInt32(Reader["iCod_Conta"]);
                        //Obj.iCod_Produto.iCod_Produto = Convert.ToInt32(Reader["iCod_Produto"]);
                        Obj.iCod_Produto.vNom_Produto = Convert.ToString(Reader["vNom_Produto"]);
                        Obj.vQtd_EstoqueAtual = Convert.ToString(Reader["vQtd_EstoqueAtual"]);
                        Obj.vQtd_Saida = Convert.ToString(Reader["vQtd_Saida"]);
                        Obj.vQtd_EstoqueAnt = Convert.ToString(Reader["vQtd_EstoqueAnt"]);
                        Obj.dData_Saida = Convert.ToDateTime(Reader["dData_Saida"]);
                        Obj.bFlag_Entrada = Convert.ToBoolean(Reader["bFlag_Entrada"]);

                        Lista.Add(Obj);
                    }
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                return null;
            }
            finally
            {
                if (Conexao.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Close();
                }

            }

            return Lista;
        }


    



}
}