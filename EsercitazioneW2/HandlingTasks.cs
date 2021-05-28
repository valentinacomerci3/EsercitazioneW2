using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneW2
{
    public static class HandlingTasks
    {

        //inserisci task

        internal static Task CompilazioneTask()
        {
            Task t = new Task();
            try
            {
                bool success;
                //int
                Console.WriteLine("Inserisci un numero identificativo per il tuo task:");
                t.NumeroIdentificativo = VerificaValidita();//check con funzione definita a parte
                //string
                Console.WriteLine("Inserisci descrizione");
                t.Descrizione = Console.ReadLine();
                //datetime
                Console.WriteLine("Inserisci data di scadenza"); //check con tryparse
                bool esito = DateTime.TryParse(Console.ReadLine(), out DateTime scadenza);
                while (!esito)
                {
                    Console.WriteLine("Hai inserito la data corettamente?");
                    esito = DateTime.TryParse(Console.ReadLine(), out scadenza);
                }
                t.DataScadenza = scadenza;
                //enum
                Console.WriteLine("Inserisci livello importanza:");
                int[] values = new int[] { 0, 1, 2 };
                foreach (int enumValue in values)
                {
                    Console.WriteLine(Enum.GetName(typeof(Importanza), enumValue));
                }
                success = Enum.TryParse(Console.ReadLine(), out Importanza i);
                t.Importance = i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return t;
        }

        //stampa task a video
        public static void VisualizzaTasks(ArrayList tasks)
        {
            foreach (Task t in tasks)
            {
                Console.WriteLine(t);
            }
        }

        //stampa task a video based on importance
        public static void StampaImportanza(ArrayList tasks)
            
        {
            bool continua = true;
            while (continua)
            {
                int a = OpzioniImportanza();
                

                switch (a)
                {
                    case 1:
                        Console.WriteLine("I task marcati con Importanza Alta sono");
                        foreach (Task t in tasks)
                        {
                            if (t.Importance == Importanza.UNO)
                                Console.WriteLine(t);
                        }
                        break;
                    case 2:

                        Console.WriteLine("I task marcati con Importanza Media sono");
                        foreach (Task t in tasks)
                        {
                            if (t.Importance == Importanza.DUE)
                                Console.WriteLine(t);
                        }
                        break;
                    case 3:

                        Console.WriteLine("I task marcati con Importanza Bassa sono");
                        foreach (Task t in tasks)
                        {
                            if (t.Importance == Importanza.TRE)
                                Console.WriteLine(t);
                        }
                        break;
                    default: 
                        continua = false;
                        Console.WriteLine("Grazie, Arrivederci");
                        break;
                }
            }

        }

        public static int OpzioniImportanza()
        {
                Console.WriteLine("Seleziona importanza: -Premi 1 per Alta\n -Premi 2 per Media\n -Premi 3 per bassa");
            int a = 0;
            try
             {
                 a = Convert.ToInt32(Console.ReadLine());
             }
             catch (Exception)
             {
                 Console.WriteLine("Inserisci un numero corretto");
                a = 0;
             }
             return a;
            }



        //Trova Task da gestire

        public static Task ScegliTask(ArrayList tasks)
        {
            Console.WriteLine("Inserisci numero identificativo del task da gestire: ");

            int numeroid = VerificaValidita();
            foreach (Task t in tasks)
            {
                if (t.NumeroIdentificativo == numeroid)
                {
                    return t;
                }
            }
            return null;
        }

        public static int VerificaValidita()
        {
            bool success = Int32.TryParse(Console.ReadLine(), out int value);
            while (!success)
            {
                Console.WriteLine("Input non riconosciuto - Controlla di aver inserito un valore esatto ");
                success = Int32.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }
    } 
}
