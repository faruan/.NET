using System;
using CadastroJogos;
using CadastroSeries;

namespace DIOProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            CadastroSerie cadastroSerie = new CadastroSerie();
            CadastroDeJogos cadastroJogos = new CadastroDeJogos();

            //cadastroSerie.Execute();
            cadastroJogos.Execute();
        }
    }
}
