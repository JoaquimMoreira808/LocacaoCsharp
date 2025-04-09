using Locadora.Classes;
namespace Locadora.Services 
{
    public static class ClienteServices
    {
        public static List<Cliente> ClientesCadastrados = new List<Cliente>();
        

        public static void ClienteSeed()
        {
            ClienteServices.CadastrarCliente("Marcelo");
            ClienteServices.CadastrarCliente("Claudinei a lenda");
            ClienteServices.CadastrarCliente("Babinsky");
            ClienteServices.CadastrarCliente("Naldo");
            ClienteServices.CadastrarCliente("Bananilson Farofa");
            ClienteServices.CadastrarCliente("Dante Allegiere");
        }
        public static void CadastrarCliente(string nome)
        {
            Cliente novoCliente = new Cliente(nome, new List<Filme>());
            ClientesCadastrados.Add(novoCliente);
            Console.WriteLine($"Cliente {nome} cadastrado com sucesso!");
        }

        public static void ListarClientes()
        {
            if (ClientesCadastrados.Count == 0)
            {
                throw new Exception("Não há clientes cadastrados");
            }

            var ClienteAlfabeticos = ClientesCadastrados.OrderBy(c => c.Nome).ToList();


            foreach (var cliente in ClienteAlfabeticos)
            {
                Console.WriteLine($"Nome: {cliente.Nome}");
            }
        }

        public static void ListarFilmesAlugados(Cliente cliente)
        {
            if (cliente.FilmesAlugados.Count == 0)
            {
                Console.WriteLine($"{cliente.Nome} não possui filmes alugados no momento.");
            }
            else
            {
                Console.WriteLine($"Filmes alugados por {cliente.Nome}:");
                foreach (var filme in cliente.FilmesAlugados)
                {
                    Console.WriteLine($"- {filme.Titulo}");
                }
            }
        }
    }
}