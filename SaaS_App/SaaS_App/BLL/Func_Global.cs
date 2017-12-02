using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using SaaS_App.DAL;
using SaaS_App.Entidades;

namespace SaaS_App.BLL
{
    public class Func_Global
    {
        /// <summary>
        /// Funções relacionadas a criptografia do sistema
        /// </summary>
        #region Criptografia

        String Key = ConfigurationManager.AppSettings["KeyCripto"];
        TripleDESCryptoServiceProvider Des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider HashMD5 = new MD5CryptoServiceProvider();

        /// <summary>
        /// Criptografa o texto informado como parâmetro
        /// </summary>
        /// <param name="Texto"></param>
        public string CifraTexto(string Texto)
        {

            try
            {

                string TextoCifrado;
                Des.Key = HashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                Des.Mode = CipherMode.ECB;
                ICryptoTransform Desdencrypt = Des.CreateEncryptor();
                ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
                Byte[] buff = ASCIIEncoding.ASCII.GetBytes(Texto);
                TextoCifrado = Convert.ToBase64String(Desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
                return TextoCifrado;

            }
            catch (Exception)
            {
                return "";

            }

        }

        /// <summary>
        /// Decriptografa o texto informado como parâmetro
        /// </summary>
        /// <param name="Texto"></param>
        public string DeCifraTexto(string Texto)
        {

            try
            {

                string TextoDecifrado;
                Des.Key = HashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                Des.Mode = CipherMode.ECB;
                ICryptoTransform Desdencrypt = Des.CreateDecryptor();
                Byte[] buff = Convert.FromBase64String(Texto);
                TextoDecifrado = ASCIIEncoding.ASCII.GetString(Desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
                return TextoDecifrado;

            }
            catch (Exception)
            {
                return "";
            }

        }

        #endregion


        ///Funções relacionadas a validações da conta
        #region Validações Gerais da Conta
        /// <summary>
        /// Verifica se a conta logada já possui empresa cadastrada
        /// </summary>
        /// <param name="iCod_Conta"></param>
        /// <returns></returns>
        public string Verifica_Cad_Empresa(string iCod_Conta)
        {

            Tb_Empresa_DAO DAO = new Tb_Empresa_DAO();
            Tb_Empresa Obj = new Tb_Empresa();

            try
            {

                Obj = DAO.Retrieve("SELECT * FROM db_app.tb_empresa WHERE iCod_Conta = " + iCod_Conta).FirstOrDefault();

                if (Obj != null)
                {
                    return Obj.iCod_Empresa.ToString();
                }
                else
                {
                    return "0";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        #endregion


        //Fim da Classe
    }
}