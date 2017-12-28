using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Categoria_Produto
    {

        public int iCod_Categoria { get; set; }
        public string vNom_Categoria { get; set; }
        public int iCod_Conta { get; set; }

        public override string ToString()
        {
            return vNom_Categoria;
        }

    }
}