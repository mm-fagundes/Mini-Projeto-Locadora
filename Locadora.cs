using Microsoft.VisualBasic;

public class Locadora
{
    public List<Titulo> Titulos { get; set; } = [];

    public void AdicionarTitulo(Titulo nome)
    {
        Titulos.Add(nome);
    }


    public void ListarFilmes()
    {
        var filmes = Titulos.OfType<Filme>();
        if (!filmes.Any())
        {
            System.Console.WriteLine("Nenhum filme cadastrado.");
            return;
        }
        foreach (var t in filmes)
        {
            System.Console.WriteLine($"Filme:{t.Nome} | Descricao:{t.Descricao} | Ano De Lançamento:{t.AnoLancamento} | Genero:{t.Genero} | Disponibilidade:{(t.Disponivel ? "Disponível" : "Alugado")}");
        }
    }

    public void ListarSeries()
    {
        var series = Titulos.OfType<Serie>();
        if (!series.Any())
        {
            System.Console.WriteLine("Nenhuma serie cadastrado.");
            return;
        }
        foreach (var t in series)
        {
            System.Console.WriteLine($"Serie:{t.Nome} | Descricao:{t.Descricao} | Genero:{t.Genero} | Temporadas: {t.Temporadas} | Episodios: {t.Episodios} | Disponibilidade:{(t.Disponivel ? "Disponível" : "Alugado")}");
        }
    }


    public void ListarTitulos()
    {
        foreach (Titulo titulo in Titulos)
        {

            string tipo = titulo switch
            {
                Filme => "Filme",
                Serie => "Serie",
                _ => "Desconhecido"
            };
            ExibeDadosBasicos(titulo);
        }
    }

    public void BuscarTitulos(string Nome)
    {
        foreach (Titulo titulo in Titulos)
        {
            if (titulo.Nome.Trim().ToUpper() == Nome.Trim().ToUpper())
            {
                System.Console.WriteLine($"Titulo: {titulo.Nome} | Descricao: {titulo.Descricao} | Ano De Lançamento: {titulo.AnoLancamento} | Genero: {titulo.Genero} | Disponibilidade: {(titulo.Disponivel ? "Disponível" : "Alugado")}");
            }
        }
    }

    public void AlugarTitulo(string Nome)
    {
        bool encontrado = false;
        foreach (Titulo titulo in Titulos)
        {
            if (titulo.Nome.ToUpper() == Nome.Trim().ToUpper())
            {
                encontrado = true;
                titulo.Alugar();
            }

        }
        if (!encontrado)
        {
            System.Console.WriteLine("Titulo não encontrado.");
        }
    }

    public void DevolverTitulo(string Nome)
    {
        bool encontrado = false;
        foreach (Titulo titulo in Titulos)
        {
            if (titulo.Nome.ToUpper() == Nome.Trim().ToUpper())
            {
                encontrado = true;
                titulo.Devolver();
            }
        }
        if (!encontrado)
        {
            System.Console.WriteLine("Titulo não encontrado");
        }
    }
    public void ContagemTitulosAlugados()
    {
        int cont = Titulos.Count(t => !t.Disponivel);
        System.Console.WriteLine($"O total de titulos alugados é: {cont}");
    }

    public void ListarDisponiveis()
    {
        var disponiveis = Titulos.Where(t => t.Disponivel);

        if (!disponiveis.Any())
        {
            System.Console.WriteLine("Nenhum titulo disponível.");
            return;
        }
        foreach (Titulo titulo in disponiveis)
        {
            System.Console.WriteLine($"Titulo: {titulo.Nome} | Disponível");
        }
    }

    public void ListarAlugados()
    {
        var indisponiveis = Titulos.Where(t => !t.Disponivel);
        if (!indisponiveis.Any())
        {
            System.Console.WriteLine("Nenhum titulo está alugado.");
            return;
        }

        foreach (Titulo titulo in indisponiveis)
        {
            System.Console.WriteLine($"Titulo: {titulo.Nome} | Alugado");
        }
    }

    private void ListarPorGenero(Genero genero, String nomeGenero)
    {
        var titulos = Titulos.Where(t => t.Genero == genero);
        if (!titulos.Any())
        {
            System.Console.WriteLine($"Nenhum titulo de {nomeGenero} registrado.");
            return;
        }
        foreach (var t in titulos)
        {
            System.Console.WriteLine($"{t.Nome} | {t.Disponivel} | {nomeGenero}");
        }

    }

    public void BuscarPorGenero()
    {
        while (true)
        {
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("[1] Romance");
            System.Console.WriteLine("[2] Ação");
            System.Console.WriteLine("[3] Ficção Cientifica");
            System.Console.WriteLine("[4] Terror");
            System.Console.WriteLine("[5] Drama");
            System.Console.WriteLine("[6] Documentário");
            System.Console.WriteLine("[7] Sair");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Selecione o gênero: ");
            string? escolhaS = Console.ReadLine();
            if (string.IsNullOrEmpty(escolhaS))
            {
                System.Console.WriteLine("É necessário escolher.");
                continue;
            }
            if (!int.TryParse(escolhaS, out int escolha))
            {
                System.Console.WriteLine("Digite apenas números!");
                continue;
            }

            switch (escolha)
            {
                case 1:
                    ListarPorGenero(Genero.Romance, "Romance");
                    break;
                case 2:
                    ListarPorGenero(Genero.Acao, "Ação");
                    break;
                case 3:
                    ListarPorGenero(Genero.Scifi, "Ficção Ciêntifica");
                    break;
                case 4:
                    ListarPorGenero(Genero.Terror, "Terror");
                    break;
                case 5:
                    ListarPorGenero(Genero.Drama, "Drama");
                    break;
                case 6:
                    ListarPorGenero(Genero.Documentario, "Documentario");
                    break;
                case 7:
                    System.Console.WriteLine("Saindo..");
                    return;
                default:
                    System.Console.WriteLine("Opção inválida, tente novamente.");
                    continue;
            }
        }


    }

    public void BuscarPorAno()
    {
        while (true)
        {
            System.Console.Write("Digite o ano de lançamento: ");
            string? anoEscolhido = Console.ReadLine();
            if (ValidaVazio(anoEscolhido?.Trim()))
            {
                continue;
            }
            if (!int.TryParse(anoEscolhido, out int ano))
            {
                System.Console.WriteLine("Digite apenas números!");
                continue;
            }

            if (!Titulos.Any(t => t.AnoLancamento == ano))
            {
                System.Console.WriteLine($"Nenhum titulo lançado em {ano} encontrado.");
                continue;
            }

            var titulosPorAno = Titulos.Where(t => t.AnoLancamento == ano);
            foreach (var t in titulosPorAno)
            {
                ExibeDadosBasicos(t);
            }
            break;
        }
    }





    public void IniciarMenu()
    {
        while (true)
        {
            System.Console.WriteLine("--------------------");
            System.Console.WriteLine("[1] Listar Filmes");
            System.Console.WriteLine("[2] Listar Series");
            System.Console.WriteLine("[3] Alugar Titulo");
            System.Console.WriteLine("[4] Devolver Titulo");
            System.Console.WriteLine("[5] Buscar Titulo");
            System.Console.WriteLine("[6] Buscar por Genêro");
            System.Console.WriteLine("[7] Sair");
            System.Console.WriteLine("--------------------");
            System.Console.Write("Seleção: ");
            string? escolhaS = Console.ReadLine();
            if (string.IsNullOrEmpty(escolhaS))
            {
                System.Console.WriteLine("Digite algo!");
                continue;
            }

            if (!int.TryParse(escolhaS, out int escolha))
            {
                System.Console.WriteLine("Digite apenas números!");
                continue;
            }


            switch (escolha)
            {
                case 1:
                    ListarFilmes();
                    break;
                case 2:
                    ListarSeries();
                    break;
                case 3:
                    System.Console.WriteLine("Digite o nome do titulo: ");
                    string? tituloA = Console.ReadLine();
                    if (string.IsNullOrEmpty(tituloA))
                    {
                        System.Console.WriteLine("É necessário digitar algo!");
                        continue;
                    }
                    AlugarTitulo(tituloA);
                    break;
                case 4:
                    System.Console.WriteLine("Digite o nome do titulo que deseja devolver: ");
                    string? tituloD = Console.ReadLine();
                    if (string.IsNullOrEmpty(tituloD))
                    {
                        System.Console.WriteLine("É necessário digitar algo!");
                        continue;
                    }
                    DevolverTitulo(tituloD);
                    break;
                case 5:
                    System.Console.WriteLine("Digite o nome do titulo que deseja buscar: ");
                    string? tituloB = Console.ReadLine();
                    if (string.IsNullOrEmpty(tituloB))
                    {
                        System.Console.WriteLine("É necessário escrever algo!");
                        continue;
                    }
                    BuscarTitulos(tituloB);
                    break;
                case 6:
                    BuscarPorGenero();
                    break;
                default:
                    System.Console.WriteLine("Opção inválda, tente novamente.");
                    break;
            }
        }
    }

    private bool ValidaVazio(string? valida)
    {
        if (string.IsNullOrEmpty(valida))
        {
            System.Console.WriteLine("É necessário escrever algo!");
            return true;

        }
        else
        {
            return false;
        }
    }

    private void ExibeDadosBasicos(Titulo t)
    {
        string tipo = t switch{
            Filme => "Filme",
            Serie => "Série",
            _ => "Não Definido"
        };

        System.Console.WriteLine("-----------------------------");
        System.Console.WriteLine($"Tipo: {tipo}");
        System.Console.WriteLine($"Nome: {t.Nome}");
        System.Console.WriteLine($"Descrição: {t.Descricao}");
        System.Console.WriteLine($"Ano de Lançamento: {t.AnoLancamento}");
        System.Console.WriteLine($"Disponibilidade: {(t.Disponivel ? "Disponível" : "Alugado")}");
        System.Console.WriteLine("-----------------------------");
    }
}