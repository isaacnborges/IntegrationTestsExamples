using HBSIS.Exemplo.Dominio.Validacoes;
using System;

namespace HBSIS.Exemplo.Dominio.Comandos
{
    public class ComandoAtualizarProduto : ProdutoComando
    {
        public ComandoAtualizarProduto(Guid id, int codigo, string descricao, double preco)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
        }

        public override bool Valido()
        {
            ValidationResult = new ValidacaoAtualizarProduto().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
