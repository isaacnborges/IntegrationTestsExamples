using HBSIS.Exemplo.Dominio.Comandos;

namespace HBSIS.Exemplo.Dominio.Validacoes
{
    public class ValidacaoRemoverProduto : ProdutoValidacao<ComandoRemoverProduto>
    {
        public ValidacaoRemoverProduto()
        {
            ValidarId();
        }
    }
}
