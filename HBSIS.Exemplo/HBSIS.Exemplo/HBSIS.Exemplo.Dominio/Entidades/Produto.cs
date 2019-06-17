namespace HBSIS.Exemplo.Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        private Produto()
        {

        }

        public Produto(int codigo, string descricao, double preco)
        {
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
        }

        public Produto InformarCodigo(int codigo)
        {
            Codigo = codigo;
            return this;
        }

        public Produto InformarDescricao(string descricao)
        {
            Descricao = descricao;
            return this;
        }

        public Produto InformarPreco(double preco)
        {
            Preco = preco;
            return this;
        }
    }
}
