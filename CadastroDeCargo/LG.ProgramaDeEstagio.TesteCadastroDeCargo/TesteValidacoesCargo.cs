using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LG.ProgramaDeEstagio.CadastroDeCargo;

namespace LG.ProgramaDeEstagio.TesteCadastroDeCargo
{
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

            var validadorDeCargo = new ValidadorDeCargo<Cargo>();

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

            var validadorDeCargo = new ValidadorDeCargo<Cargo>();

            validadorDeCargo.AssineRegraDescricaoObrigatorio();

            var resultado = validadorDeCargo.Validate(cargo);

            Assert.AreEqual(0, resultado.Errors.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase("D")]
        public void TesteAssineRegraDescricaoTamanhoMinimo(string descricao)
        {
            var cargo = new Cargo()
            {
                Descricao = descricao
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>();

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
        [TestCase("")]
        [TestCase(RandomString(100))]
        public void TesteAssineRegraDescricaoTamanhoMaximo(string descricao)
        {
            var cargo = new Cargo()
            {
                Descricao = descricao
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>();

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
        public void TesteAssineRegraCodigoTamanhoMinimo(int codigo)
        {
             var cargo = new Cargo()
            {
                Codigo = codigo
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>();

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
        public void TesteAssineRegraCodigoTamanhoMinimo(int codigo)
        {
             var cargo = new Cargo()
            {
                Codigo = codigo
            };

            var validadorDeCargo = new ValidadorDeCargo<Cargo>();

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

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
