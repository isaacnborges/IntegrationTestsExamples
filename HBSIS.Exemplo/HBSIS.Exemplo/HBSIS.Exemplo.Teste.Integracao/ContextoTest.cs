using HBSIS.Exemplo.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace HBSIS.Exemplo.Teste.Integracao
{
    public class ContextoTest
    {
        public HttpClient Client;
        public IServiceProvider ServiceProvider;
        private TestServer _server;
        private IServiceScope _scope;

        public ContextoTest()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseSetting("ConnectionStrings:DefaultConnection", "Server=(localdb)\\mssqllocaldb;Database=ExemploDB;Trusted_Connection=True;MultipleActiveResultSets=True;"));

            Client = _server.CreateClient();
            _scope = _server.Host.Services.CreateScope();
            ServiceProvider = _scope.ServiceProvider;
        }
    }
}
