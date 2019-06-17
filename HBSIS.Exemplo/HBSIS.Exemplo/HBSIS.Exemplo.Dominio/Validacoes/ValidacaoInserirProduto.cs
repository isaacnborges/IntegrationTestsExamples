using HBSIS.Exemplo.Dominio.Comandos;

namespace HBSIS.Exemplo.Dominio.Validacoes
{
    public class ValidacaoInserirProduto : ProdutoValidacao<ComandoInserirProduto>
    {
        public ValidacaoInserirProduto()
        {
            ValidarCodigo();
            ValidarDescricao();
            ValidarPreco();
        }
    }
}
