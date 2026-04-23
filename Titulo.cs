using System.Diagnostics.Contracts;

public class Titulo
{
    public string Nome { get; set; }
    public bool Disponivel { get; set; } = true;
    public string Descricao { get; set; }
    public int AnoLancamento { get; set; }

    public Genero Genero { get; set; }
    public Titulo(string nome, string descricao, int anolancamento, Genero genero)
    {
        Nome = nome;
        Descricao = descricao;
        AnoLancamento = anolancamento;
        Genero = genero;
    }

    public void Alugar()
    {
        if (Disponivel)
        {
            string tipo = this switch
            {
                Filme => "Filme",
                Serie => "Serie",
                _ => "Desconhecido"
            };

            Disponivel = false;
            Console.WriteLine($"{tipo} alugado com sucesso!");
        }
        else
        {
            System.Console.WriteLine("O titulo ja está alugado.");
        }
        
    }

    public void Devolver()
    {
        if(!Disponivel)
        {
            Disponivel = true;
            Console.WriteLine("Titulo devolvido com sucesso!");
        }
        else
        {
            System.Console.WriteLine("O titulo não está emprestado.");
        }
    }
}