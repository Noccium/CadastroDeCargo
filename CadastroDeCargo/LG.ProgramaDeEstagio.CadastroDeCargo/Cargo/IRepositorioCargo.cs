using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public interface IRepositorioCargo
    {
        Cargo Consulte(int codigo);
    }
}
