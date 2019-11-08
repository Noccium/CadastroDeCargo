using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public static class ValidacoesDePessoaExtensions
    {
        const int CODIGO_TAMANHO_MINIMO = 1;
        const int CODIGO_TAMANHO_MAXIMO = 999999;

        const int NOME_DA_PESSOA_TAMANHO_MINIMO = 2;
        const int NOME_DA_PESSOA_TAMANHO_MAXIMO = 100;

        const int DIA_MINIMO_DATA_DE_NASCIMENTO = 2;
        const int MES_MINIMO_DATA_DE_NASCIMENTO = 1;
        const int ANO_MINIMO_DATA_DE_NASCIMENTO = 1900;

        public static IRuleBuilderOptions<T, int> CodigoTamanhoMinimoValida<T>(this IRuleBuilder<T, int> ruleBuilder) where T : Pessoa
        {
            return ruleBuilder.Must(TesteCodigoTamanhoMinimo);
        }

        public static IRuleBuilderOptions<T, int> CodigoTamanhoMaximoValida<T>(this IRuleBuilder<T, int> ruleBuilder) where T : Pessoa
        {
            return ruleBuilder.Must(TesteCodigoTamanhoMaximo);
        }

        public static IRuleBuilderOptions<T, String> NomeTamanhoMinimoValida<T>(this IRuleBuilder<T, String> ruleBuilder) where T : Pessoa
        {
            return ruleBuilder.Must(TesteNomeTamanhoMinimo)
                    .When(pessoa => !string.IsNullOrWhiteSpace(pessoa.Nome));
        }

        public static IRuleBuilderOptions<T, String> NomeTamanhoMaximoValida<T>(this IRuleBuilder<T, String> ruleBuilder) where T : Pessoa
        {
            return ruleBuilder.Must(TesteNomeTamanhoMaximo)
                .When(pessoa => !string.IsNullOrWhiteSpace(pessoa.Nome));
        }

        public static IRuleBuilderOptions<T, string> CPFValida<T>(this IRuleBuilder<T, string> ruleBuilder) where T : Pessoa
        {
            return ruleBuilder.Must(TesteCPFValido);
        }

        public static IRuleBuilderOptions<T, DateTime> DataDeNascimentoMenorQuePermitidaValida<T>(this IRuleBuilder<T, DateTime> ruleBuilder) where T : Pessoa
        {
            return ruleBuilder.Must(TesteDataDeNascimentoMenorQuePermitida);
        }
       
        public static IRuleBuilderOptions<T, DateTime> DataDeNascimentoMaiorOuIgualQueDataAtualValida<T>(this IRuleBuilder<T, DateTime> ruleBuilder) where T : Pessoa
        {
            return ruleBuilder.Must(TesteDataDeNascimentoMaiorOuIgualQueDataAtual);
        }

        private static bool TesteCodigoTamanhoMinimo(int codigo)
        {
            return codigo >= CODIGO_TAMANHO_MINIMO;
        }

        private static bool TesteCodigoTamanhoMaximo(int codigo)
        {
            return codigo <= CODIGO_TAMANHO_MAXIMO;
        }

        private static bool TesteNomeTamanhoMinimo(string nomeDaPessoa)
        {
            return nomeDaPessoa.Trim().Length >= NOME_DA_PESSOA_TAMANHO_MINIMO;
        }

        private static bool TesteNomeTamanhoMaximo(string nomeDaPessoa)
        {
            return nomeDaPessoa.Trim().Length <= NOME_DA_PESSOA_TAMANHO_MAXIMO;
        }

        public static bool TesteCPFValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool TesteDataDeNascimentoMenorQuePermitida(DateTime dataDeNascimento)
        {
            return dataDeNascimento > new DateTime(ANO_MINIMO_DATA_DE_NASCIMENTO, 
                                                   MES_MINIMO_DATA_DE_NASCIMENTO, 
                                                   DIA_MINIMO_DATA_DE_NASCIMENTO);
        }

        public static bool TesteDataDeNascimentoMaiorOuIgualQueDataAtual(DateTime dataDeNascimento)
        {
            return dataDeNascimento < DateTime.Now;
        }
    }
}
