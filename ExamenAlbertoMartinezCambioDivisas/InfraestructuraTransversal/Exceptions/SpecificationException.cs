using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions
{
    public class SpecificationException : Exception
    {
        public SpecificationException() : base() { }
        public SpecificationException(string message) : base(message) { }
        public SpecificationException(string message, Exception innerException) : base(message, innerException) { }
    }
}