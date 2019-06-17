using HBSIS.Exemplo.Dominio.Entidades;
using HBSIS.Exemplo.Dominio.Interfaces;
using HBSIS.Exemplo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HBSIS.Exemplo.Infra.Repositorios
{
    public class RepositorioBase<T> : IRepositorio<T> where T : EntidadeBase
    {
        private readonly ExemploDbContexto _contexto;

        public RepositorioBase(ExemploDbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Inserir(T objeto)
        {
            _contexto.Set<T>().Add(objeto);
            _contexto.SaveChanges();
        }

        public void Atualizar(T objeto)
        {
            _contexto.Set<T>().Update(objeto);
            _contexto.SaveChanges();
        }

        public void Remover(Guid id)
        {
            _contexto.Set<T>().Remove(Obter(id));
            _contexto.SaveChanges();
        }

        public T Obter(Guid id)
        {
            return _contexto.Set<T>().Find(id);
        }

        public IList<T> BuscarTodos()
        {
            return _contexto.Set<T>().ToList();
        }
    }
}
