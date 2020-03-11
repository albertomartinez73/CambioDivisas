using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Models;
using System;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Specification
{
    public class SpecificationTransactions : ISpecificationTransactions
    {
        public bool IsSatisfyiedBy(Transactions transactions)
        {
            try
            {
                return !transactions.Sku.Equals("") && transactions.Sku != null
                    && !transactions.Amount.Equals("") && transactions.Amount != null
                    && !transactions.Currency.Equals("") && transactions.Currency != null;
            }
            catch (Exception ex)
            {
                throw new SpecificationException("No se han podido validar las transacciones: TransactionsSpecification ", ex);
            }
        }
    }
}