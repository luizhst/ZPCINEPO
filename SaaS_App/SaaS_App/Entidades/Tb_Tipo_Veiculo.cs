using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Tipo_Veiculo
    {

        public int iCod_TipoVeiculo { get; set; }
        public string vDes_TipoVeiculo { get; set; }
        public int iCod_Veiculo { get; set; }

        public override string ToString()
        {
            return vDes_TipoVeiculo;
        }

    }
}