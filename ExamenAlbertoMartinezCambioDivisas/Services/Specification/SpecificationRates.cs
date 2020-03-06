using ExamenAlbertoMartinezCambioDivisas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Specification
{
    public class SpecificationRates : ISpecificationRates
    {
        public bool IsSatisfyiedBy(Rates rates)
        {
            if (!rates.From.Equals("") && !rates.To.Equals(""))
            {
                return true;

            } else
            {
                return false;
            }
        }
    }
}