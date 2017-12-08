using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Veiculo
    {

        public int iCod_Veiculo { get; set; }
        public string vNum_Implacacao { get; set; }
        public string vTipo_Veiculo { get; set; }
        public string vDes_Veiculo { get; set; }
        public int iCod_Transportadora { get; set; }

        public override string ToString()
        {
            return vNum_Implacacao;
        }

    }
}