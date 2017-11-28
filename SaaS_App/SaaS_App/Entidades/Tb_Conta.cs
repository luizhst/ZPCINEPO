using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Conta
    {
        public int iCod_Conta { get; set; }
        public string vDes_Login { get; set; }
        public string vDes_Senha { get; set; }
        public bool bFlag_Primaria { get; set; }
        public int iCod_Primaria { get; set; }
        public bool bFlag_Ativa { get; set; }
    }
}