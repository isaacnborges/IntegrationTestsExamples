using HBSIS.Exemplo.Dominio.Entidades;
using HBSIS.Exemplo.Dominio.Interfaces;
using HBSIS.Exemplo.Infra.Contexto;

namespace HBSIS.Exemplo.Infra.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(ExemploDbContexto contexto) : base(contexto)
        {
        }
    }
}
