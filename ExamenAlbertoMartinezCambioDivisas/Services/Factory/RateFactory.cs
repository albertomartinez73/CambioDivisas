using ExamenAlbertoMartinezCambioDivisas.Models;
using System;
using System.Collections.Generic;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Services.Specification;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Factory
{
    public class RateFactory : IRateFactory
    {
        private ISpecificationRates _specificationRates = new SpecificationRates();
        private List<Rates> _ratesList = new List<Rates>();

        public List<Rates> CreateRatesList(List<Rates> ratesList)
        {
            try
            {
                foreach (var item in ratesList)
                {
                    if (this._specificationRates.IsSatisfyiedBy(item) == true)
                    {
                        this._ratesList.Add(item);
                    }
                    else { 
                        throw new FactoryException("No se ha podido crear el objeto rates: RatesFactory");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FactoryException("No se ha podido crear el objeto rates: RatesFactory", ex);

            }
            return this._ratesList;
        }
    }
}