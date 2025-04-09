namespace Locadora.Classes
{
    public class Filme
    {
        public string Titulo { get; set; }

        public string Genero { get; set; }

        public int Quantidade { get; set; }

        public Filme(string nome, string genero, int quantidade)
        {
            this.Titulo = nome;
            this.Genero = genero;
            this.Quantidade = quantidade;
        }


    }
}
