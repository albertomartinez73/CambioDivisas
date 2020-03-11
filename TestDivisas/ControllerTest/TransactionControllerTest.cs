using ExamenAlbertoMartinezCambioDivisas.Controllers;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.TransactionsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestDivisas.IntegrationTests
{
    [TestClass]
    public class TransactionControllerTest
    {
        TransactionsController transactioncontroller = new TransactionsController();
        private ITransactionsRepository repositorio = new TransactionsRepository();
        private Transactions transaction = new Transactions { Sku = "C6618", Amount = 33.9M, Currency = "USD" };

        [TestMethod]
        public async Task Index()
        {
            var resultado = await transactioncontroller.Index();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);
        }

        [TestMethod]
        public async Task create()
        {
            repositorio.Insert(transaction);
            await repositorio.Save();
            var guardado = await repositorio.GetById(transaction.Id);
            Assert.IsNotNull(guardado);
        }
    }
}
