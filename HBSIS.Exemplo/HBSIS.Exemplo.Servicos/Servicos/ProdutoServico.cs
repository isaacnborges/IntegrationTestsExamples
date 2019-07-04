using HBSIS.Exemplo.Dominio.Comandos;
using HBSIS.Exemplo.Dominio.Entidades;
using HBSIS.Exemplo.Dominio.Interfaces;
using HBSIS.Exemplo.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HBSIS.Exemplo.Servicos.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public Produto Inserir(ComandoInserirProduto comando)
        {
            if (comando.Valido())
            {
                var novoProduto = new Produto(comando.Codigo, comando.Descricao, comando.Preco);
                _produtoRepositorio.Inserir(novoProduto);

                return _produtoRepositorio.Obter(novoProduto.Id);
            }

            return new Produto();
        }

        public Produto Atualizar(ComandoAtualizarProduto comando)
        {
            if (comando.Valido())
            {
                var produto = _produtoRepositorio.Obter(comando.Id);

                produto
                    .InformarCodigo(comando.Codigo)
                    .InformarDescricao(comando.Descricao)
                    .InformarPreco(comando.Preco);

                _produtoRepositorio.Atualizar(produto);

                return _produtoRepositorio.Obter(produto.Id);
            }

            return new Produto();
        }

        public void Remover(Guid id)
        {
            _produtoRepositorio.Remover(id);
        }

        public Produto Obter(Guid id)
        {
            return _produtoRepositorio.Obter(id);
        }

        public IList<Produto> BuscarTodos()
        {
            return _produtoRepositorio.BuscarTodos()
                .OrderBy(x => x.Descricao)
                .ToList();
        }
    }
}
