using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CadastroJogos.Classes;
using CadastroJogos.Enums;

namespace CadastroJogos
{
    public class CadastroDeJogos
    {
        static JogoRepositorio repositorio = new JogoRepositorio();

        public void Execute()
        {
            AppJogo();
        }

        private void AppJogo()
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarJogos();
                        break;
                    case "2":
                        InserirJogo();
                        break;
                    case "3":
                        AtualizarJogo();
                        break;
                    case "4":
                        AnularJogo();
                        break;
                    case "5":
                        DetalhesJogo();
                        break;
                    case "6":
                        PesquisarJogo();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("\nPrograma encerrado");
        }

        private void PesquisarJogo()
        {
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Não existem jogos cadastrados.");
                return;
            }
            string opcaoUsuario = ObterPesquisaUsuario();
            while (opcaoUsuario != "4")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Pesquisa Jogos por Data");
                        Console.WriteLine("Informe a data: ");
                        var dataPartida = DateTime.Parse(Console.ReadLine());

                        var pesquisaData = repositorio.Lista().Where(x => x.Anulado != true && x.DataJogo == dataPartida).ToList();
                        foreach (var jogo in pesquisaData)
                        {
                            Console.WriteLine("#ID: {0} -> Partida: {1}", jogo.retornaId(), jogo.retornaPartida());
                        }
                        break;
                    case "2":
                        Console.WriteLine("Pesquisa Jogos por Campeonato");
                        Console.WriteLine("Informe o campeonato: ");
                        
                        foreach (int i in Enum.GetValues(typeof(Campeonato)))
                        {
                            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Campeonato), i));
                        }
                        var tipoCampeonato = int.Parse(Console.ReadLine());

                        var pesquisaCampeonato = repositorio.Lista().Where(x => x.Anulado != true && x.Campeonato == (Campeonato)tipoCampeonato).ToList();
                        foreach (var jogo in pesquisaCampeonato)
                        {
                            Console.WriteLine("#ID: {0} -> Partida: {1}", jogo.retornaId(), jogo.retornaPartida());
                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Pesquisa Jogos por Time");
                        Console.WriteLine("Informe o Time: ");
                        var time = Console.ReadLine();

                        var pesquisaTime = repositorio.Lista().Where(x => x.Anulado != true && x.TimeCasa.ToUpper() == time.ToUpper() || 
                        x.TimeAdversario.ToUpper() == time.ToUpper()).ToList();
                        foreach (var jogo in pesquisaTime)
                        {
                            Console.WriteLine("#ID: {0} -> Partida: {1}", jogo.retornaId(), jogo.retornaPartida());
                        }
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida.");
                        break;
                }
                opcaoUsuario = ObterPesquisaUsuario();
            }
        }

        private void DetalhesJogo()
        {
            Console.WriteLine("Detalhes da partida");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Não existem jogos cadastrados.");
                return;
            }
            Console.WriteLine("Informe o id do jogo: ");
            var indiceJogo = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornaPorId(indiceJogo);
            Console.WriteLine(jogo);
        }

        private void AnularJogo()
        {
            Console.WriteLine("Anular jogo");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Não existem jogos cadastrados.");
                return;
            }
            Console.WriteLine("Informe o id do jogo: ");
            var indiceJogo = int.Parse(Console.ReadLine());

            repositorio.Anula(indiceJogo);

        }

        private void AtualizarJogo()
        {
            Console.WriteLine("Atualizar jogo");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Não existem jogos cadastrados.");
                return;
            }
            Console.WriteLine("Informe o id do jogo: ");
            var indiceJogo = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Campeonato)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Campeonato), i));
            }
            Console.WriteLine("Informe o campeonato entre as opções acima: ");
            var entradaCampeonato = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o time da casa: ");
            var entradaTimeCasa = Console.ReadLine();
            Console.WriteLine("Informe o time adversário: ");
            var entradaTimeAdv = Console.ReadLine();
            Console.WriteLine("Informe o estádio onde ocorrerá a partida: ");
            var entradaEstadio = Console.ReadLine();
            Console.WriteLine("Informe o dia da partida: ");
            var entradaDataJogo = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Informe o horario da partida: ");
            var entradaHorario = DateTime.Parse(Console.ReadLine());

            Jogo jogo = new Jogo(id: repositorio.ProximoId(),
                campeonato: (Campeonato)entradaCampeonato,
                timeCasa: entradaTimeCasa,
                timeAdversario: entradaTimeAdv,
                estadio: entradaEstadio,
                dataJogo: entradaDataJogo,
                horario: entradaHorario);

            repositorio.Atualiza(indiceJogo, jogo);
        }

        private void InserirJogo()
        {
            Console.WriteLine("Inserir novo jogo");
            foreach (int i in Enum.GetValues(typeof(Campeonato)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Campeonato), i));
            }
            Console.WriteLine("Informe o campeonato entre as opções acima: ");
            var entradaCampeonato = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o time da casa: ");
            var entradaTimeCasa = Console.ReadLine();
            Console.WriteLine("Informe o time adversário: ");
            var entradaTimeAdv = Console.ReadLine();
            Console.WriteLine("Informe o estádio onde ocorrerá a partida: ");
            var entradaEstadio = Console.ReadLine();
            Console.WriteLine("Informe o dia da partida: ");
            var entradaDataJogo = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Informe o horario da partida: ");
            var entradaHorario = DateTime.Parse(Console.ReadLine());

            Jogo jogo = new Jogo(id: repositorio.ProximoId(),
                campeonato: (Campeonato)entradaCampeonato,
                timeCasa: entradaTimeCasa,
                timeAdversario: entradaTimeAdv,
                estadio: entradaEstadio,
                dataJogo: entradaDataJogo,
                horario: entradaHorario);
            repositorio.Insere(jogo);
        }

        private void ListarJogos()
        {
            Console.WriteLine("Listar Jogos");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Não existem jogos cadastrados.");
                return;
            }
            foreach (var jogo in lista)
            {
                var anulado = jogo.retornaAnulado();
                Console.WriteLine("#ID: {0} -> Partida: {1} {2}", jogo.retornaId(), jogo.retornaPartida(), anulado ?
                    "**Jogo Anulado**" : "");
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Cadastro de Jogos \n ======================");
            Console.WriteLine("Informe a opçao desejada: ");
            Console.WriteLine("1 - Listar jogos");
            Console.WriteLine("2 - Inserir novo jogo");
            Console.WriteLine("3 - Atualizar jogo");
            Console.WriteLine("4 - Excluir jogo");
            Console.WriteLine("5 - Detalhes da partida");
            Console.WriteLine("6 - Pesquisar jogo");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string ObterPesquisaUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Pesquisar jogo \n ======================");
            Console.WriteLine("Informe a opçao desejada: ");
            Console.WriteLine("1 - Pesquisar por Data");
            Console.WriteLine("2 - Pesquisar por Campeonato");
            Console.WriteLine("3 - Pesquisar por time");
            Console.WriteLine("4 - Voltar");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
