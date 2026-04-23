# Locadora de Filmes

Este é um projeto de prática em **C#** e **Orientação a Objetos**, desenvolvido para simular um sistema básico de locadora de filmes e séries. O objetivo é aplicar conceitos como classes, interfaces, herança e polimorfismo em um contexto real.

## Funcionalidades

- **Gerenciamento de Títulos**: Classes para representar filmes (`Filme.cs`) e séries (`Serie.cs`), herdando de uma classe base `Titulo.cs`.
- **Gêneros**: Classe `Genero.cs` para categorizar os títulos.
- **Interface Locável**: `ILocavel.cs` define contratos para itens que podem ser alugados.
- **Locadora**: Classe `Locadora.cs` gerencia o catálogo e operações de locação.
- **Programa Principal**: `Program.cs` demonstra o uso do sistema.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET 10.0
- **IDE**: Visual Studio ou VS Code com extensão C#

## Como Executar

1. **Pré-requisitos**:
   - Instalar o [.NET SDK](https://dotnet.microsoft.com/download) (versão 10.0 ou superior).

2. **Clonar o Repositório**:
   ```
   git clone https://github.com/mm-fagundes/Mini-Projeto-Locadora.git
   cd Mini-Projeto-Locadora
   ```

3. **Restaurar Dependências**:
   ```
   dotnet restore
   ```

4. **Executar o Projeto**:
   ```
   dotnet run
   ```

O programa será executado no console, exibindo informações sobre o catálogo e operações de locação.

## Estrutura do Projeto

- `Filme.cs`: Classe para filmes.
- `Serie.cs`: Classe para séries.
- `Titulo.cs`: Classe base para títulos.
- `Genero.cs`: Classe para gêneros.
- `ILocavel.cs`: Interface para itens locáveis.
- `Locadora.cs`: Classe principal da locadora.
- `Program.cs`: Ponto de entrada da aplicação.
- `LocadoraFilmes.csproj`: Arquivo de projeto.
- `LocadoraFilmes.sln`: Arquivo de solução.

## Contribuição

Este é um projeto de aprendizado. Sinta-se à vontade para fazer fork, sugerir melhorias ou adicionar novas funcionalidades!

## Autor

- **Mateus Fagundes** - [mm-fagundes](https://github.com/mm-fagundes)

## Licença

Este projeto é para fins educacionais e não possui licença específica.
