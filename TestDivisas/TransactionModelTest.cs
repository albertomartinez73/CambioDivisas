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
    public class TransactionModelTest
    {
        [TestMethod]
        public void TransactionCorrecto()
        {

            Transactions transaction = new Transactions { Sku = "C6618", Amount = 33.9M, Currency = "USD" };
            Assert.IsNotNull(transaction);

        }

        [TestMethod]
        public void TransactionPrimerVacio()
        {

            Transactions transaction = new Transactions { Sku = "", Amount = 48.9M, Currency = "USD" };
            Assert.IsTrue(string.IsNullOrEmpty(transaction.Sku));


        }


        [TestMethod]
        public void TransactionTercerVacio()
        {

            Transactions transaction = new Transactions { Sku = "B18", Amount = 48.9M, Currency = "" };
            Assert.IsTrue(string.IsNullOrEmpty(transaction.Currency));

        }
    }
}
