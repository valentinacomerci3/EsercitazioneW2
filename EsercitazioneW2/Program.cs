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
                        Task taskDaAggiungere = HandlingTasks.CompilazioneTask();
                        tasks.Add(taskDaAggiungere);
                        break;
                    case 2:
                        HandlingTasks.VisualizzaTasks(tasks);
                        break;
                    case 3:
                        Task taskDaEliminare = HandlingTasks.ScegliTask(tasks);
                        try
                        {
                            tasks.Remove(taskDaEliminare);
                            TaskFileIO.StampaSuFile(tasks);

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Task non trovato");

                        }

                        break;
                    case 4:
                        TaskFileIO.StampaSuFile(tasks);
                        break;
                    case 5:
                        HandlingTasks.StampaImportanza(tasks);
                        break;
                    case 0: //per eccezione
                        break;
                    default: //numeri diversi da 012345 ma prompto user di inserire 6 
                        continua = false;
                        Console.WriteLine("Grazie, Arrivederci");
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
            Console.WriteLine("5. Salva tutti i tuoi task su file");
            Console.WriteLine("6. Per uscire");
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