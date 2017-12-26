using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Saida
    {
        public int iCod_Saida { get; set; }
        public Tb_Conta iCod_Conta { get; set; }
        public Tb_Produto iCod_Produto { get; set; }
        public string vQtd_Saida { get; set; }
        public string vQtd_EstoqueAnt { get; set; }
        public string vQtd_EstoqueAtual { get; set; }
        public DateTime dData_Saida { get; set; }
        public bool bFlag_Entrada { get; set; }

        public override string ToString()
        {
            return iCod_Produto.vNom_Produto;
        }
    }
}