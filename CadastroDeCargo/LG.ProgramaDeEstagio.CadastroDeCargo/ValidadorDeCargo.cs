using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public class ValidadorDeCargo<TCargo> : AbstractValidator<Cargo> where TCargo : Cargo
    {
        private IRepositorioCargo _repositorioCargo;

        public ValidadorDeCargo(IRepositorioCargo repositorioCargo)
        {
            _repositorioCargo = repositorioCargo;
        }
        public void AssineRegraDescricaoObrigatorio()
        {
            RuleFor(cargo => cargo.Descricao)
                .NotEmpty().WithMessage("Descrição do Cargo deve ser informado.");
        }

        public void AssineRegraDescricaoTamanhoMinimo()
        {
            RuleFor(cargo => cargo.Descricao)
                .DescricaoMinimaValida().WithMessage("Descrição do Cargo deve ter no mínimo 2 caracteres.");
                
        }

        public void AssineRegraDescricaoTamanhoMaximo()
        {
            RuleFor(cargo => cargo.Descricao)
                .DescricaoMaximaValida().WithMessage("Descrição do Cargo deve ter no máximo 100 caracteres.");
        }

        public void AssineRegraCodigoTamanhoMinimo()
        {
            RuleFor(cargo => cargo.Codigo)
                .CodigoMinimoValida().WithMessage("Codigo do Cargo deve ser maior ou igual a 1.");
        }

        public void AssineRegraCodigoTamanhoMaximo()
        {
            RuleFor(cargo => cargo.Codigo)
                .CodigoMaximoValida().WithMessage("Codigo do Cargo deve ser menor ou igual a 999999.");
        }

        public void AssineRegraCargoJaCadastrado()
        {
            RuleFor(cargo => cargo.Codigo)
                .Must(VerifiqueCargoNaoCadastrado)
                .WithMessage("Cargo já cadastrado.");
        }

        private bool VerifiqueCargoNaoCadastrado(Cargo cargo, int codigo)
        {
            var cargoConsultado = _repositorioCargo.Consulte(codigo);
            var cargoNaoCadastrado = cargoConsultado == null;

            return cargoNaoCadastrado;
        }
    }
}