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
    public class Tb_Veiculo_DAO
    {

        Conn.Conexao Db = new Conn.Conexao();

        public string Insert(Tb_Veiculo Obj)
        {
            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();

            Sql.Append("INSERT INTO db_app.tb_veiculo (vNum_Implacacao, vTipo_Veiculo, vDes_Veiculo, iCod_Conta) VALUES " +
                                                        "(@vNum_Implacacao, @vTipo_Veiculo, @vDes_Veiculo, @iCod_Conta)");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@vNum_Implacacao", Obj.vNum_Implacacao);
                Comando.Parameters.AddWithValue("@vTipo_Veiculo", Obj.vTipo_Veiculo);
                Comando.Parameters.AddWithValue("@vDes_Veiculo", Obj.vDes_Veiculo);
                Comando.Parameters.AddWithValue("@iCod_Conta", Obj.iCod_Veiculo);
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


        public bool Update(Tb_Veiculo Obj)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();

            Sql.Append("UPDATE db_app.tb_veiculo SET vNum_Implacacao = @vNum_Implacacao, vTipo_Veiculo = @vTipo_Veiculo" +
                       "vDes_Veiculo = @vDes_Veiculo WHERE iCod_Veiculo = @iCod_Veiculo");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@vNum_Implacacao", Obj.vNum_Implacacao);
                Comando.Parameters.AddWithValue("@vTipo_Veiculo", Obj.vTipo_Veiculo);
                Comando.Parameters.AddWithValue("@vDes_Veiculo", Obj.vDes_Veiculo);
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


        public bool Delete(string iCod_Veiculo)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();
            Sql.Append("DELETE FROM db_app.tb_veiculo WHERE iCod_Veiculo = '" + iCod_Veiculo + "'");

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


        public List<Tb_Veiculo> Retrieve(String Sql)
        {
            List<Tb_Veiculo> Lista = new List<Tb_Veiculo>();
            Tb_Veiculo Obj = new Tb_Veiculo();

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();

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

                        Obj = new Tb_Veiculo();

                        Obj.iCod_Veiculo = Convert.ToInt32(Reader["iCod_Veiculo"]);
                        Obj.vNum_Implacacao = Convert.ToString(Reader["vNum_Implacacao"]);
                        Obj.vTipo_Veiculo = Convert.ToString(Reader["vTipo_Veiculo"]);
                        Obj.vDes_Veiculo = Convert.ToString(Reader["vNum_Implacacao"]);
                        Obj.iCod_Veiculo = Convert.ToInt32(Reader["iCod_Veiculo"]);
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