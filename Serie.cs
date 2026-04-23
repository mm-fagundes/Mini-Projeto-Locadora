public class Serie : Titulo
{
    public int Episodios { get; set; }
    public int Temporadas {get; set; }

    public Serie(string nome, string descricao, int anolancamento, Genero genero, int episodios, int temporadas)
    : base (nome, descricao, anolancamento, genero)
    {
        Episodios = episodios;
        Temporadas = temporadas;
    }

}