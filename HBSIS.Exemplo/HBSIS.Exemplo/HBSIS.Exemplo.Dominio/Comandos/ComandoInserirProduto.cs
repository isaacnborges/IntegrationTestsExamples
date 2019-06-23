using HBSIS.Exemplo.Dominio.Validacoes;

namespace HBSIS.Exemplo.Dominio.Comandos
{
    public class ComandoInserirProduto : ProdutoComando
    {
        public ComandoInserirProduto()
        {
        }

        public ComandoInserirProduto(int codigo, string descricao, double preco)
        {
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
        }

        public override bool Valido()
        {
            ValidationResult = new ValidacaoInserirProduto().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
