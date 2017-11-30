using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using SaaS_App.DAL;
using SaaS_App.Entidades;
using System.Text;

namespace SaaS_App.BLL
{
    public class Tb_Conta_BO
    {
        public bool InputCadastro(String vEmail, String vPassword)
        {
            
            Tb_Conta Obj = new Tb_Conta();
            Tb_Conta_DAO DAO = new Tb_Conta_DAO();

            Obj = DAO.Retrieve("Select * From Where vEmail = '" + vEmail + "'").FirstOrDefault();
            if (!Obj.Equals(null))
            {
                Obj.vDes_Login = vEmail;
                Obj.vDes_Senha = vPassword;
                Obj.bFlag_Primaria = true;
                Obj.iCod_Primaria = 1;
                Obj.bFlag_Ativa = true;
                DAO.Insert(Obj);
                return true;
            }
            return false;
        }
    }
}