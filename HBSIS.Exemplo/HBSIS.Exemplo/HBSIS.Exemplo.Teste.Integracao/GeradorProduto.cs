using Bogus;
using HBSIS.Exemplo.Dominio.Comandos;
using HBSIS.Exemplo.Dominio.Entidades;
using System;

namespace HBSIS.Exemplo.Teste.Integracao
{
    public static class GeradorProduto
    {
        public static Faker<ComandoInserirProduto> ComandoNovoProduto()
        {
            var novoProduto = new Faker<ComandoInserirProduto>()
                    .RuleFor(c => c.Id, f => Guid.NewGuid())
                    .RuleFor(c => c.Codigo, f => f.Random.Int(1, 9999))
                    .RuleFor(c => c.Descricao, f => f.Commerce.ProductName())
                    .RuleFor(c => c.Preco, f => Math.Round(f.Random.Double(1, 9999), 2))
                    .RuleFor(c => c.ValidationResult, f => new FluentValidation.Results.ValidationResult());

            return novoProduto;
        }

        public static Faker<Produto> NovoProduto()
        {
            var novoProduto = new Faker<Produto>()
                    .RuleFor(c => c.Id, f => Guid.NewGuid())
                    .RuleFor(c => c.Codigo, f => f.Random.Int(1, 9999))
                    .RuleFor(c => c.Descricao, f => f.Commerce.ProductName())
                    .RuleFor(c => c.Preco, f => Math.Round(f.Random.Double(1, 9999), 2));

            return novoProduto;
        }
    }
}
