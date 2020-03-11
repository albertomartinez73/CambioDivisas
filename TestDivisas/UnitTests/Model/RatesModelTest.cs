using ExamenAlbertoMartinezCambioDivisas.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDivisas.UnitTests.Model
{
    [TestClass]
    public class RatesModelTest
    {
        [TestMethod]
        public void RatesCorrecto()
        {
            var rates = new Rates { From = "USD", To = "EUR", Rate = 0.65M };
            Assert.IsNotNull(rates);
        }

        [TestMethod]
        public void RatesPrimeroVacio()
        {
            var rates = new Rates { From = "", To = "EUR", Rate = 0.65M };
            Assert.IsTrue(string.IsNullOrEmpty(rates.From));
        }

        [TestMethod]
        public void RatesSegundoVacio()
        {
            var rates = new Rates { From = "USD", To = "", Rate = 0.65M };
            Assert.IsTrue(string.IsNullOrEmpty(rates.To));
        }

        [TestMethod]
        public void RatesTerceroNumero()
        {
            var rates = new Rates { From = "USD", To = "", Rate = 0.65M };
            Assert.IsNotNull(rates.Rate);
        }


    }
}
