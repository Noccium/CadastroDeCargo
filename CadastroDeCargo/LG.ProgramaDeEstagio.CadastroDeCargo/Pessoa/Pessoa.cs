using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public class Pessoa
    {
        public Guid ID { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
