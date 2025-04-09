namespace Locadora.Classes
{
    public class Cliente 
    {
        public string Nome { get; set; } = "";
        public List<Filme> FilmesAlugados { get; set; } = new List<Filme>();

        public Cliente(string nome, List<Filme> filmesAlugados)
        {
            this.Nome = nome;
            this.FilmesAlugados = filmesAlugados;
        }
    }
}
