using HBSIS.Exemplo.Dominio.Comandos;
using System;

namespace HBSIS.Exemplo.Testes.Fakes
{
    public class ProdutoFake
    {
        public ComandoInserirProduto InserirProduto()
        {
            return new ComandoInserirProduto(1, "tesas", 9.45);
        }

        public ComandoAtualizarProduto AtualizarProduto()
        {
            return new ComandoAtualizarProduto(Guid.NewGuid(), 1, "tesas", 9.45);
        }

        public ComandoRemoverProduto RemoverProduto()
        {
            return new ComandoRemoverProduto(Guid.NewGuid());
        }
    }
}
