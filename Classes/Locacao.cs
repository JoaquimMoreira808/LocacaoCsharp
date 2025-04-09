namespace Locadora.Classes
{
    public class Locacao 
    {
        public Filme FilmeAlugado { get; set; }

        public Cliente Cliente{ get; set; }

        public DateTime DataDevolucao { get; set; }

        public Locacao(Filme filme, Cliente cliente, DateTime datadevolucao)
        {
            this.FilmeAlugado = filme;
            this.Cliente = cliente;
            this.DataDevolucao = datadevolucao;
        }
    }
}
