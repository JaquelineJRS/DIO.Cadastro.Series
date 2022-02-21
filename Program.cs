using System;
using DIO.Cadastro.Series;

namespace DIO.Cadastro.Series
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
      System.Console.WriteLine("Obrigado por utilizar nossos serviços!");
      Console.ReadLine();
    }

    private static void VisualizarSerie()
    {
      Console.Write("Digite o id da série qe deseja visualizar");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);

      System.Console.WriteLine(serie);
    }

    private static void ExcluirSerie()
    {
      Console.Write("Digite o id da série que deseja excluir: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceSerie);
    }

    private static void AtualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Lançamento da Série: ");
      int entradaAnoLancamento = int.Parse(Console.ReadLine());

      Console.Write("Digite uma breve descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      Series atualizaSeries = new Series(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    lancamento: entradaAnoLancamento,
                                    descricao: entradaDescricao);
      repositorio.Atualiza(indiceSerie, atualizaSeries);


    }

    private static void ListarSeries()
    {
      System.Console.WriteLine("Listar Séries:");

      var lista = repositorio.Lista();
      if (lista.Count == 0)
      {
        System.Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        System.Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído" : ""));
      }
    }

    private static void InserirSerie()
    {
      System.Console.WriteLine("Inserir nova série");
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Lançamento da Série: ");
      int entradaAnoLancamento = int.Parse(Console.ReadLine());

      Console.Write("Digite uma breve descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      Series novaSerie = new Series(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    lancamento: entradaAnoLancamento,
                                    descricao: entradaDescricao);
      repositorio.Insere(novaSerie);
    }

    private static string ObterOpcaoUsuario()
    {
      System.Console.WriteLine();
      System.Console.WriteLine("Olá, estamos ao seu dispor!");
      System.Console.Write("Informe a opção desejada: ");
      System.Console.WriteLine();

      System.Console.WriteLine("1 - Listar séries.");
      System.Console.WriteLine("2 - Inserir uma nova série.");
      System.Console.WriteLine("3 - Atualizar uma série");
      System.Console.WriteLine("4 - Excluir uma série");
      System.Console.WriteLine("5 - Visualizar uma série");
      System.Console.WriteLine("C - Limpar a tela");
      System.Console.WriteLine("X - Sair");
      System.Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      System.Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
