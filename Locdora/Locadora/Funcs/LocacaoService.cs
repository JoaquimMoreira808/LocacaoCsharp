using Locadora.Classes;
namespace Locadora.Services
{
    public static class LocacaoService
    {
        public static List<Locacao> LocacoesAtivas = new List<Locacao>();

        public static void LocarFilme(Filme filmeEscolhido, Cliente cliente, DateTime dataDeDevolucao)
        {


            if (cliente.FilmesAlugados.Count >= 2)
            {
                throw new Exception($"O cliente {cliente.Nome} já possui 2 filmes alugados. Devolva um antes de alugar outro.");
            }

            if (filmeEscolhido.Quantidade <= 0)
            {
                throw new Exception("Esse filme não está disponível para locação.");
            }


            Locacao novaLocacao = new Locacao(filmeEscolhido, cliente, dataDeDevolucao);

            cliente.FilmesAlugados.Add(filmeEscolhido);
            filmeEscolhido.Quantidade--;
            LocacoesAtivas.Add(novaLocacao);

            Console.WriteLine($"Filme '{filmeEscolhido.Titulo}' locado com sucesso para {cliente.Nome} até {dataDeDevolucao.ToShortDateString()}.");
        }

        public static void DevolverFilme(Locacao locacao, Cliente cliente)
        {
            if (!cliente.FilmesAlugados.Contains(locacao.FilmeAlugado))
            {
                throw new Exception("Essa locação não existe!");
            }

            cliente.FilmesAlugados.Remove(locacao.FilmeAlugado);
            locacao.FilmeAlugado.Quantidade++;

            Console.WriteLine($"Filme '{locacao.FilmeAlugado.Titulo}' devolvido com sucesso pelo cliente {cliente.Nome}.");
        }
    }
}