using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public static class ValidadorDeCargoExtensions
    {
        public static IRuleBuilderOptions<T, int> CodigoMinimoValida<T>(this IRuleBuilder<T, int> ruleBuilder) where T : Cargo
        {
            return ruleBuilder.Must(CodigoMinimo);
        }

        public static IRuleBuilderOptions<T, int> CodigoMaximoValida<T>(this IRuleBuilder<T, int> ruleBuilder) where T : Cargo
        {
            return ruleBuilder.Must(CodigoMaximo);
        }

        public static IRuleBuilderOptions<T, String> DescricaoMinimaValida<T>(this IRuleBuilder<T, String> ruleBuilder) where T : Cargo
        {
            return ruleBuilder.Must(DescricaoMinima);
        }

        public static IRuleBuilderOptions<T, String> DescricaoMaximaValida<T>(this IRuleBuilder<T, String> ruleBuilder) where T : Cargo
        {
            return ruleBuilder.Must(DescricaoMaxima);
        }

        private static bool CodigoMinimo(int codigo)
        {
            return codigo >= 1;
        }

        private static bool CodigoMaximo(int codigo)
        {
            return codigo <= 999999;
        }

        private static bool DescricaoMinima(string descricao)
        {
            return descricao.Length >= 2;
        }

        private static bool DescricaoMaxima(string descricao)
        {
            return descricao.Length <= 100;
        }
       

    }
}
