using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SaaS_App.Conn
{
    public class Conexao
    {

        string StrConn = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        public MySqlConnection GetConexao() { 
       MySqlConnection oSQLConn = new MySqlConnection();
            try
            {
                oSQLConn.ConnectionString = StrConn;
                oSQLConn.Open();
                return oSQLConn;
            }
            catch (Exception ex)
            {
                var test = ex.Message;
                throw;
            }
 }


        public void CloseConexao(MySqlConnection conn)
        {
            if (Convert.ToBoolean(conn.State))
            {
                conn.Close();
            }
        }
    }




}