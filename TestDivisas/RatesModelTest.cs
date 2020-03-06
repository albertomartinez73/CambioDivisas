using ExamenAlbertoMartinezCambioDivisas.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDivisas
{
    [TestClass]
    public class RatesModelTest
    {
        [TestMethod]
        public void RatesCorrecto()
        {
            Rates rates = new Rates { From = "USD", To = "EUR", Rate = 3.65M };
            Assert.IsNotNull(rates);
        }

        [TestMethod]
        public void RatesPrimeroVacio()
        {

            Rates rates = new Rates { From = "", To = "EUR", Rate = 3.65M };
            Assert.IsTrue(string.IsNullOrEmpty(rates.From));


        }

        [TestMethod]
        public void RatesSegundoVacio()
        {

            Rates rates = new Rates { From = "USD", To = "", Rate = 3.65M };
            Assert.IsTrue(string.IsNullOrEmpty(rates.To));


        }
    }
}
