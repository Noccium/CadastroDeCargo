using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public class Cargo
    {
        public Guid ID { get; set; }
        public int Codigo { get; set; }
        public string  Descricao { get; set; }

        //public Cargo(int codigo, string descricao)
        //{
        //    Codigo = codigo;
        //    Descricao = descricao;
        //}
    }
}
