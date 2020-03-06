using ExamenAlbertoMartinezCambioDivisas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Services.Specification;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Factory
{
    public class RateFactory : IRateFactory
    {
        private Rates Rates;
        ISpecificationRates rateSpecification = new SpecificationRates();
        public List<Rates> ListadoRates { get; set; } = new List<Rates>();
        public void CreateRate(Rates rate)
        {
            try
            {
                if (rateSpecification.IsSatisfyiedBy(rate))
                {
                    this.Rates = new Rates
                    {
                        From = rate.From,
                        To = rate.To,
                        Rate = rate.Rate
                    };

                    this.ListadoRates.Add(this.Rates);

                } else
                {
                    throw new SpecificationException("Error en el SpecificationRate: No se pudo crear el elemento Rate.");
                }

            }
            catch (Exception e)
            {
                throw new RatesFactoryExceptions("Error en RatesFactory ", e);
            }
        }

        public List<Rates> ListaRates()
        {
            return this.ListadoRates;
        }
    }
}