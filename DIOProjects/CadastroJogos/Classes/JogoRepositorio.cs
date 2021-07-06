using System;
using System.Collections.Generic;
using System.Text;
using CadastroJogos.Interfaces;

namespace CadastroJogos.Classes
{
    public class JogoRepositorio : IRepositorio<Jogo>
    {
        private List<Jogo> listaJogo = new List<Jogo>(); 
        public void Atualiza(int id, Jogo objeto)
        {
            listaJogo[id] = objeto;
        }

        public void Anula(int id)
        {
            listaJogo[id].Anular();
        }

        public void Insere(Jogo objeto)
        {
            listaJogo.Add(objeto);
        }

        public List<Jogo> Lista()
        {
            return listaJogo;
        }

        public int ProximoId()
        {
            return listaJogo.Count;
        }

        public Jogo RetornaPorId(int id)
        {
            return listaJogo[id];
        }
    }
}
