using ExamenAlbertoMartinezCambioDivisas.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDivisas.UnitTests.Model
{
    [TestClass]
    public class TransactionModelTest
    {

        [TestMethod]
        public void TransactionCorrecto()
        {
            var transaction = new Transactions { Sku = "C6618", Amount = 33.9M, Currency = "USD" };
            Assert.IsNotNull(transaction);
        }


        [TestMethod]
        public void TransactionPrimerVacio()
        {
            var transaction = new Transactions { Sku = "", Amount = 33.9M, Currency = "USD" };
            Assert.IsTrue(string.IsNullOrEmpty(transaction.Sku));
        }


        [TestMethod]
        public void TransactionTercerVacio()
        {
            var transaction = new Transactions { Sku = "C6618", Amount = 33.9M, Currency = "" };
            Assert.IsTrue(string.IsNullOrEmpty(transaction.Currency));
        }
    }
}
