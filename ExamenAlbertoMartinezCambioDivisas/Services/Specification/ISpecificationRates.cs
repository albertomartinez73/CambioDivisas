using ExamenAlbertoMartinezCambioDivisas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Specification
{
    public interface ISpecificationRates
    {
        bool IsSatisfyiedBy(Rates rates);
    }
}
