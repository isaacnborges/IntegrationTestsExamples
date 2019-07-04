using FluentValidation;
using HBSIS.Exemplo.Dominio.Comandos;
using System;

namespace HBSIS.Exemplo.Dominio.Validacoes
{
    public abstract class ProdutoValidacao<T> : AbstractValidator<T> where T : ProdutoComando
    {
        protected void ValidarId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidarCodigo()
        {
            RuleFor(c => c.Codigo)
                .GreaterThanOrEqualTo(1).WithMessage("Informe o código.");
        }

        protected void ValidarDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Informe a descrição.")
                .Length(2, 100).WithMessage("A descrição deve conter entre 2 e 100 caracteres.");
        }

        protected void ValidarPreco()
        {
            RuleFor(c => c.Preco)
                .GreaterThanOrEqualTo(0.01).WithMessage("Informe o preço.");
        }
    }
}
