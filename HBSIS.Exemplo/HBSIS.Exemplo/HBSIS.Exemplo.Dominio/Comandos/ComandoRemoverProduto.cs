using HBSIS.Exemplo.Dominio.Validacoes;
using System;

namespace HBSIS.Exemplo.Dominio.Comandos
{
    public class ComandoRemoverProduto : ProdutoComando
    {
        public ComandoRemoverProduto(Guid id)
        {
            Id = id;
        }

        public override bool Valido()
        {
            ValidationResult = new ValidacaoRemoverProduto().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
