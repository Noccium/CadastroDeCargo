using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace LG.ProgramaDeEstagio.CadastroDeCargo
{
    public class ValidacoesPessoa<TPessoa> : AbstractValidator<Pessoa> where TPessoa : Pessoa
    {
        public void AssineRegraCodigoTamanhoMinimo()
        {
            RuleFor(pessoa => pessoa.Codigo)
                .CodigoTamanhoMinimoValida()
                .WithMessage("Codigo da Pessoa deve ser maior ou igual a 1.");
        }

        public void AssineRegraCodigoTamanhoMaximo()
        {
            RuleFor(pessoa => pessoa.Codigo)
                .CodigoTamanhoMaximoValida()
                .WithMessage("Codigo da Pessoa deve ser menor ou igual a 999999.");
        }

        public void AssineRegraNomeObrigatorio()
        {
            RuleFor(pessoa => pessoa.Nome)
                .NotEmpty()
                .WithMessage("Nome da Pessoa deve ser informado.");
        }

        public void AssineRegraNomeMinimo()
        {
            RuleFor(pessoa => pessoa.Nome)
                .NomeTamanhoMinimoValida()
                .WithMessage("Nome da Pessoa deve ter no mínimo 2 caracteres.")
                .When(pessoa => !string.IsNullOrEmpty(pessoa.Nome));
        }

        public void AssineRegraNomeMaximo()
        {
            RuleFor(pessoa => pessoa.Nome)
                .NomeTamanhoMaximoValida()
                .WithMessage("Nome da Pessoa deve ter no máximo 100 caracteres.")
                .When(pessoa => !string.IsNullOrEmpty(pessoa.Nome)); ;
        }

        public void AssineRegraCPF()
        {
            RuleFor(pessoa => pessoa.CPF)
                .CPFValida()
                .WithMessage("CPF inválido.");
        }

        public void AssineRegraDataDeNascimentoObrigatoria()
        {
            RuleFor(pessoa => pessoa.DataDeNascimento)
                .NotEmpty()
                .WithMessage("Data de nascimento deve ser informada.");
        }

        public void AssineRegraDataDeNascimentoMenorQuePermitida()
        {
            RuleFor(pessoa => pessoa.DataDeNascimento)
                .DataDeNascimentoMenorQuePermitidaValida()
                .WithMessage("A Data de Nascimento não pode ser inferior a 02/01/1900.");
        }

        public void AssineRegraDataDeNascimentoMaiorOuIgualQueDataAtual()
        {
            RuleFor(pessoa => pessoa.DataDeNascimento)
               .DataDeNascimentoMaiorOuIgualQueDataAtualValida()
               .WithMessage("A Data de Nascimento não pode ser maior ou igual que a data atual.");
        }
    }
}
