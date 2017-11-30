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

            Sql.Append("INSERT INTO db_app.tb_empresa (vNom_Empresa, vNom_Responsavel,vNum_CnpjCpf, " +
                                                        "vNum_TelefoneComercial, vNum_Celular, vCep," +
                                                        "vEndereco, vCidade, vUf ) VALUES " +
                                                        "(@vNom_Empresa, @vNom_Responsavel, @vNum_CnpjCpf," +
                                                        "@vNum_TelefoneComercial, @vNum_Celular, @vCep, " + 
                                                        "@vEndereco, @vCidade, @vUf )");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@vNom_Empresa", Obj.vNom_Empresa);
                Comando.Parameters.AddWithValue("@vNom_Responsavel", Obj.vNom_Responsavel);
                Comando.Parameters.AddWithValue("@vNum_CnpjCpf", Obj.vNum_CnpjCpf);
                Comando.Parameters.AddWithValue("@vNum_TelefoneComercial", Obj.vNum_TelefoneComercial);
                Comando.Parameters.AddWithValue("@vNum_Celular", Obj.vNum_Celular);
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

        public List<Tb_Empresa> Retrieve(String Sql)
        {
            List<Tb_Empresa> ListaEmpresas = new List<Tb_Empresa>();
            Tb_Empresa Obj = new Tb_Empresa();

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

                        Obj = new Tb_Empresa();

                        Obj.iCod_Conta = Convert.ToInt32(Reader["iCod_Conta"]);
                        Obj.iCod_Empresa = Convert.ToInt32(Reader["iCod_Empresa"]);
                        Obj.vNom_Empresa = Convert.ToString(Reader["vNom_Empresa"]);
                        Obj.vNom_Responsavel = Convert.ToString(Reader["vNom_Responsavel"]);
                        Obj.vNum_CnpjCpf = Convert.ToString(Reader["vNum_CnpjCpf"]);
                        Obj.vNum_TelefoneComercial = Convert.ToString(Reader["vNum_TelefoneComercial"]);
                        Obj.vNum_Celular = Convert.ToString(Reader["vNum_Celular"]);
                        Obj.vCep = Convert.ToString(Reader["vCep"]);
                        Obj.vEndereco = Convert.ToString(Reader["vEndereco"]);
                        Obj.vCidade = Convert.ToString(Reader["vCidade"]);
                        Obj.vUf = Convert.ToString(Reader["vUf"]);
                        Obj.dData_Cadastro = Convert.ToDateTime(Reader["dData_Cadastro"]);
                        ListaEmpresas.Add(Obj);
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

            return ListaEmpresas;
        }

        public bool Update(Tb_Empresa Obj)
        {

            MySqlConnection Conexao = new MySqlConnection();
            MySqlCommand Comando = new MySqlCommand();
            StringBuilder Sql = new StringBuilder();

            Sql.Append("UPDATE db_app.tb_empresa SET iCod_Conta = @iCod_Conta, vNom_Empresa = @vNom_Empresa, " +
                       "vNom_Responsavel = @vNom_Responsavel, vNum_CnpjCpf = @vNum_CnpjCpf, " +
                       "vNum_TelefoneComercial = @vNum_TelefoneComercial, vNum_Celular = @vNum_Celular" +
                       "vCep = @vCep, vCidade = @vCidade, vUf = @vUf, dData_Cadastro = @dData_Cadastro" +
                       " WHERE iCod_Empresa = @iCod_Empresa");

            try
            {
                Conexao = Db.GetConexao();

                Comando.Connection = Conexao;
                Comando.CommandText = Sql.ToString();
                Comando.Parameters.AddWithValue("@iCod_Empresa", Obj.iCod_Empresa);
                Comando.Parameters.AddWithValue("@iCod_Conta", Obj.iCod_Conta);
                Comando.Parameters.AddWithValue("@vNom_Empresa", Obj.vNom_Empresa);
                Comando.Parameters.AddWithValue("@vNom_Responsavel", Obj.vNom_Responsavel);
                Comando.Parameters.AddWithValue("@vNum_CnpjCpf", Obj.vNum_CnpjCpf);
                Comando.Parameters.AddWithValue("@vNum_TelefoneComercial", Obj.vNum_TelefoneComercial);
                Comando.Parameters.AddWithValue("@vNum_Celular", Obj.vNum_Celular);
                Comando.Parameters.AddWithValue("@vCep", Obj.vCep);
                Comando.Parameters.AddWithValue("@vCidade", Obj.vCidade);
                Comando.Parameters.AddWithValue("@vUf", Obj.vUf);
                Comando.Parameters.AddWithValue("@dData_Cadastro", Obj.dData_Cadastro);

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
