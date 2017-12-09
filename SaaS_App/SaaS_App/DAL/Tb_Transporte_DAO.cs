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
    public class Tb_Transporte_DAO
    {

        Conn.Conexao Db = new Conn.Conexao();

        public string Insert(Tb_Transporte Obj)
        {
            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();

            Sql.Append("INSERT INTO db_app.tb_transporte (vNom_Transportadora, vDes_Observacao, iCod_Empresa) VALUES " +
                                                        "(@vNom_Transportadora, @vDes_Observacao, @iCod_Empresa)");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@vNom_Transportadora", Obj.vNom_Transportadora);
                Comando.Parameters.AddWithValue("@vDes_Observacao", Obj.vDes_Observacao);
                Comando.Parameters.AddWithValue("@iCod_Empresa", Obj.iCod_Empresa);
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


        public bool Update(Tb_Transporte Obj)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();

            Sql.Append("UPDATE db_app.tb_transporte SET vNom_Transportadora = @vNom_Transportadora, vDes_Observacao = @vDes_Observacao, iCod_Empresa = @iCod_Empresa" +
                       " WHERE iCod_Transporte = @iCod_Transporte");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@iCod_Transporte", Obj.iCod_Transporte);
                Comando.Parameters.AddWithValue("@vNom_Transportadora", Obj.vNom_Transportadora);
                Comando.Parameters.AddWithValue("@vDes_Observacao", Obj.vDes_Observacao);
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


        public bool Delete(string iCod_Transporte)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            Comando.CommandTimeout = 120;
            StringBuilder Sql = new StringBuilder();
            Sql.Append("DELETE FROM db_app.tb_transporte WHERE iCod_Transporte = '" + iCod_Transporte + "'");

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


        public List<Tb_Transporte> Retrieve(String Sql)
        {
            List<Tb_Transporte> Lista = new List<Tb_Transporte>();
            Tb_Transporte Obj = new Tb_Transporte();

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

                        Obj = new Tb_Transporte();

                        Obj.iCod_Transporte = Convert.ToInt32(Reader["iCod_Transporte"]);
                        Obj.vNom_Transportadora = Convert.ToString(Reader["vNom_Transportadora"]);
                        Obj.iCod_Empresa = Convert.ToInt32(Reader["iCod_Empresa"]);
                        Obj.vDes_Observacao = Convert.ToString(Reader["vDes_Observacao"]);
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