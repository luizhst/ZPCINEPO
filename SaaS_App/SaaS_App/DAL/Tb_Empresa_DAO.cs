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
    public class Tb_Empresa_DAO
    {
        Conn.Conexao Db = new Conn.Conexao();

        public Boolean Insert(Tb_Empresa Obj)
        {
            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            StringBuilder Sql = new StringBuilder();

            Sql.Append("INSERT INTO db_app.tb_empresa (vNomEmpresa, vNomResponsavel,vNumCnpjCpf, " +
                                                        "vNumTelefoneComercial, vNumCelular, vCep," +
                                                        "vEndereco, vCidade, vUf ) VALUES " +
                                                        "(@vNomEmpresa, @vNomResponsavel, @vNumCnpjCpf," +
                                                        "@vNumTelefoneComercial, @vNumCelular, @vCep, " + "" +
                                                        "@vEndereco, @vCidade, @vUf )");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@vNomEmpresa", Obj.vNomEmpresa);
                Comando.Parameters.AddWithValue("@vNomResponsavel", Obj.vNomResponsavel);
                Comando.Parameters.AddWithValue("@vNumCnpjCpf", Obj.vNumCnpjCpf);
                Comando.Parameters.AddWithValue("@vNumTelefoneComercial", Obj.vNumTelefoneComercial);
                Comando.Parameters.AddWithValue("@vNumCelular", Obj.vNumCelular);
                Comando.Parameters.AddWithValue("@vCep", Obj.vCep);
                Comando.Parameters.AddWithValue("@vEndereco", Obj.vEndereco);
                Comando.Parameters.AddWithValue("@vCidade", Obj.vCidade);
                Comando.Parameters.AddWithValue("@vUf", Obj.vUf);

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