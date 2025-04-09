using Locadora.Classes;
namespace Locadora.Services
{
    public static class FilmeServices
    {
        public static List<Filme> FilmesCadastrados = new List<Filme>();

        public static void FilmeSeed()
        {
            FilmeServices.CadastrarFilme("O Poderoso Chefão", "Drama", 0);
            FilmeServices.CadastrarFilme("Velozes e Furiosos", "Ação", 1);
            FilmeServices.CadastrarFilme("Interestelar", "Ficção Científica", 8);
            FilmeServices.CadastrarFilme("Invocação do Mal", "Terror", 0);
            FilmeServices.CadastrarFilme("Toy Story", "Animação", 12);
        }

        public static void CadastrarFilme(string Titulo, string genero, int quantidade)
        {
            Filme novoFilme = new Filme(Titulo, genero, quantidade);
            FilmesCadastrados.Add(novoFilme);
            Console.WriteLine($"Filme '{Titulo}' cadastrado com sucesso!");
        }

        public static void ListarTodosFilmes()
        {
            if (FilmesCadastrados.Count == 0)
            {
                throw new Exception("Não há filmes cadastrados");
            }

            Console.WriteLine(@"Os filmes cadastrados são:
            ==========================");
            foreach (var filme in FilmesCadastrados)
            {
                Console.WriteLine($"Titulo: {filme.Titulo}, Gênero: {filme.Genero}, Quantidade: {filme.Quantidade}");
            }
        }

        public static void ListarTodosDisponiveis()
        {
            Console.WriteLine("Os filmes Disponiveis são:");
            foreach (var filme in FilmesCadastrados)
            {
                if (filme.Quantidade >= 1)
                {
                    Console.WriteLine($"Titulo: {filme.Titulo}");
                }
            }
        }

        public static void ListarTodosIndisponiveis()
        {
            Console.WriteLine("Os filmes indisponiveis são:");
            bool encontrouIndisponivel = false;

            foreach (var filme in FilmesCadastrados)
            {
                if (filme.Quantidade == 0)
                {
                    Console.Write($"{filme.Titulo}\n");
                    encontrouIndisponivel = true;
                }
            }

            if (!encontrouIndisponivel)
            {
                throw new Exception("Todos os filmes estão disponíveis. Nenhum filme indisponível foi encontrado.");
            }
        }
    }

} 