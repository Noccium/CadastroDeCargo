using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public static class ValidadorDeCargoExtensions
    {
        public static IRuleBuilderOptions<T, int> CodigoMinimoValida<T>(this IRuleBuilder<T, int> ruleBuilder, int valorMinimo) where T : Cargo
        {
            return ruleBuilder.Must(CodigoMinimo(valorMinimo));
        }

        public static IRuleBuilderOptions<T, int> CodigoMaximoValida<T>(this IRuleBuilder<T, int> ruleBuilder, int valorMaximo) where T : Cargo
        {
            return ruleBuilder.Must(CodigoMaximo(valorMaximo));
        }

        public static IRuleBuilderOptions<T, String> DescricaoMinimaValida<T>(this IRuleBuilder<T, String> ruleBuilder, int tamanhoMinimo) where T : Cargo
        {
            return ruleBuilder.Must(DescricaoMinima(tamanhoMinimo));
        }

        public static IRuleBuilderOptions<T, String> DescricaoMaximaValida<T>(this IRuleBuilder<T, String> ruleBuilder, int tamanhoMaximo) where T : Cargo
        {
            return ruleBuilder.Must(DescricaoMaxima(tamanhoMaximo));
        }

        private static bool CodigoMinimo(int codigo, int valorMinimo)
        {
            return codigo >= valorMinimo;
        }

        private static bool CodigoMaximo(int codigo, int valorMaximo)
        {
            return codigo <= valorMaximo;
        }

        private static bool DescricaoMinima(string descricao, int tamanhoMinimo)
        {
            return descricao.Length >= tamanhoMinimo;
        }

        private static bool DescricaoMaxima(string descricao, int tamanhoMaximo)
        {
            return descricao.Length <= tamanhoMaximo;
        }
       

    }
}
