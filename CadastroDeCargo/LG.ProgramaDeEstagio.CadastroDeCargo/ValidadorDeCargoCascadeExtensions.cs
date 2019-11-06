using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public static class ValidadorDeCargoCascadeExtensions
    {
        public static IRuleBuilderOptions<T, int> ValidaCodigo<T>(this IRuleBuilderInitial<T, int> ruleBuilder) where T : Cargo
        {
            return ruleBuilder.Cascade(CascadeMode.StopOnFirstFailure)
                                                
                                                .CodigoMinimoValida().WithMessage("")
                                                .CodigoMaximoValida().WithMessage("");
                                                
        }

        public static IRuleBuilderOptions<T, string> ValidaDescricao<T>(this IRuleBuilderInitial<T, string> ruleBuilder) where T : Cargo
        {
            return ruleBuilder.Cascade(CascadeMode.Continue)
                              .NotNull().WithMessage("Descrição do Cargo deve ser informado.")
                              .NotEmpty().WithMessage("Descrição do Cargo deve ser informado.")
                              .DescricaoMinimaValida().WithMessage("Descrição do Cargo deve ter no mínimo 2 caracteres.")
                              .DescricaoMaximaValida().WithMessage("Descrição do Cargo deve ter no máximo 100 caracteres.");
                
        }
    }
}
