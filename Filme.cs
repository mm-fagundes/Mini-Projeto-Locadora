public class Filme : Titulo , ILocavel
{
    public string Diretor { get; set; }
    public int Duracao  { get; set; }

    public Filme(string nome, string descricao,int anolancamento, Genero genero, string diretor, int duracao)
        : base(nome, descricao, anolancamento, genero)
    {
        Diretor = diretor;
        Duracao = duracao;
    }

    
    
}