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
                .DescricaoMinimaValida().WithMessage("Descrição do Cargo deve ter no mínimo 2 caracteres.");
        }

        public void AssineRegraDescricaoTamanhoMaximo()
        {
            RuleFor(cargo => cargo.Descricao)
                .DescricaoMaximaValida().WithMessage("Descrição do Cargo deve ter no máximo 100 caracteres.");
        }


    }
}
