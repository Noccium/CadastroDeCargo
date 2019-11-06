using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public class ValidadorDeCargo<TCargo> : AbstractValidator<Cargo> where TCargo : Cargo
    {
        public void AssineRegraDescricaoObrigatorio()
        {
            RuleFor(cargo => cargo.Descricao)
                .NotEmpty().WithMessage("Descrição do Cargo deve ser informado.");
        }

        public void AssineRegraDescricaoTamanhoMinimo()
        {
            RuleFor(cargo => cargo.Descricao)
                .DescricaoMinimaValida(2).WithMessage("Descrição do Cargo deve ter no mínimo 2 caracteres.");
        }

        public void AssineRegraDescricaoTamanhoMaximo()
        {
            RuleFor(cargo => cargo.Descricao)
                .DescricaoMaximaValida(100).WithMessage("Descrição do Cargo deve ter no máximo 100 caracteres.");
        }

        public void AssineRegraCodigoTamanhoMinimo()
        {
            RuleFor(cargo => cargo.Codigo)
                .CodigoMinimoValida(1).WithMessage("Codigo do Cargo deve ser maior ou igual a 1.");
        }

        public void AssineRegraCodigoTamanhoMaximo()
        {
            RuleFor(cargo => cargo.Codigo)
                .CodigoMaximoValida(999999).WithMessage("Codigo do Cargo deve ser menor ou igual a 999999.");
        }
    }
}
