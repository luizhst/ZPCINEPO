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
    public class Tb_Conta_DAO
    {
        Conn.Conexao Db = new Conn.Conexao();

        public Boolean Insert(Tb_Conta Obj)
        {
            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            StringBuilder Sql = new StringBuilder();

            Sql.Append("INSERT INTO db_app.tb_conta (vDes_Login, vDes_Senha,bFlag_Primaria, iCod_Primaria, bFlag_Ativa ) VALUES " +
                       "(@Des_User, @Des_Senha, @Flag_Primaria, @iCod_Primaria, @bFlag_Ativa )");                               

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@Des_User", Obj.vDes_Login);
                Comando.Parameters.AddWithValue("@Des_Senha", Obj.vDes_Senha);
                Comando.Parameters.AddWithValue("@Flag_Primaria", Obj.bFlag_Primaria);
                Comando.Parameters.AddWithValue("@iCod_Primaria", Obj.iCod_Primaria);
                Comando.Parameters.AddWithValue("@bFlag_Ativa", Obj.bFlag_Ativa);
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

        public List<Tb_Conta> Retrieve(String Sql)
        {
            List<Tb_Conta> ListaContas = new List<Tb_Conta>();
            Tb_Conta Obj = new Tb_Conta();

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

                        Obj = new Tb_Conta();

                        Obj.iCod_Conta = Convert.ToInt32(Reader["iCod_Conta"]);
                        Obj.vDes_Login = Convert.ToString(Reader["vDes_Login"]);
                        Obj.vDes_Senha = Convert.ToString(Reader["vDes_Senha"]);
                        Obj.iCod_Primaria = Convert.ToInt32(Reader["iCod_Primaria"]);
                        Obj.bFlag_Primaria = Convert.ToBoolean(Reader["bFlag_Primaria"]);
                        Obj.bFlag_Ativa = Convert.ToBoolean(Reader["bFlag_Ativa"]);
                        ListaContas.Add(Obj);
                    }
                }

                Reader.Close();


            }
            catch
            {
                return null;
            }
            finally
            {
                if (Conexao.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Close();
                }

            }

            return ListaContas;

        }

        public bool Update(Tb_Conta Obj)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            StringBuilder Sql = new StringBuilder();

            Sql.Append("UPDATE tb_conta SET vDes_Login = @Des_User, vDes_Senha = @Des_Senha, " +
                       "iCod_Primaria = @iCod_Primaria, bFlag_Primaria = @Flag_Primaria, " +
                       "bFlag_Ativa = @Flag_Ativa WHERE iCod_Conta = @Cod_Conta");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@Cod_Conta", Obj.iCod_Conta);
                Comando.Parameters.AddWithValue("@Des_User", Obj.vDes_Login);
                Comando.Parameters.AddWithValue("@Des_Senha", Obj.vDes_Senha);
                Comando.Parameters.AddWithValue("@iCod_Primaria", Obj.iCod_Primaria);
                Comando.Parameters.AddWithValue("@Flag_Primaria", Obj.bFlag_Primaria);
                Comando.Parameters.AddWithValue("@Flag_Ativa", Obj.bFlag_Ativa);
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
        public bool Delete(string Filtro)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            StringBuilder Sql = new StringBuilder();
            Sql.Append("DELETE FROM tb_empresa WHERE iCod_Empresa = '" + Filtro + "'");

            try
            {
                Conexao = Db.GetConexao();
                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                var sqltest = Sql.ToString();
                Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                //Fecha a conexao para não mante-la aberta
                if (Conexao.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Close();
                }

            }

        }


    }
}
