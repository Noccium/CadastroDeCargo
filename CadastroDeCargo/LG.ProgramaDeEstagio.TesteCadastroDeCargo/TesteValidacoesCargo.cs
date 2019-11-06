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
        public void TesteDescricaoFoiInformada()
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

    }
}
