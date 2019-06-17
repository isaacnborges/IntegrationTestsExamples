using HBSIS.Exemplo.Dominio.Comandos;

namespace HBSIS.Exemplo.Dominio.Validacoes
{
    public class ValidacaoAtualizarProduto : ProdutoValidacao<ComandoAtualizarProduto>
    {
        public ValidacaoAtualizarProduto()
        {
            ValidarId();
            ValidarCodigo();
            ValidarDescricao();
            ValidarPreco();
        }
    }
}
