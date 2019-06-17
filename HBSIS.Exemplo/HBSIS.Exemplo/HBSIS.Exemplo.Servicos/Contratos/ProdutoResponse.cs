using System;

namespace HBSIS.Exemplo.Servicos.Contratos
{
    public class ProdutoResponse
    {
        public Guid Id { get; set; }

        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public double Preco { get; set; }
    }
}
