using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondaProva_Lomasti
{
    class GestoreTask
    {
        private static int _ID=0;
        private static Dictionary<int, Task> _elenco = new Dictionary<int, Task>();

        public Task CreaTask(string nome, string data, Livello livello)
        {
            Task task = new Task(nome, data, livello, ++_ID);
            _elenco.Add(_ID, task);
           
            return task;
        }

        public string VisualizzaTask()
        {
            string s = "";

            foreach (Task t in _elenco.Values)
                s = s + t.descrizioneTask();

            if(s== "")
                return "Non ci sono task salvati";
            else
                return s;
        }
        public void Reset()
        {
                foreach(int i in _elenco.Keys)
                    _elenco.Remove(i);
        }
        public string Filtra(Livello livello)
        {
            string elenco_filtrato = "";
            foreach(Task t in _elenco.Values)
                if (t.Liv == livello)
                    elenco_filtrato += t.descrizioneTask();
            

            if (elenco_filtrato == "")
                return "Non ci sono task con questo livello di difficoltà";
            else
                return elenco_filtrato;
                
        }
    }
}
