using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LG.ProgramaDeEstagio.CadastroDeCargo;
using Rhino.Mocks;

namespace LG.ProgramaDeEstagio.TesteCadastroDeCargo
{
    [TestFixture]
    public class TesteValidacoesCargo
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TesteAssineRegraDescricaoObrigatoria(string descricao)
        {
            var cargo = new Cargo()
            {
                Descricao = descricao
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>(null);

            validadorDeCargo.AssineRegraDescricaoObrigatorio();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual(
                "Descrição do Cargo deve ser informado.",
                resultado.Errors[0].ErrorMessage);
            Assert.AreEqual(
                "Descricao",
                resultado.Errors[0].PropertyName);
        }

        [Test]
        public void TesteDescricaoFoiInformadaCorretamente()
        {
            var cargo = new Cargo()
            {
                Descricao = "Desenvolvedor"
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>(null);

            validadorDeCargo.AssineRegraDescricaoObrigatorio();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        [TestCase("D")]
        [TestCase(" D")]
        [TestCase("D ")]
        public void TesteAssineRegraDescricaoTamanhoMinimo(string descricao)
        {
            var cargo = new Cargo()
            {
                Descricao = descricao
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>(null);

            validadorDeCargo.AssineRegraDescricaoTamanhoMinimo();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual(
                "Descrição do Cargo deve ter no mínimo 2 caracteres.",
                resultado.Errors[0].ErrorMessage);
            Assert.AreEqual(
                "Descricao",
                resultado.Errors[0].PropertyName);
        }

        [Test]
        [TestCase("De")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TesteAssineRegraDescricaoTamanhoMinimoValido(string descricao)
        {
            var cargo = new Cargo()
            {
                Descricao = descricao
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>(null);

            validadorDeCargo.AssineRegraDescricaoTamanhoMinimo();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        public void TesteAssineRegraDescricaoTamanhoMaximo()
        {
            var cargo = new Cargo()
            {
                Descricao =new string('A', 101)
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>(null);

            validadorDeCargo.AssineRegraDescricaoTamanhoMaximo();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual(
                "Descrição do Cargo deve ter no máximo 100 caracteres.",
                resultado.Errors[0].ErrorMessage);
            Assert.AreEqual(
                "Descricao",
                resultado.Errors[0].PropertyName);
        }

        [Test]
        [TestCase(0)]
        [TestCase(100)]
        public void TesteAssineRegraDescricaoTamanhoMaximoValido(int tamanhoDescricao)
        {
            var cargo = new Cargo()
            {
                Descricao = new string('A', tamanhoDescricao)
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>(null);

            validadorDeCargo.AssineRegraDescricaoTamanhoMaximo();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        [TestCase(0)]
        public void TesteAssineRegraCodigoTamanhoMinimo(int codigo)
        {
            var cargo = new Cargo()
            {
                Codigo = codigo
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>(null);

            validadorDeCargo.AssineRegraCodigoTamanhoMinimo();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual(
                "Codigo do Cargo deve ser maior ou igual a 1.",
                resultado.Errors[0].ErrorMessage);
            Assert.AreEqual(
                "Codigo",
                resultado.Errors[0].PropertyName);
        }

        [Test]
        [TestCase(1000000)]
        public void TesteAssineRegraCodigoTamanhoMaximo(int codigo)
        {
            var cargo = new Cargo()
            {
                Codigo = codigo
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>(null);

            validadorDeCargo.AssineRegraCodigoTamanhoMaximo();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual(
                "Codigo do Cargo deve ser menor ou igual a 999999.",
                resultado.Errors[0].ErrorMessage);
            Assert.AreEqual(
                "Codigo",
                resultado.Errors[0].PropertyName);
        }


        [Test]
        public void TesteAssineRegraCargoJacadastrado()
        {
            var cargo = new Cargo();

            var mockRepositorio = new MockRepository(); // DLL 

            var repositorio = mockRepositorio.StrictMock<IRepositorioCargo>();

            using (mockRepositorio.Record())
            {
                repositorio.Consulte(1);
                LastCall.Return(new Cargo());
                LastCall.IgnoreArguments();
            }

            var validadorDeCargo = new ValidadorDeCargo<Cargo>(repositorio);

            validadorDeCargo.AssineRegraCargoJaCadastrado();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual(
                "Cargo já cadastrado.",
                resultado.Errors[0].ErrorMessage);
            Assert.AreEqual(
                "Codigo",
                resultado.Errors[0].PropertyName);
        }

        [Test]
        public void TesteAssineRegraCargoNaoCadastrado()
        {
            var cargo = new Cargo();

            var mockRepositorio = new MockRepository(); // DLL 

            var repositorio = mockRepositorio.StrictMock<IRepositorioCargo>();

            using (mockRepositorio.Record())
            {
                repositorio.Consulte(0);
                LastCall.Return(null);
                LastCall.IgnoreArguments();
            }
            var validadorDeCargo = new ValidadorDeCargo<Cargo>(repositorio);

            validadorDeCargo.AssineRegraCargoJaCadastrado();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(0, resultado.Errors.Count);
        }   
    }
}