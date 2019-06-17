using HBSIS.Exemplo.Dominio.Comandos;
using HBSIS.Exemplo.Dominio.Entidades;
using HBSIS.Exemplo.Servicos.Contratos;
using System;
using System.Collections.Generic;

namespace HBSIS.Exemplo.Servicos.Interfaces
{
    public interface IProdutoServico
    {
        ProdutoResponse Inserir(ComandoInserirProduto comando);

        ProdutoResponse Atualizar(ComandoAtualizarProduto comando);

        void Remover(Guid id);

        Produto Obter(Guid id);

        IList<Produto> BuscarTodos();
    }
}
