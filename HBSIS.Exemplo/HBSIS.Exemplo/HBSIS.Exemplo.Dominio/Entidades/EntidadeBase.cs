using System;

namespace HBSIS.Exemplo.Dominio.Entidades
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
