using System;

namespace Avanade.SmartApps.Logger
{
    public class Log
    {
        public string IdCorrelacao { get; set; }
        public DateTime DataHora { get; set; }
        public string Ip { get; set; }
        public string Maquina { get; set; }
        public string Usuario { get; set; }
        public string SistemaOrigem { get; set; }
        public string Tipo { get; set; }
        public string Dados { get; set; }
    }
}
