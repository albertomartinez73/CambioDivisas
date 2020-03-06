using ExamenAlbertoMartinezCambioDivisas.Services.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDivisas
{
    [TestClass]
    public class LogServicesTest
    {
        public string Contain = "";
        private readonly ILog _log = new LogFichero();

        [TestInitialize]
        public void LogServiceInit()
        {
            Contain = "Esto es una prueba de funcionamiento!";
            _log.EscribirLog(Contain);
        }

        [TestMethod]
        public void LogWrite()
        {
            _log.EscribirLog(Contain);
        }
    }
}
