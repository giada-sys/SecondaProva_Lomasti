using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondaProva_Lomasti
{
    class Task
    {
        public string Nome { get; }
        public string Data { get; }
        public Livello Liv { get; }
        public int ID { get; }

        public Task(string nome, string data, Livello livello, int id)
        {
            Nome= nome;
            Data = data;
            Liv = livello;
            ID = id;
        }
        public string descrizioneTask()
        {
            return $"Task numero: "+ID+ "\nNome Task: "+Nome+"\nData di Scadenza: "+Data+ "\nLivello di importanza: "+Liv +"\n";
        }
    }
}
