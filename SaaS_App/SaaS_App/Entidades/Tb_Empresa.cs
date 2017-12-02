using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Empresa
    {
        public int iCod_Empresa { get; set; }
        public int iCod_Conta { get; set; }
        public string vNom_Empresa { get; set; }
        public string vNom_Responsavel { get; set; }
        public string vNum_CnpjCpf { get; set; }
        public string vNum_TelefoneComercial { get; set; }
        public string vNum_Celular { get; set; }
        public string vCep { get; set; }
        public string vEndereco { get; set; }
        public string vCidade { get; set; }
        public string vUf { get; set; }
        public DateTime dData_Cadastro { get; set; }

    }
}