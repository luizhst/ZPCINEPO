using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Produto
    {

        public int iCod_Produto { get; set; }
        public int iCod_Conta { get; set; }
        public int iCod_Categoria { get; set; }
        public string vNom_Produto { get; set; }
        public double dPreco_Custo { get; set; }
        public double dPreco_Venda { get; set; }
        public string vQtd_Estoque { get; set; }
        public string vQtd_Min_Estoque { get; set; }
        public DateTime dData_Cadastro { get; set; }

        public override string ToString()
        {
            return vNom_Produto;
        }

    }
}