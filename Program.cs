using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();

        static void Main(string[] args)
        {
            string opcaoMenu = ObterOpcaoMenu();
            while (opcaoMenu.ToUpper() != "X")
            {
                switch (opcaoMenu)
                {
                    case "1":
                        MenuSerie();
                        break;
                    case "2":
                        MenuFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoMenu = ObterOpcaoMenu();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadKey();
        }

        private static void MenuSerie()
        {
            string entidade = "Série";
            string opcaoUsuario = ObterOpcaoUsuario(entidade);
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
                opcaoUsuario = ObterOpcaoUsuario(entidade);
            }
            Console.Clear();
        }

        private static void MenuFilme()
        {
            string entidade = "Filme";
            string opcaoUsuario = ObterOpcaoUsuario(entidade);
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario(entidade);
            }
            Console.Clear();
        }

        private static void ListarSeries()//Listar Series
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Registro está excluído!!!" : "Registro está Ativo"));
            }
        }

        private static void ListarFilmes()//Listar Filmes
        {
            Console.WriteLine("Listar Filmes");

            var lista = repositorioFilme.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "Registro está excluído!!!" : "Registro está Ativo"));
            }
        }

        private static void InserirSerie()//Inserir Séries
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do início da série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void InserirFilme()//Inserir Filmes
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Gênero: ");
            int eGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do Filme: ");
            string eNome = Console.ReadLine();

            Console.WriteLine("Ator Principal: ");
            string eAtor = Console.ReadLine();

            Console.WriteLine("Atriz Principal: ");
            string eAtriz = Console.ReadLine();

            Console.WriteLine("Ano do Filme");
            int eAno = int.Parse(Console.ReadLine());

            Filme nFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: (Genero)eGenero,
                                        nome: eNome,
                                        atorPrincipal: eAtor,
                                        atrizPrincipal: eAtriz,
                                        ano: eAno);

            repositorioFilme.Insere(nFilme);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do início da série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                           ano: entradaAno,
                                     descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void AtualizarFilme()//Atualiza Filmes
        {
            Console.WriteLine("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Gênero: ");
            int eGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do Filme: ");
            string eNome = Console.ReadLine();

            Console.WriteLine("Ator Principal: ");
            string eAtor = Console.ReadLine();

            Console.WriteLine("Atriz Principal: ");
            string eAtriz = Console.ReadLine();

            Console.WriteLine("Ano do Filme");
            int eAno = int.Parse(Console.ReadLine());

            Filme nFilme = new Filme(id: indiceFilme,
                                 genero: (Genero)eGenero,
                                   nome: eNome,
                          atorPrincipal: eAtor,
                         atrizPrincipal: eAtriz,
                                    ano: eAno);
            repositorioFilme.Atualiza(indiceFilme, nFilme);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            string opcaoSN = ObterSN();

            while (opcaoSN.ToUpper() != "S" &&
                   opcaoSN.ToUpper() != "N")
            {
                Console.WriteLine("Escolha entre 'S' e 'N' por favor !");
                opcaoSN = ObterSN();
            }

            //Se chegou aqui o valor é 'S' ou 'N' devido o looping do while anterior.
            switch (opcaoSN)
            {
                case "S":
                    repositorio.Exclui(indiceSerie);
                    Console.WriteLine("Exclusão realizada com sucesso !");
                    break;
                default://Entra aqui apenas se o valor for 'N'
                    Console.WriteLine("Exclusão não foi realizada, o registro permace ativo !");
                    break;
            }
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            string opcaoSN = ObterSN();

            while (opcaoSN.ToUpper() != "S" &&
                   opcaoSN.ToUpper() != "N")
            {
                Console.WriteLine("Escolha entre 'S' e 'N' por favor !");
                opcaoSN = ObterSN();
            }

            //Se chegou aqui o valor é 'S' ou 'N' devido o looping do while anterior.
            switch (opcaoSN)
            {
                case "S":
                    repositorioFilme.Exclui(indiceFilme);
                    Console.WriteLine("Exclusão realizada com sucesso !");
                    break;
                default://Entra aqui apenas se o valor for 'N'
                    Console.WriteLine("Exclusão não foi realizada, o registro permace ativo !");
                    break;
            }
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void VisualizarFilme()
        {
            Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        private static string ObterOpcaoMenu()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("*** Menu Princial ***");
            Console.WriteLine("*********************");

            Console.WriteLine(" 1-Cadastro de Séries");
            Console.WriteLine(" 2-Cadastro de Filmes");
            Console.WriteLine(" C-Limpar Tela");
            Console.WriteLine(" X-Encerrar sistema");
            Console.WriteLine();

            string opcaoMenu = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine();
            return opcaoMenu;
        }

        private static string ObterOpcaoUsuario(string nomeObjeto)
        {

            Console.WriteLine("*** DIO => Cadastro de " + nomeObjeto + " ***");
            Console.WriteLine(" Escolha a opção:");
            Console.WriteLine();
            Console.WriteLine(" 1-Listar");
            Console.WriteLine(" 2-Inserir");
            Console.WriteLine(" 3-Atualizar");
            Console.WriteLine(" 4-Excluir");
            Console.WriteLine(" 5-Visualizar");
            Console.WriteLine(" C-Limpar Tela");
            Console.WriteLine(" X-Voltar para o Menu");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.Clear();
            return opcaoUsuario;
        }

        private static string ObterSN()
        {
            Console.WriteLine();
            Console.WriteLine("Confirma Exclusão S/N ?");

            string opcaoSN = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoSN;
        }
    }
}
