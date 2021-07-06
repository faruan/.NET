using System;
using System.Collections.Generic;
using System.Text;
using CadastroJogos.Enums;

namespace CadastroJogos.Classes
{
    public class Jogo : EntidadeBase
    {
        public Campeonato Campeonato { get; set; }
        public string TimeCasa { get; set; }
        public string TimeAdversario { get; set; }
        public string Estadio { get; set; }
        public DateTime DataJogo { get; set; }
        public DateTime Horario { get; set; }
        public bool Anulado { get; set; }

        public Jogo(int id, Campeonato campeonato, string timeCasa, string timeAdversario, string estadio, DateTime dataJogo,
            DateTime horario)
        {
            Id = id;
            Campeonato = campeonato;
            TimeCasa = timeCasa;
            TimeAdversario = timeAdversario;
            Estadio = estadio;
            DataJogo = dataJogo;
            Horario = horario;
            Anulado = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Campeonato: " + Campeonato + Environment.NewLine;
            retorno += "Time da Casa: " + TimeCasa + Environment.NewLine;
            retorno += "Time Adversário: " + TimeAdversario + Environment.NewLine;
            retorno += "Estádio: " + Estadio + Environment.NewLine;
            retorno += "Data de Jogo: " + DataJogo.ToString("dd/MM/yyyy") + Environment.NewLine;
            retorno += "Horário: " + Horario.ToString("HH:mm") + Environment.NewLine; ;
            retorno += "Anulado: " + Anulado;
            return retorno;
        }

        public string retornaPartida()
        {
            return $"{TimeCasa} x {TimeAdversario}"; 
        }
        public int retornaId()
        {
            return Id;
        }
        public bool retornaAnulado()
        {
            return Anulado;
        }
        public void Anular()
        {
            Anulado = true;
        }
    }
}
