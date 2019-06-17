using System.Net;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using HBSIS.Exemplo.Dominio.Comandos;

namespace HBSIS.Exemplo.Teste.Integracao
{
    public class ValuesTest
    {
        private readonly TestContext _testContext;
        public ValuesTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/produto/");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Deve_Inserir_Produto()
        {
            var novoPproduto = NovoProduto();
            var content = new StringContent(JsonConvert.SerializeObject(novoPproduto), Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("api/produto/", content);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public ComandoInserirProduto NovoProduto()
        {
            return new ComandoInserirProduto(9999, "PELO_TESTE", 90);
        }
    }
}
