using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Logs
{
    public class Log
    {
        public static void LogToFile(string title, string message)
        {
            // Obtenha o caminho do diretório de trabalho do projeto de teste
            string directoryPath = Directory.GetCurrentDirectory();

            // Crie o caminho completo para o arquivo de log
            string fileName = Path.Combine(directoryPath, "FilesLogs", "LogsDay.txt");


            StreamWriter streamWriter;

            if (File.Exists(fileName))
            {
                //se existe o arquivo eu escrevo dentro dele
                streamWriter = File.AppendText(fileName);
            }
            else
            {
                //se não existir eu crio
                streamWriter= new StreamWriter(fileName);
            }

            streamWriter.WriteLine("Log:");
            streamWriter.WriteLine(DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            streamWriter.WriteLine("Title Message : {0}", title);
            streamWriter.WriteLine("Message : {0}", message);
            streamWriter.WriteLine("------------------------------------------");
            streamWriter.WriteLine("");
            streamWriter.Close();

        }
    }
}
