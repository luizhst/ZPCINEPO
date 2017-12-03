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

        public string Insert(Tb_Conta Obj)
        {
            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            StringBuilder Sql = new StringBuilder();

            Sql.Append("INSERT INTO db_app.tb_conta (vDes_Login, vDes_Senha, bFlag_Primaria, iCod_Primaria, bFlag_Ativa, dData_Cadastro) VALUES " +
                       "(@vDes_Login, @vDes_Senha, @bFlag_Primaria, @iCod_Primaria, @bFlag_Ativa, @dData_Cadastro)");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@vDes_Login", Obj.vDes_Login);
                Comando.Parameters.AddWithValue("@vDes_Senha", Obj.vDes_Senha);
                Comando.Parameters.AddWithValue("@bFlag_Primaria", Obj.bFlag_Primaria);
                Comando.Parameters.AddWithValue("@iCod_Primaria", Obj.iCod_Primaria);
                Comando.Parameters.AddWithValue("@bFlag_Ativa", Obj.bFlag_Ativa);
                Comando.Parameters.AddWithValue("@dData_Cadastro", Obj.dData_Cadastro);
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
                        Obj.dData_Cadastro = Convert.ToDateTime(Reader["dData_Cadastro"]);
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

            Sql.Append("UPDATE db_app.tb_conta SET vDes_Login = @vDes_Login, vDes_Senha = @vDes_Senha, " +
                       "iCod_Primaria = @iCod_Primaria, bFlag_Primaria = @bFlag_Primaria, " +
                       "bFlag_Ativa = @bFlag_Ativa WHERE iCod_Conta = @iCod_Conta");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@iCod_Conta", Obj.iCod_Conta);
                Comando.Parameters.AddWithValue("@vDes_Login", Obj.vDes_Login);
                Comando.Parameters.AddWithValue("@vDes_Senha", Obj.vDes_Senha);
                Comando.Parameters.AddWithValue("@iCod_Primaria", Obj.iCod_Primaria);
                Comando.Parameters.AddWithValue("@bFlag_Primaria", Obj.bFlag_Primaria);
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



    }
}
