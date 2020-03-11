using ExamenAlbertoMartinezCambioDivisas.Models;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Specification
{
    public interface ISpecificationRates
    {
        bool IsSatisfyiedBy(Rates rates);
    }
}
