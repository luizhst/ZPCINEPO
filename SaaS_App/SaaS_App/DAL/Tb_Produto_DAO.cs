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
    public class Tb_Produto_DAO
    {

        Conn.Conexao Db = new Conn.Conexao();

        public string Insert(Tb_Produto Obj)
        {
            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            StringBuilder Sql = new StringBuilder();

            Sql.Append("INSERT INTO db_app.tb_produto (iCod_Conta, vNom_Produto, dPreco_Custo, " +
                                                        "dPreco_Venda, vQtd_Estoque, vQtd_Min_Estoque," +
                                                        "dData_Cadastro) VALUES " +
                                                        "(@iCod_Conta, @vNom_Produto, @dPreco_Custo, " +
                                                        "@dPreco_Venda, @vQtd_Estoque, @vQtd_Min_Estoque," +
                                                        "@dData_Cadastro)");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@vNom_Produto", Obj.vNom_Produto);
                Comando.Parameters.AddWithValue("@dPreco_Custo", Obj.dPreco_Custo);
                Comando.Parameters.AddWithValue("@dPreco_Venda", Obj.dPreco_Venda);
                Comando.Parameters.AddWithValue("@vQtd_Estoque", Obj.vQtd_Estoque);
                Comando.Parameters.AddWithValue("@vQtd_Min_Estoque", Obj.vQtd_Min_Estoque);
                Comando.Parameters.AddWithValue("@dData_Cadastro", Obj.dData_Cadastro);
                Comando.Parameters.AddWithValue("@iCod_Conta", Obj.iCod_Conta);

                Comando.ExecuteNonQuery();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
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