using ExamenAlbertoMartinezCambioDivisas.Controllers;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.RatesRepository;
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
    public class RateControllerTest
    {
        RatesController ratecontroller = new RatesController();
        private IRatesRepository repositorio = new RatesRepository();
        private Rates rates = new Rates { From = "USD", To = "EUR", Rate = 0.65M };

        [TestMethod]
        public async Task Index()
        {
            var resultado = await ratecontroller.Index();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);
        }

        [TestMethod]
        public async Task create()
        {
            repositorio.Insert(rates);
            await repositorio.Save();
            var guardado = await repositorio.GetById(rates.Id);
            Assert.IsNotNull(guardado);
        }
    }
}
