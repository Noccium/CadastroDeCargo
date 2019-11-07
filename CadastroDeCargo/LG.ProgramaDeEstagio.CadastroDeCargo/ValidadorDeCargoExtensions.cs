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
            return ruleBuilder.Must(DescricaoMinima)
                    .When(cargo => !string.IsNullOrWhiteSpace(cargo.Descricao));
        }

        public static IRuleBuilderOptions<T, String> DescricaoMaximaValida<T>(this IRuleBuilder<T, String> ruleBuilder) where T : Cargo
        {
            return ruleBuilder.Must(DescricaoMaxima)
                .When(cargo => !string.IsNullOrWhiteSpace(cargo.Descricao));
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
            return descricao.Trim().Length >= 2;
        }

        private static bool DescricaoMaxima(string descricao)
        {
            return descricao.Trim().Length <= 100;
        }

        //private static bool CodigoMinimo(int codigo, int valorMinimo)
        //{
        //    return codigo >= valorMinimo;
        //}

        //private static bool CodigoMaximo(int codigo, int valorMaximo)
        //{
        //    return codigo <= valorMaximo;
        //}

        //private static bool DescricaoMinima(string descricao, int tamanhoMinimo)
        //{
        //    return descricao.Length >= tamanhoMinimo;
        //}

        //private static bool DescricaoMaxima(string descricao, int tamanhoMaximo)
        //{
        //    return descricao.Length <= tamanhoMaximo;
        //}


    }
}