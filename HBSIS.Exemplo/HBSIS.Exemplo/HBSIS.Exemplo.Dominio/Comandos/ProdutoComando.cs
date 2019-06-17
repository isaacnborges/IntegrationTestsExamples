using System;

namespace HBSIS.Exemplo.Dominio.Comandos
{
    public abstract class ProdutoComando : Comando
    {
        public Guid Id { get; set; }

        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public double Preco { get; set; }
    }
}
