using FluentAssertions;
using HBSIS.Exemplo.Dominio.Comandos;
using HBSIS.Exemplo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HBSIS.Exemplo.Teste.Integracao
{
    public class ProdutoTestDojo
    {
        private readonly ContextoTest _context;

        public ProdutoTestDojo()
        {
            _context = new ContextoTest();
        }

        [Fact]
        public async Task Deve_Retornar_Status_OK()
        {
            var comando = new ComandoInserirProduto(1, "Pepsi", 1);
            var result = await _context.Client.PostAsJsonAsync("api/produto", comando);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Deve_Validar_Produto_Inserido()
        {
            var comando = new ComandoInserirProduto(2, "Pepsi Twist", 1);
            var result = await _context.Client.PostAsJsonAsync("api/produto", comando);
            var produtoInserido = await result.Content.ReadAsAsync<Produto>();

            var produtoFinal = await _context.Client.GetAsync($"api/produto/{produtoInserido.Id}");
            var produtoSelect = await produtoFinal.Content.ReadAsAsync<Produto>();

            produtoSelect.Should().BeEquivalentTo(produtoInserido);
        }

        [Fact]
        public async Task Deve_Alterar_Produto_Inserido()
        {
            var comando = new ComandoInserirProduto(3, "Original", 2);
            var result = await _context.Client.PostAsJsonAsync("api/produto", comando);
            var produtoInserido = await result.Content.ReadAsAsync<Produto>();

            var produtoFinal = await _context.Client.GetAsync($"api/produto/{produtoInserido.Id}");
            var produtoSelect = await produtoFinal.Content.ReadAsAsync<Produto>();

            var comandoUpdate = new ComandoAtualizarProduto(produtoSelect.Id,
                produtoSelect.Codigo, "Original 600 ml", 3);

            var updatedResult = await _context.Client.PutAsJsonAsync("api/produto", comandoUpdate);
            var produtoAlterado = await updatedResult.Content.ReadAsAsync<Produto>();

            var produtoAlteradoSelect = await _context.Client.GetAsync($"api/produto/{produtoAlterado.Id}");
            var produtoAlteradoFinal = await produtoAlteradoSelect.Content.ReadAsAsync<Produto>();

            produtoAlteradoFinal.Should().BeEquivalentTo(produtoAlterado);
        }

        [Fact]
        public async Task Deve_Deletar_Produto()
        {
            var comando = new ComandoInserirProduto(3, "Original", 2);
            var result = await _context.Client.PostAsJsonAsync("api/produto", comando);
            var produtoInserido = await result.Content.ReadAsAsync<Produto>();

            await _context.Client.DeleteAsync($"api/produto/{produtoInserido.Id}");
            var produtoDeletadoSelect = await _context.Client.GetAsync($"api/produto/{produtoInserido.Id}");
            var produtoDeletadoFinal = await produtoDeletadoSelect.Content.ReadAsAsync<Produto>();

            produtoDeletadoFinal.Should().BeNull();
        }

        [Fact]
        public async Task Deve_Deletar_Apena_Um()
        {
            var listaProdutos = await _context.Client.GetAsync($"api/produto");
            var produtos = await listaProdutos.Content.ReadAsAsync<IList<Produto>>();

            foreach (var produto in produtos)
            {
                await _context.Client.DeleteAsync($"api/produto/{produto.Id}");
            }

            var comando = new ComandoInserirProduto(3, "Original", 2);
            var comando2 = new ComandoInserirProduto(4, "Budweiser", 2);

            var result = await _context.Client.PostAsJsonAsync("api/produto", comando);
            var produtoInserido = await result.Content.ReadAsAsync<Produto>();
            await _context.Client.PostAsJsonAsync("api/produto", comando2);

            await _context.Client.DeleteAsync($"api/produto/{produtoInserido.Id}");

            listaProdutos = await _context.Client.GetAsync($"api/produto");
            produtos = await listaProdutos.Content.ReadAsAsync<IList<Produto>>();

            produtos.Count.Should().Be(1);
        }

        [Fact]
        public async Task Deve_Buscar_Dado_Nao_Existente()
        {
            var produtoFinal = await _context.Client.GetAsync($"api/produto/{Guid.NewGuid()}");
            produtoFinal.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}