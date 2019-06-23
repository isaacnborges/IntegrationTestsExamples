using FluentAssertions;
using HBSIS.Exemplo.Dominio.Comandos;
using HBSIS.Exemplo.Dominio.Entidades;
using HBSIS.Exemplo.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HBSIS.Exemplo.Teste.Integracao
{
    public class ProdutoTest
    {
        private readonly ContextoTest _testContext;
        private readonly IProdutoRepositorio repositorio;

        public ProdutoTest()
        {
            _testContext = new ContextoTest();
            repositorio = _testContext.ServiceProvider.GetService<IProdutoRepositorio>();
        }

        [Fact]
        public async Task Deve_Retornar_Produto()
        {
            Produto produto = GeradorProduto.NovoProduto();
            repositorio.Inserir(produto);

            var response = await _testContext.Client.GetAsync($"api/produto/{produto.Id}");
            var responseProduto = await response.Content.ReadAsAsync<Produto>();
            responseProduto.Should().BeEquivalentTo(produto);
        }

        [Fact]
        public async Task Deve_Retornar_Todos_Os_Produtos()
        {
            var response = await _testContext.Client.GetAsync("/api/produto/");
            var responseProdutos = await response.Content.ReadAsAsync<IList<Produto>>();

            var produtos = repositorio.BuscarTodos();

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseProdutos.Should().BeEquivalentTo(produtos).And.BeInAscendingOrder(x => x.Descricao);
        }

        [Fact]
        public async Task Deve_Inserir_Produto()
        {
            ComandoInserirProduto novoProduto = GeradorProduto.ComandoNovoProduto();
            var response = await _testContext.Client.PostAsJsonAsync("api/produto/", novoProduto);
            var responseProduto = await response.Content.ReadAsAsync<Produto>();
            var produtoFake = ProdutoFake(novoProduto.Codigo, novoProduto.Descricao, novoProduto.Preco);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseProduto.Should().BeEquivalentTo(produtoFake, option => option.Excluding(x => x.Id));
        }

        [Fact]
        public async Task Deve_Atualizar_Produto()
        {
            Produto produtoInserir = GeradorProduto.NovoProduto();
            repositorio.Inserir(produtoInserir);

            var produto = repositorio.Obter(produtoInserir.Id);
            produto.Codigo += 1;
            produto.Descricao += "-Atualizar";
            produto.Preco += produto.Preco;

            var response = await _testContext.Client.PutAsJsonAsync("api/produto/", produto);
            var responseProduto = await response.Content.ReadAsAsync<Produto>();
            var produtoFake = ProdutoFake(produto.Codigo, produto.Descricao, produto.Preco);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseProduto.Should().BeEquivalentTo(produtoFake, option => option.Excluding(x => x.Id));
        }

        [Fact]
        public async Task Deve_Remover_Produto()
        {
            Produto produto = GeradorProduto.NovoProduto();
            repositorio.Inserir(produto);

            var response = await _testContext.Client.DeleteAsync($"api/produto/{produto.Id}");
            var produtoExcluido = repositorio.Obter(produto.Id);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            produtoExcluido.Should().BeNull();
        }

        [Fact]
        public async Task Produto_Nao_Encontrado()
        {
            var produtos = repositorio.BuscarTodos();
            foreach (var produto in produtos)
                repositorio.Remover(produto.Id);

            var produtoId = Guid.NewGuid();
            var response = await _testContext.Client.GetAsync($"/api/products/{produtoId}");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }

        private Produto ProdutoFake(int codigo, string descricao, double preco)
        {
            var produto = new Produto(codigo, descricao, preco);
            return produto;
        }
    }
}
