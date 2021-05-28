using System;
using System.Collections;

namespace EsercitazioneW2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList tasks = new ArrayList();
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();

                switch (scelta)
                {
                    case 1:
                        Task taskDaAggiungere = HandlingTasks.InserisciTask();
                        tasks.Add(taskDaAggiungere);
                        break;
                    case 2:
                        HandlingTasks.StampaTasks(tasks);
                        break;
                    case 3:
                        Task taskDaCancellare = HandlingTasks.CercaTask(tasks);
                        try
                        {
                            tasks.Remove(taskDaCancellare);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Veicolo non trovato");

                        }

                        break;
                    case 4:
                        TaskFileIO.StampaSuFile(tasks);
                        break;
                    case 0: //casistica dell'eccezione
                        break;
                    default: //un numero diverso da 0
                        continua = false;
                        Console.WriteLine("Arrivederci");
                        break;
                }
            }

        }

        public static int SchermoMenu()
        {
            Console.WriteLine("1. Aggiungi task");
            Console.WriteLine("2. Visualizza tutti i tuoi task");
            Console.WriteLine("3. Elimina un task");
            Console.WriteLine("4. Salva tutti i tuoi task su file");
            Console.WriteLine("5. Per uscire");
            int scelta = 0;
            try
            {
                scelta = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Inserisci un numero corretto");
                scelta = 0;
            }
            return scelta;
        }
    }
}