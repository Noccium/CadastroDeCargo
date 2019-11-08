using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LG.ProgramaDeEstagio.CadastroDeCargo;
using FluentValidation.Results;

namespace LG.ProgramaDeEstagio.TesteCadastroDeCargo
{
    [TestFixture]
    public class TesteValidacoesPessoa
    {
        public Pessoa Pessoa { get; set; }
        public ValidacoesPessoa<Pessoa> ValidadorDePessoa { get; set; }

        [SetUp]
        public void TesteIniciaClasse()
        {
           Pessoa = new Pessoa();
           ValidadorDePessoa = new ValidacoesPessoa<Pessoa>();
        }

        [Test]
        [TestCase(0)]
        public void TesteAssineRegraCodigoTamanhoMinimo(int codigo)
        {
            Pessoa.Codigo = codigo;

            ValidadorDePessoa.AssineRegraCodigoTamanhoMinimo();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            string mensagemDeErro = "Codigo da Pessoa deve ser maior ou igual a 1.";
            string nomeDaPropriedade = "Codigo";

            CheckResult(resultado, mensagemDeErro, nomeDaPropriedade);
        }

        [Test]
        [TestCase(1)]
        public void TesteAssineRegraCodigoTamanhoMinimoValido(int codigo)
        {
            Pessoa.Codigo = codigo;

            ValidadorDePessoa.AssineRegraCodigoTamanhoMinimo();

            var resultado = ValidadorDePessoa.Validate(Pessoa);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        [TestCase(1000000)]
        public void TesteAssineRegraCodigoTamanhoMaximo(int codigo)
        {
            Pessoa.Codigo = codigo;

            ValidadorDePessoa.AssineRegraCodigoTamanhoMaximo();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            string mensagemDeErro = "Codigo da Pessoa deve ser menor ou igual a 999999.";
            string nomeDaPropriedade = "Codigo";

            CheckResult(resultado, mensagemDeErro, nomeDaPropriedade);
        }

        [Test]
        [TestCase(999999)]
        public void TesteAssineRegraCodigoTamanhoMaximoValido(int codigo)
        {
            Pessoa.Codigo = codigo;

            ValidadorDePessoa.AssineRegraCodigoTamanhoMaximo();

            var resultado = ValidadorDePessoa.Validate(Pessoa);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TesteAssineRegraNomeObrigatorio(string nome)
        {
            Pessoa.Nome = nome;

            ValidadorDePessoa.AssineRegraNomeObrigatorio();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            string mensagemDeErro = "Nome da Pessoa deve ser informado.";
            string nomeDaPropriedade = "Nome";

            CheckResult(resultado, mensagemDeErro, nomeDaPropriedade);
        }

        [Test]
        [TestCase("P")]
        public void TesteAssineRegraNomeObrigatorioValido(string nome)
        {
            Pessoa.Nome = nome;

            ValidadorDePessoa.AssineRegraNomeObrigatorio();

            var resultado = ValidadorDePessoa.Validate(Pessoa);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        [TestCase("P")]
        public void TesteAssineRegraNomeMinimo(string nome)
        {
            Pessoa.Nome = nome;

            ValidadorDePessoa.AssineRegraNomeMinimo();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            string mensagemDeErro = "Nome da Pessoa deve ter no mínimo 2 caracteres.";
            string nomeDaPropriedade = "Nome";

            CheckResult(resultado, mensagemDeErro, nomeDaPropriedade);
        }

        [Test]
        [TestCase("Pe")]
        public void TesteAssineRegraNomeMinimoValido(string nome)
        {
            Pessoa.Nome = nome;

            ValidadorDePessoa.AssineRegraNomeMinimo();

            var resultado = ValidadorDePessoa.Validate(Pessoa);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        [TestCase(101)]
        public void TesteAssineRegraNomeMaximo(int tamanhoNome)
        {
            Pessoa.Nome = new string('P', tamanhoNome);

            ValidadorDePessoa.AssineRegraNomeMaximo();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            string mensagemDeErro = "Nome da Pessoa deve ter no máximo 100 caracteres.";
            string nomeDaPropriedade = "Nome";

            CheckResult(resultado, mensagemDeErro, nomeDaPropriedade);
        }

        [Test]
        [TestCase(100)]
        public void TesteAssineRegraNomeMaximoValido(int tamanhoNome)
        {
            Pessoa.Nome = new string('P', 100);

            ValidadorDePessoa.AssineRegraNomeMaximo();

            var resultado = ValidadorDePessoa.Validate(Pessoa);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        [TestCase("12345678912")]
        public void TesteAssineRegraCPF(string cpf)
        {
            Pessoa.CPF = cpf;

            ValidadorDePessoa.AssineRegraCPF();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            string mensagemDeErro = "CPF inválido.";
            string nomeDaPropriedade = "CPF";

            CheckResult(resultado, mensagemDeErro, nomeDaPropriedade);
        }

        [Test]
        [TestCase("213.169.190-48")]
        public void TesteAssineRegraCPFValido(string cpf)
        {
            Pessoa.CPF = cpf;

            ValidadorDePessoa.AssineRegraCPF();

            var resultado = ValidadorDePessoa.Validate(Pessoa);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        [TestCase(null)]
        public void TesteAssineRegraDataDeNascimentoObrigatoria(DateTime dataDeNascimento)
        {
            Pessoa.DataDeNascimento = dataDeNascimento;

            ValidadorDePessoa.AssineRegraDataDeNascimentoObrigatoria();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            string mensagemDeErro = "Data de nascimento deve ser informada.";
            string nomeDaPropriedade = "DataDeNascimento";

            CheckResult(resultado, mensagemDeErro, nomeDaPropriedade);

        }

        [Test]
        public void TesteAssineRegraDataDeNascimentoObrigatoriaValido()
        {
            Pessoa.DataDeNascimento = new DateTime(2001, 1, 1);

            ValidadorDePessoa.AssineRegraDataDeNascimentoObrigatoria();

            var resultado = ValidadorDePessoa.Validate(Pessoa);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        public void TesteAssinePegraDataDeNascimentoMenorQuePermitida()
        {
            Pessoa.DataDeNascimento = new DateTime(1900, 1, 1);

            ValidadorDePessoa.AssineRegraDataDeNascimentoMenorQuePermitida();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            string mensagemDeErro = "A Data de Nascimento não pode ser inferior a 02/01/1900.";
            string nomeDaPropriedade = "DataDeNascimento";

            CheckResult(resultado, mensagemDeErro, nomeDaPropriedade);
        }

        [Test]
        public void TesteAssinePegraDataDeNascimentoMenorQuePermitidaValido()
        {
            Pessoa.DataDeNascimento = new DateTime(2000, 1, 1);

            ValidadorDePessoa.AssineRegraDataDeNascimentoMenorQuePermitida();

            var resultado = ValidadorDePessoa.Validate(Pessoa);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        public void TesteAssineRegraDataDeNascimentoMaiorOuIgualQueDataAtual()
        {
            Pessoa.DataDeNascimento = DateTime.Now.AddDays(1);

            ValidadorDePessoa.AssineRegraDataDeNascimentoMaiorOuIgualQueDataAtual();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            string mensagemDeErro = "A Data de Nascimento não pode ser maior ou igual que a data atual.";
            string nomeDaPropriedade = "DataDeNascimento";

            CheckResult(resultado, mensagemDeErro, nomeDaPropriedade);     
        }

        [Test]
        public void TesteAssineRegraDataDeNascimentoMaiorOuIgualQueDataAtualValido()
        {
            Pessoa.DataDeNascimento = new DateTime(2000, 1, 1);

            ValidadorDePessoa.AssineRegraDataDeNascimentoMaiorOuIgualQueDataAtual();

            var resultado = ValidadorDePessoa.Validate(Pessoa);
            Assert.AreEqual(0, resultado.Errors.Count);    
        }

        private static void CheckResult(ValidationResult resultado,
                                        string mensagemDeErro,
                                        string nomeDaPropriedade)
        {
            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual(mensagemDeErro,
                            resultado.Errors[0].ErrorMessage);
            Assert.AreEqual(nomeDaPropriedade,
                            resultado.Errors[0].PropertyName);
        }
    }
}
