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

        internal static Task InserisciTask()
        {
            Task t = new Task();
            try
            {
                bool success;
                //int
                Console.WriteLine("Inserisci numero identificativo di 4 cifre:");
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

        //stampa task
        public static void StampaTasks(ArrayList tasks)
        {
            foreach (Task t in tasks)
            {
                Console.WriteLine(t);
            }
        }


        //Trova Task da gestire

        public static Task CercaTask(ArrayList tasks)
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
