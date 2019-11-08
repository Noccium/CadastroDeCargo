using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace LG.ProgramaDeEstagio.CadastroDeCargo.Contrato
{
    public class ValidacoesDeContrato<TContrato> : AbstractValidator<Contrato> where TContrato : Contrato
    {
        private IRepositorioContrato _repositorioContrato;

        public ValidacoesDeContrato(IRepositorioContrato repositorioContrato)
        {
            _repositorioContrato = repositorioContrato;
        }

        public void AssineRegraContratoJaCadastrado()
        {
            RuleFor(contrato => contrato.Matricula)
                .Must(VerifiqueContratoNaoCadastrado)
                .WithMessage("Contrato já cadastrado.");
        }

        private bool VerifiqueContratoNaoCadastrado(Contrato contrato, int matricula)
        {
            var contratoConsultado = _repositorioContrato.Consulte(matricula);
            var contratoNaoCadastrado = contratoConsultado == null;

            return contratoNaoCadastrado;
        }
    }
}
