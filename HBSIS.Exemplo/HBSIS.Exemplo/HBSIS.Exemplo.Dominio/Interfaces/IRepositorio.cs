using HBSIS.Exemplo.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace HBSIS.Exemplo.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        void Inserir(T objeto);

        void Atualizar(T objeto);

        void Remover(Guid id);

        T Obter(Guid id);

        IList<T> BuscarTodos();
    }
}
