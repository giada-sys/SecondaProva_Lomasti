using System;
using System.Collections.Generic;
using System.IO;

namespace SecondaProva_Lomasti
{
    enum Livello
    {
        Basso,
        Medio, 
        Alto
    }
    class Program
    {
        private static GestoreTask gestore = new GestoreTask();
        static void Main(string[] args)
        {
            Console.WriteLine("Console Application!");
            
            //una classe che è in grado di gestire le istanze delle task
            //Gestore dei task --> classe
            //Task --> classe
            //Chiedere una data --> DateTime.TryParse

            do
            {
                Console.WriteLine();
                Console.WriteLine("Menù");
                Console.WriteLine("1. Visualizza Task");
                Console.WriteLine("2. Aggiungi Task");
                Console.WriteLine("3. Elimina Task");
                Console.WriteLine("4. Salva i Task");
                Console.WriteLine("5. Cerca Task");
                Console.WriteLine("0. Esci");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        //Visualizza Task
                        VisualizzaTask();
                        break;
                    case '2':
                        //Aggiungi Task
                        AggiungiTask();
                        break;
                    case '3':
                        //Elimina Task
                        EliminaTask();
                        break;
                    case '4':
                        //Salva Task
                        SalvaTask();
                        break;
                    case '5':
                        //Filtra Task
                        FiltraTask();
                        break;
                    case '0':
                        //Esci
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Scelta non valida;");
                        break;
                }

            } while (true);

        }

        private static void SalvaTask()
        {
            //Salvare su un file
            const string fileName = @"Task.txt";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(gestore.VisualizzaTask());
            }
        }

        private static void FiltraTask()
        {
            //Filtra
            Console.Write("Filtra per Livello di importanza.\n Scegli un livello: \n 1. Basso [b]\n 2. Medio [m] \n 3. Alto [a]\n");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.B:
                    Console.WriteLine(gestore.Filtra(Livello.Basso));
                    break;
                case ConsoleKey.M:
                    Console.WriteLine(gestore.Filtra(Livello.Medio));
                    break;
                case ConsoleKey.A:
                    Console.WriteLine(gestore.Filtra(Livello.Alto));
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Scelta non valida;");
                    break;
            }
        }

        private static void EliminaTask()
        {
            //Elimina Task
            gestore.Reset();
            Console.WriteLine("\nTutti i Task sono stati eliminati;");

        }

        private static void VisualizzaTask()
        {
            //Visualizzazione
            Console.WriteLine("\nLista Task");
            Console.WriteLine(gestore.VisualizzaTask());
            Console.WriteLine();
        }

        private static void AggiungiTask()
        {
            //Aggiungi Task
            Livello liv = 0;
            Console.WriteLine("\nInserire il nome del Task:");
            string nome_task = Console.ReadLine();

            Console.WriteLine("Inserire la data di scadenza: [format: 19-Mar-2021]");
            DateTime data_task = new DateTime();
           
            while (!DateTime.TryParse(Console.ReadLine(), out data_task) || data_task < DateTime.Today)
                    Console.WriteLine("Data di scadenza non valida. Inserire un'altra data.");

            string data= data_task.ToShortDateString();
            Task t;

            Console.Write("Inserire il livello di importanza: \n 1. Basso [b]\n 2. Medio [m] \n 3. Alto [a]\n");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.B:
                    liv = Livello.Basso;
                    t = gestore.CreaTask(nome_task, data, liv);
                    Console.WriteLine($"\nIl Task n.{t.ID} è stato creato.");
                    break;
                case ConsoleKey.M:
                    liv = Livello.Medio;
                    t = gestore.CreaTask(nome_task, data, liv);
                    Console.WriteLine($"\nIl Task n.{t.ID} è stato creato.");
                    break;
                case ConsoleKey.A:
                    liv = Livello.Alto;
                    t = gestore.CreaTask(nome_task, data, liv);
                    Console.WriteLine($"\nIl Task n.{t.ID} è stato creato.");
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("\nScelta non valida. Il task non è stato creato.");
                    break;
            }
        }
    }
}
