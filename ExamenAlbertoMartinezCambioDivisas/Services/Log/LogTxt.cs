using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using System;
using System.IO;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Log
{
    //Escibir en TXt
    public class LogTxt : ILog
    {
        private readonly string _path;
        public LogTxt()
        {
            this._path = AppDomain.CurrentDomain.BaseDirectory + "LogGenerado";
            Directory.CreateDirectory(this._path);

        }
        public void WriteLog(string message)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var time = DateTime.Now.ToString("HH:mm:ss");

            using (var sw = new StreamWriter(this._path + "/logfile.txt", true))
            {
                try
                {
                    sw.WriteLine("[" + date + " " + time + "] " + message);
                }
                catch (Exception ex)
                {
                    throw new LogException("No ha sido posible escribir el log en el fichero: LogTxt.", ex);
                }
            }
        }
    }
}