using ExamenAlbertoMartinezCambioDivisas.Models;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Specification
{
    public interface ISpecificationTransactions
    {
        bool IsSatisfyiedBy(Transactions transactions);
    }
}
