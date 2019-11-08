using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.ProgramaDeEstagio.CadastroDeCargo.Contrato
{
    public interface IRepositorioContrato
    {
        Contrato Consulte(int matricula);
    }
}
