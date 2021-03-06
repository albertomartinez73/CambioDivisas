﻿using System;

namespace ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions.ControllerException
{
    public class ControllerException : Exception
    {
        public ControllerException() : base() { }
        public ControllerException(string message) : base(message) { }
        public ControllerException(string message, Exception innerException) : base(message, innerException) { }
    }
}