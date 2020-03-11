using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Models;
using System;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Specification
{
    public class SpecificationRates : ISpecificationRates
    {
        public bool IsSatisfyiedBy(Rates rates)
        {
            try
            {
                return !rates.From.Equals("") && rates.From != null
                       && !rates.To.Equals("") && rates.To != null
                       && !rates.Rate.Equals("") && rates.Rate != null;
            }
            catch (Exception ex)
            {
                throw new SpecificationException("Error a la hora de validar los Rates: RatesSpecification", ex);
            }
        }
    }
}