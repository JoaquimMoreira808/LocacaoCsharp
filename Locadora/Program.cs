using System;
using Locadora.Classes;
using Locadora.Services;

//  _    _____    ____   __________  ____  _____   __________  _________   _____    
// | |  / /   |  /  _/  / ____/ __ \/ __ \/  _/ | / /_  __/ / / /  _/   | / ___/    
// | | / / /| |  / /   / /   / / / / /_/ // //  |/ / / / / /_/ // // /| | \__ \     
// | |/ / ___ |_/ /   / /___/ /_/ / _, _// // /|  / / / / __  // // ___ |___/ /     
// |___/_/  |_/___/   \____/\____/_/ |_/___/_/ |_/ /_/ /_/ /_/___/_/  |_/____/      
                                                                                 
class Program
{
    static void Main(string[] args)
    {
        ClienteServices.ClienteSeed();
        FilmeServices.FilmeSeed(); 

        bool sair = false;
        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("=== Locadora dos guri's ===");
            Console.WriteLine("1. Cadastrar Cliente");
            Console.WriteLine("2. Listar Clientes");
            Console.WriteLine("3. Cadastrar Filme");
            Console.WriteLine("4. Listar Todos os Filmes");
            Console.WriteLine("5. Listar Filmes Disponíveis");
            Console.WriteLine("6. Listar Filmes Indisponíveis");
            Console.WriteLine("7. Alugar Filme");
            Console.WriteLine("8. Devolver Filme");
            Console.WriteLine("9. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome do cliente: ");
                    string nomeCliente = Console.ReadLine();
                    ClienteServices.CadastrarCliente(nomeCliente);
                    break;

                case "2":
                    ClienteServices.ListarClientes();
                    break;

                case "3":
                    Console.Write("Digite o título do filme: ");
                    string tituloFilme = Console.ReadLine();
                    Console.Write("Digite o gênero do filme: ");
                    string generoFilme = Console.ReadLine();
                    Console.Write("Digite a quantidade disponível: ");
                    if (int.TryParse(Console.ReadLine(), out int quantidadeFilme))
                    {
                        FilmeServices.CadastrarFilme(tituloFilme, generoFilme, quantidadeFilme);
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida.");
                    }
                    break;

                case "4":
                    FilmeServices.ListarTodosFilmes();
                    break;

                case "5":
                    FilmeServices.ListarTodosDisponiveis();
                    break;

                case "6":
                    FilmeServices.ListarTodosIndisponiveis();
                    break;

                case "7":

                    ClienteServices.ListarClientes();

                    Console.Write("Digite o nome do cliente: ");
                    string nomeClienteAlugar = Console.ReadLine();

                    Cliente clienteAlugar = null;
                    for (int i = 0; i < ClienteServices.ClientesCadastrados.Count; i++)
                    {
                        if (ClienteServices.ClientesCadastrados[i].Nome == nomeClienteAlugar)
                        {
                            clienteAlugar = ClienteServices.ClientesCadastrados[i];
                            break;
                        }
                    }

                    if (clienteAlugar != null)
                    {
                        FilmeServices.ListarTodosDisponiveis();
                        Console.Write("Digite o título do filme: ");
                        string tituloFilmeAlugar = Console.ReadLine();

                        Filme filmeAlugar = null;
                        for (int i = 0; i < FilmeServices.FilmesCadastrados.Count; i++)
                        {
                            if (FilmeServices.FilmesCadastrados[i].Titulo == tituloFilmeAlugar)
                            {
                                filmeAlugar = FilmeServices.FilmesCadastrados[i];
                                break;
                            }
                        }

                        if (filmeAlugar != null)
                        {
                            Console.Write("Digite a data de devolução (dd/MM/yyyy): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime dataDevolucao))
                            {
                                LocacaoService.LocarFilme(filmeAlugar, clienteAlugar, dataDevolucao);
                            }
                            else
                            {
                                Console.WriteLine("Data inválida.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Filme não encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cliente não encontrado.");
                    }
                    break;

                case "8":
                    Console.Write("Digite o nome do cliente: ");
                    string nomeClienteDevolver = Console.ReadLine();

                    Cliente clienteDevolver = null;
                    for (int i = 0; i < ClienteServices.ClientesCadastrados.Count; i++)
                    {
                        if (ClienteServices.ClientesCadastrados[i].Nome == nomeClienteDevolver)
                        {
                            clienteDevolver = ClienteServices.ClientesCadastrados[i];
                            break;
                        }
                    }

                    ClienteServices.ListarFilmesAlugados(clienteDevolver);

                    if (clienteDevolver != null)
                    {
                        Console.Write("Digite o título do filme: ");
                        string tituloFilmeDevolver = Console.ReadLine();

                        Filme filmeDevolver = null;
                        for (int i = 0; i < clienteDevolver.FilmesAlugados.Count; i++)
                        {
                            if (clienteDevolver.FilmesAlugados[i].Titulo == tituloFilmeDevolver)
                            {
                                filmeDevolver = clienteDevolver.FilmesAlugados[i];
                                break;
                            }
                        }

                        if (filmeDevolver != null)
                        {
                            Locacao locacaoDevolver = null;
                            for (int i = 0; i < LocacaoService.LocacoesAtivas.Count; i++)
                            {
                                if (LocacaoService.LocacoesAtivas[i].FilmeAlugado == filmeDevolver &&
                                    LocacaoService.LocacoesAtivas[i].Cliente == clienteDevolver)
                                {
                                    locacaoDevolver = LocacaoService.LocacoesAtivas[i];
                                    break;
                                }
                            }

                            if (locacaoDevolver != null)
                            {
                                LocacaoService.DevolverFilme(locacaoDevolver, clienteDevolver);
                            }
                            else
                            {
                                Console.WriteLine("Locação não encontrada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Filme não encontrado na lista de alugados do cliente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cliente não encontrado.");
                    }
                    break;

                case "9":
                    sair = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            if (!sair)
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
