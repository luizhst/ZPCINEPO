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
    public class Tb_Transportadora_DAO
    {

        Conn.Conexao Db = new Conn.Conexao();

        public string Insert(Tb_Transportadora Obj)
        {
            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();

            Sql.Append("INSERT INTO db_app.tb_transportadora (vNom_Transportadora, vDes_Observacao, iCod_Conta, vTelefone1, vTelefone2, vTelefone3, vTelefone4) VALUES " +
                                                        "(@vNom_Transportadora, @vDes_Observacao, @iCod_Conta, @vTelefone1, @vTelefone2, @vTelefone3, @vTelefone4)");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@vNom_Transportadora", Obj.vNom_Transportadora);
                Comando.Parameters.AddWithValue("@vDes_Observacao", Obj.vDes_Observacao);
                Comando.Parameters.AddWithValue("@iCod_Conta", Obj.iCod_Conta.iCod_Conta);
                Comando.Parameters.AddWithValue("@vTelefone1", Obj.vTelefone1);
                Comando.Parameters.AddWithValue("@vTelefone2", Obj.vTelefone2);
                Comando.Parameters.AddWithValue("@vTelefone3", Obj.vTelefone3);
                Comando.Parameters.AddWithValue("@vTelefone4", Obj.vTelefone4);

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


        public string Update(Tb_Transportadora Obj)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();

            Sql.Append("UPDATE db_app.tb_transportadora SET vNom_Transportadora = @vNom_Transportadora, vDes_Observacao = @vDes_Observacao, iCod_Conta = @iCod_Conta, " +
                       "vTelefone1 = @vTelefone1, vTelefone2 = @vTelefone2, vTelefone3 = @vTelefone3, vTelefone4 = @vTelefone4 WHERE iCod_Transportadora = @iCod_Transportadora");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@iCod_Transportadora", Obj.iCod_Transportadora);
                Comando.Parameters.AddWithValue("@vNom_Transportadora", Obj.vNom_Transportadora);
                Comando.Parameters.AddWithValue("@vDes_Observacao", Obj.vDes_Observacao);
                Comando.Parameters.AddWithValue("@vTelefone1", Obj.vTelefone1);
                Comando.Parameters.AddWithValue("@vTelefone2", Obj.vTelefone2);
                Comando.Parameters.AddWithValue("@vTelefone3", Obj.vTelefone3);
                Comando.Parameters.AddWithValue("@vTelefone4", Obj.vTelefone4);

                Comando.ExecuteNonQuery();
                return "1";

            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                return erro.ToString();
            }
            finally
            {
                if (Conexao.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Close();
                }

            }

        }


        public bool Delete(string iCod_Transportadora)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();
            Sql.Append("DELETE FROM db_app.tb_transportadora WHERE iCod_Transportadora = '" + iCod_Transportadora + "'");

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


        public List<Tb_Transportadora> Retrieve(String Sql)
        {
            List<Tb_Transportadora> Lista = new List<Tb_Transportadora>();
            Tb_Transportadora Obj = new Tb_Transportadora();

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            MySqlDataReader Reader;

            try
            {
                Conexao = Db.GetConexao();

                Comando.CommandTimeout = 120;
                Comando.CommandText = Sql;
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.Connection = Conexao;
                Reader = Comando.ExecuteReader();

                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {

                        Obj = new Tb_Transportadora();
                        Obj.iCod_Conta = new Tb_Conta();

                        Obj.iCod_Transportadora = Convert.ToInt32(Reader["iCod_Transportadora"]);
                        Obj.vNom_Transportadora = Convert.ToString(Reader["vNom_Transportadora"]);
                        Obj.iCod_Conta.iCod_Conta = Convert.ToInt32(Reader["iCod_Conta"]);
                        Obj.vDes_Observacao = Convert.ToString(Reader["vDes_Observacao"]);
                        Obj.vTelefone1 = Convert.ToString(Reader["vTelefone1"]);
                        Obj.vTelefone2 = Convert.ToString(Reader["vTelefone2"]);
                        Obj.vTelefone3 = Convert.ToString(Reader["vTelefone3"]);
                        Obj.vTelefone4 = Convert.ToString(Reader["vTelefone4"]);

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