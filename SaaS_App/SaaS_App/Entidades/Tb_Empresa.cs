using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS_App.Entidades
{
    public class Tb_Empresa
    {
        public int iCodEmpresa { get; set; }
        public int iCodConta { get; set; }
        public string vNomEmpresa { get; set; }
        public string vNomResponsavel { get; set; }
        public string vNumCnpjCpf { get; set; }
        public string vNumTelefoneComercial { get; set; }
        public string vNumCelular { get; set; }
        public string vCep { get; set; }
        public string vEndereco { get; set; }
        public string vCidade { get; set; }
        public string vUf { get; set; }


    }
}