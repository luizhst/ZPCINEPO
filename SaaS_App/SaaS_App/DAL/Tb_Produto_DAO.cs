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


        public bool Update(Tb_Produto Obj)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            StringBuilder Sql = new StringBuilder();

            Sql.Append("UPDATE db_app.tb_produto SET vNom_Produto = @vNom_Produto, dPreco_Custo = @dPreco_Custo, " +
                       "dPreco_Venda = @dPreco_Venda, vQtd_Estoque = @vQtd_Estoque, " +
                       "vQtd_Min_Estoque = @vQtd_Min_Estoque " +
                       " WHERE iCod_Produto = @iCod_Produto");

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
                Comando.Parameters.AddWithValue("@iCod_Produto", Obj.iCod_Produto);


                Comando.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                return false;
            }
            finally
            {
                if (Conexao.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Close();
                }

            }

        }


        public bool Delete(string iCod_Produto)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            StringBuilder Sql = new StringBuilder();
            Sql.Append("DELETE FROM db_app.tb_produto WHERE iCod_Produto = '" + iCod_Produto + "'");

            try
            {
                Conexao = Db.GetConexao();
                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (Conexao.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Close();
                }

            }

        }


        public List<Tb_Produto> Retrieve(String Sql)
        {
            List<Tb_Produto> Lista = new List<Tb_Produto>();
            Tb_Produto Obj = new Tb_Produto();

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            //MySqlDataReader Reader = new MySqlDataReader();

            try
            {
                Conexao = Db.GetConexao();

                Comando.CommandText = Sql;
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.Connection = Conexao;
                MySqlDataReader Reader = Comando.ExecuteReader();

                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {

                        Obj = new Tb_Produto();

                        Obj.iCod_Conta = Convert.ToInt32(Reader["iCod_Conta"]);
                        Obj.iCod_Produto = Convert.ToInt32(Reader["iCod_Produto"]);
                        Obj.vNom_Produto = Convert.ToString(Reader["vNom_Produto"]);
                        Obj.dPreco_Custo = Convert.ToDouble(Reader["dPreco_Custo"]);
                        Obj.dPreco_Venda = Convert.ToDouble(Reader["dPreco_Venda"]);
                        Obj.vQtd_Estoque = Convert.ToString(Reader["vQtd_Estoque"]);
                        Obj.vQtd_Min_Estoque = Convert.ToString(Reader["vQtd_Min_Estoque"]);
                        Obj.dData_Cadastro = Convert.ToDateTime(Reader["dData_Cadastro"]);

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