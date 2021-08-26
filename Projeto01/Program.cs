using System;

namespace Projeto01
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
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
                        VisualizarSerie();
                        break;
                    case "5":
                        ExcluirSerie();
                        break;
                    case "6":
                        ProcurarSerie();
                        break;
                    case "7":
                        ExibirCondicao();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();   
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Visualizar serie");
            Console.WriteLine("5- Excluir serie");
            Console.WriteLine("6- Procurar series por genero");
            Console.WriteLine("7- Condição da serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine();

            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Seria cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                if (!serie.Excluido)
                    Console.WriteLine("ID: {0} - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Serie");

            MostraGeneros();

            Console.Write("Digite o número do gênero das opcoes acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Serie");
            Console.WriteLine();
            
            Console.Write("Informe o id da série que deseja atualizar:");
            int idSerie = int.Parse(Console.ReadLine());

            MostraGeneros();

            Console.Write("Digite o número do gênero das opcoes acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie");
            string entradaDescricao = Console.ReadLine();

            Serie serieAtualizada = new Serie(id: idSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
            
            repositorio.Atualiza(idSerie, serieAtualizada);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar serie");
            Console.WriteLine();

            Console.WriteLine("1- Visualizar uma serie");
            Console.WriteLine("2- Visualizar todas as series");
            Console.WriteLine("X- Sair do Visualizar Serie");

            string opcaoUsuario = Console.ReadLine();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o id da serie");
                        int idSerie = int.Parse(Console.ReadLine());

                        var serieUnica = repositorio.RetornaPorId(idSerie);

                        Console.WriteLine(serieUnica);
                        Console.WriteLine();
                        break;
                    case "2":
                        var series = repositorio.Lista();

                        foreach (var s in series)
                            Console.WriteLine(s);
                            Console.WriteLine();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                } 
                opcaoUsuario = Console.ReadLine(); 
            }
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir Serie");
            Console.WriteLine();

            Console.WriteLine("Informe o id da serie:");
            int serieId = int.Parse(Console.ReadLine());
            repositorio.Exclui(serieId);
        }

        private static void ExibirCondicao()
        {
            Console.WriteLine("Condição da serie");
            Console.WriteLine();

            Console.WriteLine("Informe o id da serie");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(idSerie);
            Console.WriteLine();

            Console.WriteLine("{0} - {1}", serie.retornaTitulo(), (serie.Excluido ? "Excluido" : "Disponivel"));
        }

        private static void ProcurarSerie()
        {
            Console.WriteLine("Procurar Series por Genero");
            Console.WriteLine();

            MostraGeneros();

            Console.WriteLine("Escolha o numero do genero que deseja filtrar");
            int generoUsuario = int.Parse(Console.ReadLine());
            var series = repositorio.RetornaPorGenero(generoUsuario);

            foreach (var serie in series)
            {
                Console.WriteLine(serie);
                Console.WriteLine();
            }
        }

        private static void MostraGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
        }
    }
}
