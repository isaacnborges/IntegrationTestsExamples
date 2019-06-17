using HBSIS.Exemplo.Dominio.Comandos;
using HBSIS.Exemplo.Dominio.Interfaces;
using HBSIS.Exemplo.Servicos.Servicos;
using NSubstitute;
using NUnit.Framework;
using System;

namespace HBSIS.Exemplo.Testes.Servicos
{
    [TestFixture]
    public class ProdutoServicoTests
    {
        private IProdutoRepositorio subProdutoRepositorio;

        [SetUp]
        public void SetUp()
        {
            this.subProdutoRepositorio = Substitute.For<IProdutoRepositorio>();
        }

        private ProdutoServico CreateProdutoServico()
        {
            return new ProdutoServico(
                this.subProdutoRepositorio);
        }

        [Test]
        public void Inserir_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateProdutoServico();
            ComandoInserirProduto comando = TODO;

            // Act
            var result = unitUnderTest.Inserir(
                comando);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Atualizar_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateProdutoServico();
            ComandoAtualizarProduto comando = TODO;

            // Act
            var result = unitUnderTest.Atualizar(
                comando);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Remover_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateProdutoServico();
            Guid id = TODO;

            // Act
            unitUnderTest.Remover(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Obter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateProdutoServico();
            Guid id = TODO;

            // Act
            var result = unitUnderTest.Obter(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void BuscarTodos_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateProdutoServico();

            // Act
            var result = unitUnderTest.BuscarTodos();

            // Assert
            Assert.Fail();
        }
    }
}