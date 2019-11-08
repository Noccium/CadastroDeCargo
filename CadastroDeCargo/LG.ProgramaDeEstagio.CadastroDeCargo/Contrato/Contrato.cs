using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.ProgramaDeEstagio.CadastroDeCargo.Contrato
{
    public class Contrato
    {
        public Guid ID { get; set; }
        public int Matricula { get; set; }
        public Pessoa Pessoa { get; set; }
        public DateTime DataDeAdmissao { get; set; }
        public Cargo Cargo { get; set; }
    }
}
