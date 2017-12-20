using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Transportadora
    {

        public int iCod_Transportadora { get; set; }
        public string vNom_Transportadora { get; set; }
        public Tb_Conta iCod_Conta { get; set; }
        public string vTelefone1 { get; set; }
        public string vTelefone2 { get; set; }
        public string vTelefone3 { get; set; }
        public string vTelefone4 { get; set; }

        public string vDes_Observacao { get; set; }

        public override string ToString()
        {
            return vNom_Transportadora;
        }

    }
}