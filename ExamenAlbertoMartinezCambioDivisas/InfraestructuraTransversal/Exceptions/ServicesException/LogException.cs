using System;

namespace ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions
{
    public class LogException : Exception
    {
        public LogException() : base() { }
        public LogException(string message) : base(message) { }
        public LogException(string message, Exception innerException) : base(message, innerException) { }
    }
}