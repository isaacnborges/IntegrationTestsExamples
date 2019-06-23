using HBSIS.Exemplo.Dominio.Comandos;
using HBSIS.Exemplo.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace HBSIS.Exemplo.Servicos.Interfaces
{
    public interface IProdutoServico
    {
        Produto Inserir(ComandoInserirProduto comando);

        Produto Atualizar(ComandoAtualizarProduto comando);

        void Remover(Guid id);

        Produto Obter(Guid id);

        IList<Produto> BuscarTodos();
    }
}
