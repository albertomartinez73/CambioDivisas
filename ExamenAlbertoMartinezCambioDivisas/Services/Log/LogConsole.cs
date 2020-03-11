using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using System;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Log
{
    public class LogConsole : ILog
    {
        public void WriteLog(string message)
        {
            var date = DateTime.Now;

            try
            {
                Console.WriteLine($"[{date}] {message}");
            }
            catch (Exception ex)
            {
                throw new LogException("No ha sido posible escribir el log en la consola: LogConsole.", ex);
            }
        }
    }
}