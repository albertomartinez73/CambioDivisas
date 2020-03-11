using System;

namespace ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions
{
    public class FactoryException : Exception
    {
        public FactoryException() : base() { }
        public FactoryException(string message) : base(message) { }
        public FactoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}