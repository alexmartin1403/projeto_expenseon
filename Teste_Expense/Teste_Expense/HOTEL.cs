using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste_Expense
{
    public class HOTEL
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string RES_HOTEL { get; set; }
        public byte ESTRELAS { get; set; }
        public string LOGRADOURO { get; set; }
        public int NUMERO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string ESTADO { get; set; }
        public bool ESTACIONAMENTO { get; set; }
        public bool PISCINA { get; set; }
        public bool SAUNA { get; set; }
        public bool WIFI { get; set; }
        public bool RESTAURANTE { get; set; }
        public bool BAR { get; set; }
        public bool ACADEMIA { get; set; }
    }
}