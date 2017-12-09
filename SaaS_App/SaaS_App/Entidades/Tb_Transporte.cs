using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Transporte
    {

        public int iCod_Transporte { get; set; }
        public string vNom_Transportadora { get; set; }
        public string vDes_Observacao { get; set; }
        public int iCod_Empresa { get; set; }
        public override string ToString()
        {
            return vNom_Transportadora;
        }

    }
}