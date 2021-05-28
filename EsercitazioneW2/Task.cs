using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneW2
{
    public enum Importanza
    {
        ALTA ,
        MEDIA,
        BASSA,
        //EURO4
    }
    public class Task
    {

        public double NumeroIdentificativo { get; set; }
        public String Descrizione { get; set; }
        public DateTime DataScadenza { get; set; } = new DateTime(2000, 1, 1);
        public Importanza Importance { get; set; }

        //public double FUNZ { get { return FUNZ(); } }

        public override string ToString()
        {
            return $"NumeroID: {NumeroIdentificativo} - Descrizione: {Descrizione} \n" +
                $"Data di Scadenza: {DataScadenza} - Importanza: {Importance} ";
        }


    }
}
