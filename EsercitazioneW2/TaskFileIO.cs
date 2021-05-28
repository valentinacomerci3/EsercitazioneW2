using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneW2
{
    public static class TaskFileIO
    {

        public static void StampaSuFile(ArrayList tasks)
        {
            string path = Path.Combine(Environment
                .GetFolderPath(Environment.SpecialFolder.Desktop),
                "tasks.txt");
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    foreach (Task t in tasks)
                    {
                        writer.WriteAsync(t.ToString());
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
